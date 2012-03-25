using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Agents;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers;
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
                                 PathToXmlFile = @"c:\temp\file.xml",
                                 PathToYnabFile = @"c:\temp\file.ynab",
                                 PathToCsvFile = @"c:\temp\file.csv"
                               };

      CurrentScenarioContext.FakeFileAccess = fakeFileAccess;

      CurrentScenarioContext.InitializeEasyBankContext(
        new EasyBankContext(
          new CsvAgent(new CsvGateway(fakeFileAccess, fakePathProvider), new CsvMapper()),
          new YnabAgent(new YnabGateway(fakeFileAccess, fakePathProvider, CultureSettings.American()), new YnabMapper()),
          new XmlAgent(new XmlGateway(fakeFileAccess, fakePathProvider), new XmlMapper()),
          fakeFileAccess,
          new FakePathProvider()));
    }
  }
}