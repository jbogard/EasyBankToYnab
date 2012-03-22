using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  public class FakePathProvider : IDefaultPathProvider
  {
    public string PathToDataFile { get; set; }

    public string PathToExportFile { get; set; }

    public string PathToImportFile { get; set; }
  }
}