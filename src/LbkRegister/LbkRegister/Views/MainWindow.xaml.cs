using System.Windows;
using System.Windows.Controls;
using LbkRegister.Data;
using LbkRegister.Domain;
using LbkRegister.ViewModels;
using static LbkRegister.Domain.CompetitionClass;

namespace LbkRegister.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            sixMonthsLabel.Text = Categories.SixMonths.ToName();
            nineMonthsLabel.Text = Categories.NineMonths.ToName();
            nineToFifteenMonthsLabel.Text = Categories.NineToFifteenMonths.ToName();
            fifteenToTwentyFourMonthsLabel.Text = Categories.FifteenToTwentyFourMonths.ToName();
            fifteenMonthsLabel.Text = Categories.FifteenMonths.ToName();
            eightYearsLabel.Text = Categories.EightYears.ToName();

            Persistence.Initialize();
            DataContext = new MainWindowViewModel();
        }

        /*
         
            Ras: Riesenschnauzer
            Namn enligt registreringsbevis: Kantbergets Amazing
            Registreringsnummer: 10236
            Kön: Tik, Valp 4-6 mån
            Födelsedatum: 2015-03-28
            Anmäler till: Tik, Valp 4-6 mån
            Fader: Kurt
            Moder: Elit
            Uppfödare: Berta
            Ägare: Lilith Sarapik
            Din gatuadress: Skogen
            Postnummer: 1
            Ort: Skogsdungen
            Ditt telefon nummer: 2
            Din epost: sarapik@telia.com
            Meddelande: Hej
            Testar om det fungerar :)

         */

        private void RegisterButton_Click(object sender, RoutedEventArgs e) {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText)) {
                var registration = new Registration(Clipboard.GetText(TextDataFormat.UnicodeText));
                var dialog = new NewRegistration((DataContext as MainWindowViewModel).Registrations) { DataContext = registration };
                dialog.ShowDialog();

                (DataContext as MainWindowViewModel).UpdateRegistrations();
            }
        }

        private void ChangeRegistrationButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new ChangeRegistration((sender as Button).DataContext as Registration, (DataContext as MainWindowViewModel).Registrations);
            dialog.ShowDialog();

            (DataContext as MainWindowViewModel).UpdateRegistrations();
        }

        private void GroupChangeButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new ChangeGroup((sender as Button).DataContext as Registration, (DataContext as MainWindowViewModel).Registrations);
            dialog.ShowDialog();

            (DataContext as MainWindowViewModel).UpdateRegistrations();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            (DataContext as MainWindowViewModel).DeleteRegistration((sender as Button).DataContext as Registration);
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
