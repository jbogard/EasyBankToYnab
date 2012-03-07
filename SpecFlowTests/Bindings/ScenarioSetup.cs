using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class ScenarioSetup
  {
    [BeforeScenario]
    public static void BeforeFeatures()
    {
      CurrentScenarioContext.InitializeEasyBankContext(new EasyBankContext(new StatementImporter(), new YnabExporter(CultureSettings.American()), new Mapper()));
    }
  }
}