using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using LbkRegister.Data;
using LbkRegister.Domain;

namespace LbkRegister.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {        
        private IEnumerable<Registration> registrations;
        public IEnumerable<Registration> Registrations {
            get { return registrations; }
            set { SetField(ref registrations, value); }
        }

        private string emails;
        public string Emails {
            get { return emails; }
            set { SetField(ref emails, value); }
        }

        private int sixMonthsCount;
        public int SixMonthsCount {
            get { return sixMonthsCount; }
            set { SetField(ref sixMonthsCount, value); }
        }

        private int nineMonthsCount;
        public int NineMonthsCount {
            get { return nineMonthsCount; }
            set { SetField(ref nineMonthsCount, value); }
        }

        private int nineToFifteenMonthsCount;
        public int NineToFifteenMonthsCount {
            get { return nineToFifteenMonthsCount; }
            set { SetField(ref nineToFifteenMonthsCount, value); }
        }

        private int fifteenToTwentyFourMonthsCount;
        public int FifteenToTwentyFourMonthsCount {
            get { return fifteenToTwentyFourMonthsCount; }
            set { SetField(ref fifteenToTwentyFourMonthsCount, value); }
        }

        private int fifteenMonthsCount;
        public int FifteenMonthsCount {
            get { return fifteenMonthsCount; }
            set { SetField(ref fifteenMonthsCount, value); }
        }

        private int eightYearsCount;
        public int EightYearsCount {
            get { return eightYearsCount; }
            set { SetField(ref eightYearsCount, value); }
        }

        private int totalCount;
        public int TotalCount {
            get { return totalCount; }
            set { SetField(ref totalCount, value); }
        }

        public MainWindowViewModel() {
            UpdateRegistrations();
        }
        
        internal void UpdateRegistrations() {
            Registrations = Persistence.Load();
            SetRegistrationNumbers();

            Emails = Registrations.Any() 
                ? Registrations.Select(x => x.OwnerEmail).Aggregate((y, z) => y + ";" + z) 
                : string.Empty;

            SixMonthsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.SixMonths).Count();
            NineMonthsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.NineMonths).Count();
            NineToFifteenMonthsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.NineToFifteenMonths).Count();
            FifteenToTwentyFourMonthsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.FifteenToTwentyFourMonths).Count();
            FifteenMonthsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.FifteenMonths).Count();
            EightYearsCount = Registrations.Where(r => r.Group == CompetitionClass.Categories.EightYears).Count();
            TotalCount = Registrations.Count();
        }

        private void SetRegistrationNumbers() {
            /* 
                Ring
                Grupp
                Ras
                klass (yngst först)
                kön (hane först)
                namn (bokstavsordning)  
             */

            var regs = Registrations
                .OrderBy(c => c.Ring)
                .ThenBy(c => c.CompetitionGroup)
                .ThenBy(c => c.Breed)
                .ThenBy(c => c.Group)
                .ThenBy(c => c.Sex)
                .ThenBy(c => c.Name);

            var nextNumber = 1;
            foreach (var registration in regs) {
                registration.CompetitionNumber = nextNumber;

                nextNumber++;
            }            
        }

        internal void DeleteRegistration(Registration registration) {
            Persistence.Delete(registration, Registrations);
            UpdateRegistrations();
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(field, value)) {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}