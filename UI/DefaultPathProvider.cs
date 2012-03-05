using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.UI.Properties;

namespace QuestMaster.EasyBankToYnab.UI
{
    internal class DefaultPathProvider : IDefaultPathProvider
    {
        public string PathToDataFile
        {
            get
            {
                return Settings.Default.PathToDataFile;
            }
            set
            {
                Settings.Default.PathToDataFile = value;
                Settings.Default.Save();
            }
        }

        public string PathToExportFile
        {
            get
            {
                return Settings.Default.PathToExportFile;
            }
            set
            {
                Settings.Default.PathToExportFile = value;
                Settings.Default.Save();
            }
        }

        public string PathToImportFile
        {
            get
            {
                return Settings.Default.PathToImportFile;
            }
            set
            {
                Settings.Default.PathToImportFile = value;
                Settings.Default.Save();
            }
        }
    }
}