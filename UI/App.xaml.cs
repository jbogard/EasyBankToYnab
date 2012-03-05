using System;
using System.Windows;
using QuestMaster.EasyBankToYnab.DomainModel;

namespace QuestMaster.EasyBankToYnab.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // TODO: move this into an application data class.
        private static readonly CultureSettings cultureSettings = CultureSettings.American();
        private static readonly DataContextProvider dataContextProvider = new DataContextProvider();
        private static readonly DefaultPathProvider defaultPathProvider = new DefaultPathProvider();

        public App()
        {
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            dataContextProvider.SaveAndClose();
        }

        internal static CultureSettings CultureSettings
        {
            get
            {
                return cultureSettings;
            }
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow()
            {
                ViewModel = new MainFormViewModel(dataContextProvider, defaultPathProvider)
            };

            window.Show();
        }
    }
}