using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways.EasyBank;
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
      CurrentScenarioContext.FakeFileAccess = fakeFileAccess;
      CurrentScenarioContext.InitializeEasyBankContext(
        new EasyBankContext(
          new EasyBankGateway(fakeFileAccess, "c:\temp\test.txt"),
          new YnabGateway(fakeFileAccess, "c:\temp\test.txt"),
          new XmlGateway(fakeFileAccess, "c:\temp\test.txt"),
          new Mapper()));
    }
  }
}