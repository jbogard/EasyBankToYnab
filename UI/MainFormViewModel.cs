using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.UI.Foundation;

namespace QuestMaster.EasyBankToYnab.UI
{
    public class MainFormViewModel : NotifyPropertyChanged
    {
        private readonly IDataContextProvider dataContextProvider;

        private readonly IDefaultPathProvider defaultPathProvider;

        private EasyBankContext easyBank;
        private readonly SimpleCommand exitCommand;
        private readonly SimpleCommand exportCommand;
        private readonly SimpleCommand exportNowCommand;
        private readonly SimpleCommand importCommand;
        private readonly SimpleCommand importNowCommand;
        private readonly SimpleCommand markAllAsOldCommand;
        private readonly SimpleCommand openCommand;

        private readonly IFileLookupService fileLookupService = new FileLookupService();

        public MainFormViewModel(IDataContextProvider dataContextProvider, IDefaultPathProvider defaultPathProvider)
        {
            this.dataContextProvider = dataContextProvider;
            this.defaultPathProvider = defaultPathProvider;
            this.easyBank = dataContextProvider.DataContext;
            this.importNowCommand = new SimpleCommand(this.DoImport);
            this.importCommand = new SimpleCommand(this.AskFileAndImport);
            this.exportNowCommand = new SimpleCommand(this.DoExport);
            this.exportCommand = new SimpleCommand(this.AskFileAndExport);
            this.openCommand = new SimpleCommand(this.DoOpen);
            this.exitCommand = new SimpleCommand(this.RequestExit);
            this.markAllAsOldCommand = new SimpleCommand(this.DoMarkAllAsAold);
        }

        public event EventHandler Exit;

        public IEnumerable<Account> Accounts
        {
            get
            {
                return this.easyBank != null ? (IEnumerable<Account>)this.easyBank: new Account[0];
            }
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
            this.dataContextProvider.LoadDataContext(this.defaultPathProvider.PathToDataFile);
            this.easyBank = this.dataContextProvider.DataContext;
            OnPropertyChanged(() => this.Accounts);
        }

        private Tuple<string, bool> ViewModelPathToDatabaseRequested(string fileName)
        {
            return this.fileLookupService.LookForFile(fileName, "SDF Files (*.sdf)|*.sdf", Mode.Open);
        }

        private void AskFileAndExport(object obj)
        {
            Tuple<string, bool> couple = this.ViewModelPathToExportFileRequested(this.defaultPathProvider.PathToExportFile);
            if (couple.Item2)
            {
                this.defaultPathProvider.PathToExportFile = couple.Item1;
                this.DoExport(obj);
            }
        }

        private void AskFileAndImport(object obj)
        {
            Tuple<string, bool> couple = this.ViewModelPathToImportFileRequested(this.defaultPathProvider.PathToImportFile);
            if (couple.Item2)
            {
                this.defaultPathProvider.PathToImportFile = couple.Item1;
                this.DoImport(obj);
            }
        }

        private void DoExport(object obj)
        {
            var account = obj as Account;
            if (account != null)
            {
                ExportStatementsToFile(account);
            }
        }

        private void ExportStatementsToFile(Account account)
        {
            throw new NotImplementedException();
            //using (StreamWriter writer = new StreamWriter(this.defaultPathProvider.PathToExportFile))
            //{
            //    writer.Write(account.ExportNewEntries());
            //}
        }

        private void DoImport(object obj)
        {
            ImportStatementsFromFile();

            OnPropertyChanged(() => this.Accounts);
        }

        private void ImportStatementsFromFile()
        {
            throw new NotImplementedException();
            //// todo: pull out

            //IEnumerable<string> readLines = FileHelpers.ReadLines(this.defaultPathProvider.PathToImportFile);

            //this.XmlEasyBank.ImportStatements(readLines);
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
            Tuple<string, bool> couple = this.ViewModelPathToDatabaseRequested(this.defaultPathProvider.PathToDataFile);
            if (couple.Item2)
            {
                this.defaultPathProvider.PathToDataFile = couple.Item1;
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

