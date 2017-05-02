using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LbkRegister.Data;
using LbkRegister.Domain;
using LbkRegister.Spreadsheet;

namespace LbkRegister.Dependencies {
    internal class CatalogGenerator {
        private const int _columnCount = 6;

        private readonly IEnumerable<Registration> _registrations;

        public CatalogGenerator(IEnumerable<Registration> registrations) {
            _registrations = registrations;
        }

        internal void Create() {
            var file = new DataSet();

            CreateRingSheet(file, "Okänd ring", CompetitionRing.Rings.Unknown);
            CreateRingSheet(file, "Ring 1", CompetitionRing.Rings.One);
            CreateRingSheet(file, "Ring 2", CompetitionRing.Rings.Two);

            Persistence.SaveCatalog(OdsGeneration.Generate(file));
        }

        private void CreateRingSheet(DataSet file, string sheetName, CompetitionRing.Rings ring) {
            /* 
                Ring
                Grupp
                Ras
                klass (yngst först)
                kön (hane först)
                namn (bokstavsordning)  
             */

            var ringSheet = file.Tables.Add(sheetName);
            for (var i = 1; i <= _columnCount; i++) {
                ringSheet.Columns.Add(string.Empty);
            }

            var registrations = _registrations.Where(r => r.Ring == ring)
                .OrderBy(c => c.CompetitionGroup)
                .ThenBy(c => c.Breed)
                .ThenBy(c => c.Group)
                .ThenBy(c => c.Gender)
                .ThenBy(c => c.Name)
            .ToList();

            CompetitionGroup.Groups? group = null;
            string breed = null;
            CompetitionClass.Categories? klass = null;
            Sex.Genders? gender = null;
            var row = -1;

            for (var i = 0; i < registrations.Count; i++) {
                var registration = registrations[i];

                if (group.HasValue == false || registration.CompetitionGroup != group.Value) {
                    // new group
                    group = registration.CompetitionGroup;

                    AddRows(2, ringSheet, ref row);
                    //row = row + 2;
                    ringSheet.Rows[row][0] = group.Value.ToName();
                }

                if (string.IsNullOrEmpty(breed) || registration.Breed.Equals(breed) == false) {
                    // new breed
                    breed = registration.Breed;

                    AddRows(2, ringSheet, ref row);
                    //row = row + 2;
                    ringSheet.Rows[row][3] = breed;
                }

                if (klass.HasValue == false || registration.Group != klass.Value) {
                    // new class
                    klass = registration.Group;
                    gender = registration.Gender;

                    AddRows(2, ringSheet, ref row);
                    //row = row + 2;
                    ringSheet.Rows[row][1] = registration.Group.ToName();
                    ringSheet.Rows[row][5] = registration.Gender.ToLabel();
                }

                if (!gender.HasValue || registration.Gender != gender) {
                    // new gender
                    AddRows(2, ringSheet, ref row);
                    //row = row + 2;
                    ringSheet.Rows[row][1] = registration.Group.ToName();
                    ringSheet.Rows[row][5] = registration.Gender.ToLabel();
                }

                // write next registration
                AddRows(1, ringSheet, ref row);
                //row = row + 1;
                ringSheet.Rows[row][0] = registration.CompetitionNumber;
                ringSheet.Rows[row][2] = registration.CatalogRowOne;
                
                AddRows(1, ringSheet, ref row);
                ringSheet.Rows[row][2] = registration.CatalogRowTwo;

                AddRows(1, ringSheet, ref row);
                ringSheet.Rows[row][2] = registration.CatalogRowThree;
            }
        }

        private void AddRows(int numberOfNewRows, DataTable sheet, ref int row) {
            for (var i = 0; i < numberOfNewRows; i++) {
                sheet.Rows.Add();
                row = row + 1;
            }
        }
    }
}
