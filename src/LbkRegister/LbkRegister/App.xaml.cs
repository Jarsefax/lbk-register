using System;
using System.Windows;

namespace LbkRegister {
    public partial class App : Application {
        public App() : base() {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show(e.Exception.Message + Environment.NewLine + e.Exception.StackTrace, "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
