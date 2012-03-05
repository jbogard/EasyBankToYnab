using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
    public interface IDefaultPathProvider
    {
        string PathToDataFile { get; set; }

        string PathToExportFile { get; set; }

        string PathToImportFile { get; set; }
    }
}