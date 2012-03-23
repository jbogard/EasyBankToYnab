using System;
using System.Windows;

namespace QuestMaster.EasyBankToYnab.UI
{
  /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ApplicationData applicationData;

        public App()
        {
            this.applicationData = new ApplicationData();
        }

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
          this.applicationData.DataContextProvider.SaveAndClose();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow
                             {
                                 ViewModel =
                                     new MainFormViewModel(this.applicationData.DataContextProvider,
                                                           this.applicationData.PathProvider)
                             };

            window.Show();
        }
    }
}