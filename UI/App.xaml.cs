using System;
using System.Windows;
using QuestMaster.EasyBankToYnab.ApplicationLogic;

namespace QuestMaster.EasyBankToYnab.UI
{
    internal class ApplicationData
    {
        private readonly FileGateway fileGateway = new FileGateway(new Mapper());
        private readonly DataContextProvider dataContextProvider;
        private readonly DefaultPathProvider defaultPathProvider = new DefaultPathProvider();

        public ApplicationData()
        {
            this.dataContextProvider = new DataContextProvider(this.fileGateway);
        }

        public DataContextProvider DataContextProvider
        {
            get { return this.dataContextProvider; }
        }

        public IDefaultPathProvider DefaultPathProvider
        {
            get { return defaultPathProvider; }
        }
    }

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
                                                           this.applicationData.DefaultPathProvider)
                             };

            window.Show();
        }
    }
}