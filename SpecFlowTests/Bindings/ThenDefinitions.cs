using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.DomainTests.Bindings.Tables;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class ThenDefinitions
  {
    [Then(@"the list of accounts should contain '([0-9]*)'")]
    public void ThenTheListOfAccountsShouldContain(string accountNumber)
    {
      Assert.IsTrue(CurrentScenarioContext.EasyBankContext.HasAccount(accountNumber));
    }

    [Then(@"the result should be")]
    public void ThenTheResultShouldBe(string multilineText)
    {
      string[] expectedLines = Helpers.SplitLines(multilineText);
      string[] actualLines = CurrentScenarioContext.FakeFileAccess.LinesWritten;

      CollectionAssert.AreEqual(
        expectedLines.ToList(),
        actualLines.ToList());
    }

    [Then(@"the account with number '([0-9]*)' should contain these entries")]
    public void ThenTheAccountWithNumberShouldContainTheseEntries(string accountNumber, Table expectedEntries)
    {
      this.ThenTheAccountWithNumberShouldContainTheseEntries(accountNumber, new EntryTable(expectedEntries));
    }

    public void ThenTheAccountWithNumberShouldContainTheseEntries(string accountNumber, EntryTable expectedEntries)
    {
      EntryRow[] expectedRows = expectedEntries.Entries.ToArray();
      Entry[] actualEntries = CurrentScenarioContext.EasyBankContext[accountNumber].Entries.ToArray();

      Assert.AreEqual(expectedRows.Length, actualEntries.Length);

      for (int i = 0; i < expectedRows.Length; i++)
      {
        AssertEntry(expectedRows[i], actualEntries[i + 1]);
      }
    }

    private static void AssertEntry(EntryRow expected, Entry actual)
    {
      Assert.AreEqual(expected.Account, actual.Account, "Account");
      Assert.AreEqual(expected.BookingDate, actual.BookingDate, "BookingDate");
      Assert.AreEqual(expected.Description, actual.Description, "Description");
      Assert.AreEqual(expected.Payee, actual.Payee, "Payee");
      Assert.AreEqual(expected.ValueDate, actual.ValueDate, "Value Date");
      Assert.AreEqual(expected.AmountIn, actual.AmountIn, "Amount In");
      Assert.AreEqual(expected.AmountOut, actual.AmountOut, "Amount Out");
      Assert.AreEqual(expected.Currency, actual.Currency, "Currency");
      Assert.AreEqual(expected.IsNew, actual.IsNew, "Is New");
    }
  }
}