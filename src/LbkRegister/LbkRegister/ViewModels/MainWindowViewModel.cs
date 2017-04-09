using System;
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

        public MainWindowViewModel() {
            UpdateRegistrations();
        }

        private IEnumerable<Registration> LoadRegistrations() {
            return Persistence.Load();
        }

        internal void UpdateRegistrations() {
            Registrations = LoadRegistrations();
            Emails = Registrations.Any() 
                ? Registrations.Select(x => x.OwnerEmail).Aggregate((y, z) => y + ";" + z) 
                : string.Empty;
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
