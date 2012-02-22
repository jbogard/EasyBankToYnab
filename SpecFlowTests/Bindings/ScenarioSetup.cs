using QuestMaster.EasyBankRepository.DomainModel;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Bindings
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