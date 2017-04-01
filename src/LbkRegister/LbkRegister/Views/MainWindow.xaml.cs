using System.Windows;
using LbkRegister.Data;
using LbkRegister.Domain;
using LbkRegister.ViewModels;

namespace LbkRegister.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

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

        private void CatalogButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}
