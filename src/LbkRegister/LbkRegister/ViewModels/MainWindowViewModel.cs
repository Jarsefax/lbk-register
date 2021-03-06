﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private IEnumerable<Registration> sortedRegistrations;
        public IEnumerable<Registration> SortedRegistrations {
            get { return sortedRegistrations; }
            set { SetField(ref sortedRegistrations, value); }
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
        
        private int groupUnknownCount;
        public int GroupUnknownCount {
            get { return groupUnknownCount; }
            set { SetField(ref groupUnknownCount, value); }
        }

        private int groupOneCount;
        public int GroupOneCount {
            get { return groupOneCount; }
            set { SetField(ref groupOneCount, value); }
        }

        private int groupTwoCount;
        public int GroupTwoCount {
            get { return groupTwoCount; }
            set { SetField(ref groupTwoCount, value); }
        }

        private int groupThreeCount;
        public int GroupThreeCount {
            get { return groupThreeCount; }
            set { SetField(ref groupThreeCount, value); }
        }

        private int groupFourCount;
        public int GroupFourCount {
            get { return groupFourCount; }
            set { SetField(ref groupFourCount, value); }
        }

        private int groupFiveCount;
        public int GroupFiveCount {
            get { return groupFiveCount; }
            set { SetField(ref groupFiveCount, value); }
        }

        private int groupSixCount;
        public int GroupSixCount {
            get { return groupSixCount; }
            set { SetField(ref groupSixCount, value); }
        }

        private int groupSevenCount;
        public int GroupSevenCount {
            get { return groupSevenCount; }
            set { SetField(ref groupSevenCount, value); }
        }

        private int groupEightCount;
        public int GroupEightCount {
            get { return groupEightCount; }
            set { SetField(ref groupEightCount, value); }
        }

        private int groupNineCount;
        public int GroupNineCount {
            get { return groupNineCount; }
            set { SetField(ref groupNineCount, value); }
        }

        private int groupTenCount;
        public int GroupTenCount {
            get { return groupTenCount; }
            set { SetField(ref groupTenCount, value); }
        }

        private int pupBestInRaceCount;
        public int PupBestInRaceCount {
            get { return pupBestInRaceCount; }
            set { SetField(ref pupBestInRaceCount, value); }
        }

        private int adultBestInRaceCount;
        public int AdultBestInRaceCount {
            get { return adultBestInRaceCount; }
            set { SetField(ref adultBestInRaceCount, value); }
        }

        private int veteranBestInRaceCount;
        public int VeteranBestInRaceCount {
            get { return veteranBestInRaceCount; }
            set { SetField(ref veteranBestInRaceCount, value); }
        }

        private int pupBestInMotsattKönCount;
        public int PupBestInMotsattKönCount {
            get { return pupBestInMotsattKönCount; }
            set { SetField(ref pupBestInMotsattKönCount, value); }
        }

        private int adultBestInMotsattKönCount;
        public int AdultBestInMotsattKönCount {
            get { return adultBestInMotsattKönCount; }
            set { SetField(ref adultBestInMotsattKönCount, value); }
        }

        private int veteranBestInMotsattKönCount;
        public int VeteranBestInMotsattKönCount {
            get { return veteranBestInMotsattKönCount; }
            set { SetField(ref veteranBestInMotsattKönCount, value); }
        }

        private DataTable ringOneBreedCounts;
        public DataTable RingOneBreedCounts {
            get { return ringOneBreedCounts; }
            set { SetField(ref ringOneBreedCounts, value); }
        }

        private DataTable ringTwoBreedCounts;
        public DataTable RingTwoBreedCounts {
            get { return ringTwoBreedCounts; }
            set { SetField(ref ringTwoBreedCounts, value); }
        }

        public MainWindowViewModel() {
            UpdateRegistrations();
        }
        
        internal void UpdateRegistrations() {
            Registrations = Persistence.Load();
            SetRegistrationNumbers();

            SortedRegistrations = new List<Registration>(Registrations).OrderBy(r => r.CompetitionNumber);


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

            GroupUnknownCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Unknown).Count();
            GroupOneCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.One).Count();
            GroupTwoCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Two).Count();
            GroupThreeCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Three).Count();
            GroupFourCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Four).Count();
            GroupFiveCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Five).Count();
            GroupSixCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Six).Count();
            GroupSevenCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Seven).Count();
            GroupEightCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Eight).Count();
            GroupNineCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Nine).Count();
            GroupTenCount = Registrations.Where(r => r.CompetitionGroup == CompetitionGroup.Groups.Ten).Count();

            SetBestInCounts();
            SetBreedCounts();
        }

        private void SetBestInCounts() {
            var pups = Registrations.Where(r => 
                r.Group == CompetitionClass.Categories.SixMonths || 
                r.Group == CompetitionClass.Categories.NineMonths);
            var pupGroups = pups.GroupBy(p => p.Breed);

            var adults = Registrations.Where(r =>
                r.Group == CompetitionClass.Categories.NineToFifteenMonths ||
                r.Group == CompetitionClass.Categories.FifteenToTwentyFourMonths ||
                r.Group == CompetitionClass.Categories.FifteenMonths);
            var adultGroups = adults.GroupBy(p => p.Breed);

            var veterans = Registrations.Where(r =>
                r.Group == CompetitionClass.Categories.EightYears);
            var veteranGroups = veterans.GroupBy(p => p.Breed);

            // BIR (Best In Race) valp(2 klasser?)/vuxen(3 klasser!)/veteran per ras
            PupBestInRaceCount = GetBirCount(pups);
            AdultBestInRaceCount = GetBirCount(adults);
            VeteranBestInRaceCount = GetBirCount(veterans);

            // BIM (Best I Motsatt kön) om, minst, en hane och en hona i samma ras och klasser
            PupBestInMotsattKönCount = GetGroupBimCount(pupGroups);
            AdultBestInMotsattKönCount = GetGroupBimCount(adultGroups);
            VeteranBestInMotsattKönCount = GetGroupBimCount(veteranGroups);
        }

        private void SetBreedCounts() {
            var set = new DataSet();
            var ringOneTable = set.Tables.Add();
            ringOneTable.Columns.Add("Grupp");
            ringOneTable.Columns.Add("Ras");
            ringOneTable.Columns.Add("Antal");

            var ringTwoTable = set.Tables.Add();
            ringTwoTable.Columns.Add("Grupp");
            ringTwoTable.Columns.Add("Ras");
            ringTwoTable.Columns.Add("Antal");

            var breeds = Registrations
                .GroupBy(r => r.Breed.ToLower())
                .Select(g => new { Group = g.Key.FromBreed(), Breed = g.Key, Count = g.Count() })
                .OrderBy(o => o.Group)
                .ThenBy(o => o.Breed);

            var row = 0;
            foreach (var breed in breeds.Where(b => b.Group.FromGroup() == CompetitionRing.Rings.One)) {
                ringOneTable.Rows.Add();
                ringOneTable.Rows[row][0] = breed.Group.ToName();
                ringOneTable.Rows[row][1] = breed.Breed;
                ringOneTable.Rows[row][2] = breed.Count;
                row = row + 1;
            }

            row = 0;
            foreach (var breed in breeds.Where(b => b.Group.FromGroup() == CompetitionRing.Rings.Two)) {
                ringTwoTable.Rows.Add();
                ringTwoTable.Rows[row][0] = breed.Group.ToName();
                ringTwoTable.Rows[row][1] = breed.Breed;
                ringTwoTable.Rows[row][2] = breed.Count;
                row = row + 1;
            }

            RingOneBreedCounts = ringOneTable;
            RingTwoBreedCounts = ringTwoTable;
        }

        private int GetBirCount(IEnumerable<Registration> registrations) =>
            registrations
                .Select(p => p.Breed)
                .Distinct()
            .Count();

        private int GetGroupBimCount(IEnumerable<IGrouping<string, Registration>> groups) =>
            groups.Where(x => 
                x.Any(y => y.Gender == Sex.Genders.Male && 
                x.Any(z => z.Gender == Sex.Genders.Female))
            ).Count();

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
                .ThenBy(c => c.Breed.ToLower())
                .ThenBy(c => c.Grouping)
                .ThenBy(c => c.Sex)
                .ThenBy(c => c.Group)
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