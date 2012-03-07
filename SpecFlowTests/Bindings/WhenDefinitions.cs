using System;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class WhenDefinitions
  {
    [When(@"I export all entries")]
    public void WhenIExportAllEntries()
    {
      CurrentScenarioContext.EasyBankContext.ExportEntries(newOnly: false);
    }

    [When(@"I import these statements")]
    public void WhenIImportTheseStatements(string multilineText)
    {
      CurrentScenarioContext.FakeFileAccess.ReadLinesResult = Helpers.SplitLines(multilineText);
      CurrentScenarioContext.EasyBankContext.ImportEntries();
    }

    [When(@"I export all new entries")]
    public void WhenIExportAllNewEntries()
    {
      CurrentScenarioContext.EasyBankContext.ExportEntries(newOnly: true);
    }
  }
}