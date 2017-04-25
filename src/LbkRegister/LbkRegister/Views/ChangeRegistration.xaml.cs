using System.Collections.Generic;
using System.Windows;
using LbkRegister.Data;
using LbkRegister.Domain;

namespace LbkRegister.Views {
    /// <summary>
    /// Interaction logic for ChangeRegistration.xaml
    /// </summary>
    public partial class ChangeRegistration : Window {
        private readonly IEnumerable<Registration> _registrations;

        public ChangeRegistration(Registration registration, IEnumerable<Registration> registrations) {
            InitializeComponent();

            _registrations = registrations;
            DataContext = registration;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Persistence.Save(_registrations);
            Close();
        }
    }
}
