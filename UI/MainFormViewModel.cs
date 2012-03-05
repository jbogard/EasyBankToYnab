using QuestMaster.EasyBankRepository.ApplicationLogic;
using QuestMaster.EasyBankRepository.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using QuestMaster.EasyBankRepository.UI.Foundation;

namespace QuestMaster.EasyBankRepository.UI
{

    public class MainFormViewModel : NotifyPropertyChanged
    {
        private readonly IDataContextProvider dataContextProvider;

        private readonly IDefaultPathProvider defaultPathProvider;

        private EasyBankContext easyBank;
        public event EventHandler Exit;
        private readonly SimpleCommand exitCommand;
        private readonly SimpleCommand exportCommand;
        private readonly SimpleCommand exportNowCommand;
        private readonly SimpleCommand importCommand;
        private readonly SimpleCommand importNowCommand;
        private readonly SimpleCommand markAllAsOldCommand;
        private readonly SimpleCommand openCommand;

        private readonly IFileServices fileServices = new FileServices();

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

        private Tuple<string, bool> ViewModelPathToDatabaseRequested(string fileName)
        {
            return this.fileServices.LookForFile(fileName, "SDF Files (*.sdf)|*.sdf", Mode.Open);
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
            if (obj is Account)
            {
                var account = (Account) obj;

                using (StreamWriter writer = new StreamWriter(this.defaultPathProvider.PathToExportFile))
            {
                writer.Write(account.ExportNewEntries());
            }
            }
        }

        private void DoImport(object obj)
        {
            IEnumerable<string> readLines = FileServices.ReadLines(this.defaultPathProvider.PathToImportFile);

            foreach (var line in readLines)
            {
            this.easyBank.ImportStatement(line);
                
            }
            OnPropertyChanged(() => this.Accounts);
        }

        private void DoMarkAllAsAold(object obj)
        {
            if (obj is Account)
            {
                var account = (Account) obj;

                foreach (var entry in account.Entries)
                {
                    entry.IsNew = false;
                }
            this.easyBank.SubmitChanges();
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

        public void LoadDataContextFromDefaultPath()
        {
            this.dataContextProvider.LoadDataContext(this.defaultPathProvider.PathToDataFile);
            this.easyBank = this.dataContextProvider.DataContext;
            OnPropertyChanged(() => this.Accounts);
        }

        private Tuple<string, bool> ViewModelPathToExportFileRequested(string fileName)
        {
            return this.fileServices.LookForFile(fileName, "CSV Files (*.csv)|*.csv", Mode.Save);
        }

        private Tuple<string, bool> ViewModelPathToImportFileRequested(string fileName)
        {
            return this.fileServices.LookForFile(fileName, "CSV Files (*.csv)|*.csv", Mode.Open);
        }

        private void RequestExit(object obj)
        {
            this.Exit.Raise(this, EventArgs.Empty);
        }

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
    }
}

