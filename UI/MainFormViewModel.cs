using System;
using System.Collections.Generic;
using System.Windows.Input;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.UI
{
    public class MainFormViewModel : NotifyPropertyChanged
    {
        private readonly IDataContextProvider dataContextProvider;

        private readonly IPathProvider pathProvider;

        private EasyBankContext easyBank { get { return this.dataContextProvider.DataContext; } }
        private readonly SimpleCommand exitCommand;
        private readonly SimpleCommand exportCommand;
        private readonly SimpleCommand exportNowCommand;
        private readonly SimpleCommand importCommand;
        private readonly SimpleCommand importNowCommand;
        private readonly SimpleCommand markAllAsOldCommand;
        private readonly SimpleCommand openCommand;

        private readonly IFileLookupService fileLookupService = new FileLookupService();
        private readonly SimpleCommand saveAsCommand;
        private readonly SimpleCommand saveCommand;

      public MainFormViewModel(IDataContextProvider dataContextProvider, IPathProvider pathProvider)
        {
            this.dataContextProvider = dataContextProvider;
            this.pathProvider = pathProvider;
            this.importNowCommand = new SimpleCommand(this.DoImport);
            this.importCommand = new SimpleCommand(this.AskFileAndImport);
            this.exportNowCommand = new SimpleCommand(this.DoExport);
            this.exportCommand = new SimpleCommand(this.AskFileAndExport);
            this.openCommand = new SimpleCommand(this.DoOpen);
            this.exitCommand = new SimpleCommand(this.RequestExit);
            this.markAllAsOldCommand = new SimpleCommand(this.DoMarkAllAsAold);
            this.saveCommand = new SimpleCommand(this.DoSave);
            this.saveAsCommand = new SimpleCommand(this.DoSaveAs);
        }

      private void DoSave(object obj)
      {
        this.easyBank.Save();
      }

      private void DoSaveAs(object obj)
      {
        var lookForFile = this.fileLookupService.LookForFile(this.pathProvider.PathToXmlFile, "*.xml|*.xml", Mode.Save);

        if(lookForFile.Item2)
        {
          this.pathProvider.PathToXmlFile = lookForFile.Item1;
          this.easyBank.Save();
        }
      }

      public event EventHandler Exit;

        public IEnumerable<Account> Accounts
        {
            get
            {
                return this.easyBank != null ? this.easyBank.Accounts: new Account[0];
            }
        }

        public ICommand SaveAsCommand
        {
          get { return this.saveAsCommand; }
        }

        public ICommand SaveCommand
        {
          get { return this.saveCommand; }
        }

        public ICommand ExitCommand
        {
            get
            {
                return this.exitCommand;
            }
        }

        public ICommand Export
        {
            get
            {
                return this.exportCommand;
            }
        }

        public ICommand ExportNow
        {
            get
            {
                return this.exportNowCommand;
            }
        }

        public ICommand Import
        {
            get
            {
                return this.importCommand;
            }
        }

        public ICommand ImportNow
        {
            get
            {
                return this.importNowCommand;
            }
        }

        public ICommand MarkAllAsOld
        {
            get
            {
                return this.markAllAsOldCommand;
            }
        }

        public ICommand Open
        {
            get
            {
                return this.openCommand;
            }
        }

        public void LoadDataContextFromDefaultPath()
        {
            this.dataContextProvider.LoadDataContext();
            OnPropertyChanged(() => this.Accounts);
        }

        private Tuple<string, bool> ViewModelPathToDatabaseRequested(string fileName)
        {
          return this.fileLookupService.LookForFile(fileName, "*.xml|*.xml", Mode.Open);
        }

        private void AskFileAndExport(object obj)
        {
            Tuple<string, bool> couple = this.ViewModelPathToExportFileRequested(this.pathProvider.PathToYnabFile);
            if (couple.Item2)
            {
                this.pathProvider.PathToYnabFile = couple.Item1;
                this.DoExport(obj);
            }
        }

        private void AskFileAndImport(object obj)
        {
            Tuple<string, bool> couple = this.ViewModelPathToImportFileRequested(this.pathProvider.PathToCsvFile);
            if (couple.Item2)
            {
                this.pathProvider.PathToCsvFile = couple.Item1;
                this.DoImport(obj);
            }
        }

        private void DoExport(object obj)
        {
            var account = obj as Account;
            if (account != null)
            {
                ExportStatementsToFile();
            }
        }

        private void ExportStatementsToFile()
        {
          this.easyBank.ExportEntries(true);
        }

        private void DoImport(object obj)
        {
            ImportStatementsFromFile();

            OnPropertyChanged(() => this.Accounts);
        }

        private void ImportStatementsFromFile()
        {
          this.easyBank.ImportEntries();
        }

        private void DoMarkAllAsAold(object obj)
        {
            var account = obj as Account;

            if (account != null)
            {
                account.MarkStatementsAsOld();

                OnPropertyChanged(() => this.Accounts);
            }
        }

        private void DoOpen(object obj)
        {
            Tuple<string, bool> couple = this.ViewModelPathToDatabaseRequested(this.pathProvider.PathToXmlFile);
            if (couple.Item2)
            {
                this.pathProvider.PathToXmlFile = couple.Item1;
                LoadDataContextFromDefaultPath();
            }
        }

        private Tuple<string, bool> ViewModelPathToExportFileRequested(string fileName)
        {
            return this.fileLookupService.LookForFile(fileName, "CSV Files (*.csv)|*.csv", Mode.Save);
        }

        private Tuple<string, bool> ViewModelPathToImportFileRequested(string fileName)
        {
            return this.fileLookupService.LookForFile(fileName, "CSV Files (*.csv)|*.csv", Mode.Open);
        }

        private void RequestExit(object obj)
        {
            this.Exit.Raise(this, EventArgs.Empty);
        }
    }
}

