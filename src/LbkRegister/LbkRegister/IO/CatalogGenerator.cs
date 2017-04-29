using System.Collections.Generic;
using System.Linq;
using GemBox.Spreadsheet;
using LbkRegister.Data;
using LbkRegister.Domain;

namespace LbkRegister.Dependencies {
    internal class CatalogGenerator {
        private readonly IEnumerable<Registration> _registrations;

        public CatalogGenerator(IEnumerable<Registration> registrations) {
            _registrations = registrations;
        }

        internal void Create() {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var file = new ExcelFile();

            CreateRingSheet(file, "Ring 1", CompetitionRing.Rings.One);

            var ringTwoSheet = file.Worksheets.Add("Ring 2");

            Persistence.SaveCatalog(file);
        }

        private void CreateRingSheet(ExcelFile file, string sheetName, CompetitionRing.Rings ring) {
            /* 
                Ring
                Grupp
                Ras
                klass (yngst först)
                kön (hane först)
                namn (bokstavsordning)  
             */

            var ringOneSheet = file.Worksheets.Add(sheetName);
            var registrations = _registrations.Where(r => r.Ring == ring)
                .OrderBy(c => c.CompetitionGroup)
                .ThenBy(c => c.Breed)
                .ThenBy(c => c.Group)
                .ThenBy(c => c.Sex)
                .ThenBy(c => c.Name);

            CompetitionGroup.Groups? lastGroup = null;
            string lastBreed = null;
            CompetitionClass.Categories? lastClass = null;
            string lastSex = null;

            foreach (var registration in registrations) {
                if (lastGroup.HasValue == false || registration.CompetitionGroup != lastGroup.Value) {
                    // new group
                }

                if (string.IsNullOrEmpty(lastBreed) || registration.Breed.Equals(lastBreed) == false) {
                    // new breed
                }

                if (lastClass.HasValue == false || registration.Group != lastClass.Value) {
                    // new class
                }

                if (string.IsNullOrEmpty(lastSex) || registration.Sex.Equals(lastSex) == false) {
                    // new sex
                }

                // write next registration
            }
        }
    }
}
