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
            
            CreateRingSheet(file, "Ring 1", CompetitionRing.Rings.One);
            CreateRingSheet(file, "Ring 2", CompetitionRing.Rings.Two);

            Persistence.SaveCatalog(OdsGeneration.Generate(file));
        }

        internal void CreateBIS() {
            var file = new DataSet();

            var pups = _registrations
                .Where(c => c.IsChecked)
                .Where(c => c.Grouping == ClassGrouping.ClassGroupings.Pups)
                .OrderBy(c => c.CompetitionGroup)
            .ToList();
            CreateBisSheet(file, "Valpar", pups);

            var adults = _registrations
                .Where(c => c.IsChecked)
                .Where(c => c.Grouping == ClassGrouping.ClassGroupings.Adults)
                .OrderBy(c => c.CompetitionGroup)
            .ToList();
            CreateBisSheet(file, "Vuxna", adults);

            var veterans = _registrations
                .Where(c => c.IsChecked)
                .Where(c => c.Grouping == ClassGrouping.ClassGroupings.Veterans)
                .OrderBy(c => c.CompetitionGroup)
            .ToList();
            CreateBisSheet(file, "Veteraner", veterans);

            Persistence.SaveBIS(OdsGeneration.Generate(file));
        }

        private void CreateBisSheet(DataSet file, string sheetName, List<Registration> registrations) {
            var sheet = file.Tables.Add(sheetName);
            for (var i = 1; i <= _columnCount; i++) {
                sheet.Columns.Add(string.Empty);
            }

            FillInSheet(sheet, registrations);
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

            var registrations = _registrations
                .Where(r => r.Ring == ring)
                .OrderBy(c => c.CompetitionGroup)
                .ThenBy(c => c.Breed.ToLower())
                .ThenBy(c => c.Grouping)
                .ThenBy(c => c.Sex)
                .ThenBy(c => c.Group)
                .ThenBy(c => c.Name)
            .ToList();
            
            FillInSheet(ringSheet, registrations);
        }

        private void FillInSheet(DataTable sheet, List<Registration> registrations) {
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
                    breed = null;
                    klass = null;
                    gender = null;

                    AddRows(2, sheet, ref row);
                    sheet.Rows[row][0] = group.Value.ToName();
                }

                if (string.IsNullOrEmpty(breed) || registration.Breed.ToLower().Equals(breed.ToLower()) == false) {
                    // new breed
                    breed = registration.Breed;
                    klass = null;
                    gender = null;

                    AddRows(2, sheet, ref row);
                    sheet.Rows[row][3] = breed;
                }

                if (klass.HasValue == false || registration.Group != klass.Value) {
                    // new class
                    klass = registration.Group;
                    gender = registration.Gender;

                    AddRows(2, sheet, ref row);
                    sheet.Rows[row][1] = registration.Group.ToName();
                    sheet.Rows[row][5] = registration.Gender.ToLabel();
                }

                if (!gender.HasValue || registration.Gender != gender) {
                    // new gender
                    gender = registration.Gender;

                    AddRows(2, sheet, ref row);
                    sheet.Rows[row][1] = registration.Group.ToName();
                    sheet.Rows[row][5] = registration.Gender.ToLabel();
                }

                // write next registration
                AddRows(2, sheet, ref row);
                sheet.Rows[row][0] = registration.CompetitionNumber;
                sheet.Rows[row][2] = registration.CatalogRowOne;

                AddRows(1, sheet, ref row);
                sheet.Rows[row][2] = registration.CatalogRowTwo;

                AddRows(1, sheet, ref row);
                sheet.Rows[row][2] = registration.CatalogRowThree;

                AddRows(1, sheet, ref row);
                sheet.Rows[row][2] = registration.CatalogRowFour;
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
