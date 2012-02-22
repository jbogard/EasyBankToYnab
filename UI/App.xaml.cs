using System.Windows;
using System;
using QuestMaster.EasyBankRepository.Domain.EasyBankRepository;
using QuestMaster.EasyBankRepository.DomainModel;

namespace QuestMaster.EasyBankRepository.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static readonly CultureSettings cultureSettings = CultureSettings.American();
        private static readonly DataContextProvider dataContextProvider = new DataContextProvider();
        private static readonly DefaultPathProvider defaultPathProvider = new DefaultPathProvider();

        public App()
        {
            base.Exit += new ExitEventHandler(App.ApplicationExit);
        }


        private static void ApplicationExit(object sender, ExitEventArgs e)
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


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow()
            {
                ViewModel = new MainFormViewModel(dataContextProvider, defaultPathProvider)
            };

            window.Show();

        }
    }
}