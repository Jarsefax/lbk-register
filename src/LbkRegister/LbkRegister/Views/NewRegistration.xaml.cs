using System.Collections.Generic;
using System.Windows;
using LbkRegister.Data;
using LbkRegister.Domain;

namespace LbkRegister.Views {
    public partial class NewRegistration : Window {
        private IEnumerable<Registration> _existing;

        public NewRegistration(IEnumerable<Registration> existing) {
            InitializeComponent();

            _existing = existing;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Persistence.Save(DataContext as Registration, _existing);
            Close();
        }
    }
}
