using System.Windows;
using System.Windows.Controls;
using LbkRegister.Data;
using LbkRegister.Dependencies;
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

            groupUnknownLabel.Text = CompetitionGroup.Groups.Unknown.ToName();
            groupOneLabel.Text = CompetitionGroup.Groups.One.ToName();
            groupTwoLabel.Text = CompetitionGroup.Groups.Two.ToName();
            groupThreeLabel.Text = CompetitionGroup.Groups.Three.ToName();
            groupFourLabel.Text = CompetitionGroup.Groups.Four.ToName();
            groupFiveLabel.Text = CompetitionGroup.Groups.Five.ToName();
            groupSixLabel.Text = CompetitionGroup.Groups.Six.ToName();
            groupSevenLabel.Text = CompetitionGroup.Groups.Seven.ToName();
            groupEightLabel.Text = CompetitionGroup.Groups.Eight.ToName();
            groupNineLabel.Text = CompetitionGroup.Groups.Nine.ToName();
            groupTenLabel.Text = CompetitionGroup.Groups.Ten.ToName();

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

            (DataContext as MainWindowViewModel).UpdateRegistrations();
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e) {
            new CatalogGenerator((DataContext as MainWindowViewModel).Registrations).Create();

            MessageBox.Show("Skapat katalog");
        }

        private void BisButton_Click(object sender, RoutedEventArgs e) {
            new CatalogGenerator((DataContext as MainWindowViewModel).SortedRegistrations).CreateBIS();

            MessageBox.Show("Skapat BIS-fil");
        }
    }
}
