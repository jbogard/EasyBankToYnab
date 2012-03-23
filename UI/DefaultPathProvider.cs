using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.UI.Properties;

namespace QuestMaster.EasyBankToYnab.UI
{
    internal class PathProvider : IPathProvider
    {
        public string PathToXmlFile
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

        public string PathToYnabFile
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

        public string PathToCsvFile
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