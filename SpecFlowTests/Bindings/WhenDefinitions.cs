using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class WhenDefinitions
  {
    [When(@"I export all entries from the account with number '(.*)'")]
    public void WhenIExportAllEntries(string accountNumber)
    {
        CurrentScenarioContext.EasyBankContext.ExportEntries(accountNumber, newOnly: false);
    }

    [When(@"I import these statements")]
    public void WhenIImportTheseStatements(string multilineText)
    {
      CurrentScenarioContext.FakeFileAccess.ReadLinesResult = Helpers.SplitLines(multilineText);
      CurrentScenarioContext.EasyBankContext.ImportEntries();
    }

    [When(@"I export all new entries from the account with number '(.*)'")]
    public void WhenIExportAllNewEntries(string accountNumber)
    {
        CurrentScenarioContext.EasyBankContext.ExportEntries(accountNumber, newOnly: true);
    }
  }
}