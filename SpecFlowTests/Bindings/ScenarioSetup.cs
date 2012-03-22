using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.Gateways.Csv;
using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class ScenarioSetup
  {
    [BeforeScenario]
    public static void BeforeFeatures()
    {
      var fakeFileAccess = new FakeFileAccess();
      var fakePathProvider = new FakePathProvider
                               {
                                 PathToDataFile = @"c:\temp\file.xml",
                                 PathToExportFile = @"c:\temp\file.ynab",
                                 PathToImportFile = @"c:\temp\file.csv"
                               };

      CurrentScenarioContext.FakeFileAccess = fakeFileAccess;
      var mapper = new Mapper();

      CurrentScenarioContext.InitializeEasyBankContext(
        new EasyBankContext(
          new CsvAgent(new CsvGateway(fakeFileAccess, fakePathProvider.PathToImportFile), mapper),
          new YnabAgent(mapper, new YnabGateway(fakeFileAccess, fakePathProvider.PathToExportFile, CultureSettings.German())),
          new XmlAgent(mapper, new XmlGateway(fakeFileAccess, fakePathProvider.PathToDataFile)),
          fakeFileAccess,
          new FakePathProvider()));
    }
  }

  public class FakePathProvider : IDefaultPathProvider
  {
    public string PathToDataFile { get; set; }

    public string PathToExportFile { get; set; }

    public string PathToImportFile { get; set; }
  }
}