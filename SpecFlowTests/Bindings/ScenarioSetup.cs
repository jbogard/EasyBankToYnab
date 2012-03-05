using System;
using QuestMaster.EasyBankToYnab.DomainModel;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class ScenarioSetup
  {
    [BeforeScenario]
    public static void BeforeFeatures()
    {
      CurrentScenarioContext.InitializeEasyBankContext(new EasyBankContext(new StatementImporter(), new EntryExporter(CultureSettings.American())));
    }
  }
}