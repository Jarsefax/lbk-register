using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LbkRegister.Data;
using LbkRegister.Domain;
using LbkRegister.ViewModels;

namespace LbkRegister.Views {
    public partial class ChangeGroup : Window {
        private readonly IEnumerable<Registration> _registrations;
        private readonly IEnumerable<CategoryViewModel> _items;
        private readonly Registration _registration;

        public ChangeGroup(Registration registration, IEnumerable<Registration> registrations) {
            InitializeComponent();

            _registrations = registrations;
            _registration = registration;
            _items = CategoryViewModel.GetList();

            listBox.ItemsSource = _items;
            listBox.SelectedItem = _items.Single(i => i.Category == _registration.Group);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            _registration.Group = (listBox.SelectedItem as CategoryViewModel).Category;
            Persistence.Save(_registrations);
            Close();
        }
    }
}
