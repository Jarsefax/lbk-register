using System;
using System.Linq;

namespace LbkRegister.Domain {
    public class Registration {
        private const string _breedIdentifier = "Ras:";
        private const string _nameIdentifier = "Namn enligt registreringsbevis:";
        private const string _identificationNumberIdentifier = "Registreringsnummer:";
        private const string _sexIdentifier = "Kön:";
        private const string _birthDateIdentifier = "Födelsedatum:";
        private const string _groupIdentifier = "Anmäler till:";
        private const string _fatherIdentifier = "Fader:";
        private const string _motherIdentifier = "Moder:";
        private const string _breederIdentifier = "Uppfödare:";
        private const string _ownerNameIdentifier = "Ägare:";
        private const string _ownerAddressIdentifier = "Din gatuadress:";
        private const string _ownerPostalCodeIdentifier = "Postnummer:";
        private const string _ownerCityIdentifier = "Ort:";
        private const string _ownerPhoneNumberIdentifier = "Ditt telefon nummer:";
        private const string _ownerEmailIdentifier = "Din epost:";
        private const string _noteIdentifier = "Meddelande:";

        public int? CompetitionNumber { get; set; }
        public CompetitionGroup.Groups? CompetitionGroup { get; set; }
        public string Source { get; }
        public string Breed { get; set; }
        public bool BreedError => Breed.FromBreed() == Domain.CompetitionGroup.Groups.Unknown;
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public CompetitionClass.Categories Group { get; set; }
        public string GroupName => Group.ToName();
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Breeder { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPostalCode { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }
        public string Note { get; set; }

        public Registration() { }

        public Registration(string input) {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Source = input;
            SetBreed(lines);
            SetName(lines);
            SetIdentificationNumber(lines);
            SetSex(lines);
            SetBirthDate(lines);
            SetGroup(lines);
            SetFather(lines);
            SetMother(lines);
            SetBreeder(lines);
            SetOwnerName(lines);
            SetOwnerAddress(lines);
            SetOwnerPostalCode(lines);
            SetOwnerCity(lines);
            SetOwnerPhoneNumber(lines);
            SetOwnerEmail(lines);
            SetNote(lines);
        }

        private void SetBreed(string[] lines) {
            var line = lines.Single(l => l.Contains(_breedIdentifier));
            Breed = line.Substring(line.IndexOf(_breedIdentifier) + _breedIdentifier.Length).Trim();
        }

        private void SetName(string[] lines) {
            var line = lines.Single(l => l.Contains(_nameIdentifier));
            Name = line.Substring(line.IndexOf(_nameIdentifier) + _nameIdentifier.Length).Trim();
        }

        private void SetIdentificationNumber(string[] lines) {
            var line = lines.Single(l => l.Contains(_identificationNumberIdentifier));
            IdentificationNumber = line.Substring(line.IndexOf(_identificationNumberIdentifier) + _identificationNumberIdentifier.Length).Trim();
        }

        private void SetSex(string[] lines) {
            var line = lines.Single(l => l.Contains(_sexIdentifier));
            Sex = line.Substring(line.IndexOf(_sexIdentifier) + _sexIdentifier.Length).Trim();
        }

        private void SetBirthDate(string[] lines) {
            var line = lines.Single(l => l.Contains(_birthDateIdentifier));
            BirthDate = line.Substring(line.IndexOf(_birthDateIdentifier) + _birthDateIdentifier.Length).Trim();
        }

        private void SetGroup(string[] lines) {
            var line = lines.Single(l => l.Contains(_groupIdentifier));
            var value = line.Substring(line.IndexOf(_groupIdentifier) + _groupIdentifier.Length).Trim();

            Group = value.GetCategory();
        }

        private void SetFather(string[] lines) {
            var line = lines.Single(l => l.Contains(_fatherIdentifier));
            Father = line.Substring(line.IndexOf(_fatherIdentifier) + _fatherIdentifier.Length).Trim();
        }

        private void SetMother(string[] lines) {
            var line = lines.Single(l => l.Contains(_motherIdentifier));
            Mother = line.Substring(line.IndexOf(_motherIdentifier) + _motherIdentifier.Length).Trim();
        }

        private void SetBreeder(string[] lines) {
            var line = lines.Single(l => l.Contains(_breederIdentifier));
            Breeder = line.Substring(line.IndexOf(_breederIdentifier) + _breederIdentifier.Length).Trim();
        }

        private void SetOwnerName(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerNameIdentifier));
            OwnerName = line.Substring(line.IndexOf(_ownerNameIdentifier) + _ownerNameIdentifier.Length).Trim();
        }

        private void SetOwnerAddress(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerAddressIdentifier));
            OwnerAddress = line.Substring(line.IndexOf(_ownerAddressIdentifier) + _ownerAddressIdentifier.Length).Trim();
        }

        private void SetOwnerPostalCode(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerPostalCodeIdentifier));
            OwnerPostalCode = line.Substring(line.IndexOf(_ownerPostalCodeIdentifier) + _ownerPostalCodeIdentifier.Length).Trim();
        }

        private void SetOwnerCity(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerCityIdentifier));
            OwnerCity = line.Substring(line.IndexOf(_ownerCityIdentifier) + _ownerCityIdentifier.Length).Trim();
        }

        private void SetOwnerPhoneNumber(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerPhoneNumberIdentifier));
            OwnerPhoneNumber = line.Substring(line.IndexOf(_ownerPhoneNumberIdentifier) + _ownerPhoneNumberIdentifier.Length).Trim();
        }

        private void SetOwnerEmail(string[] lines) {
            var line = lines.Single(l => l.Contains(_ownerEmailIdentifier));
            OwnerEmail = line.Substring(line.IndexOf(_ownerEmailIdentifier) + _ownerEmailIdentifier.Length).Trim();
        }

        private void SetNote(string[] lines) {
            var line = lines.Single(l => l.Contains(_noteIdentifier));
            Note = line.Substring(line.IndexOf(_noteIdentifier) + _noteIdentifier.Length).Trim();
        }
    }
}
