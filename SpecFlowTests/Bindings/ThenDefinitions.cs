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
        AssertEntry(expectedRows[i], actualEntries[i], i);
      }
    }

    private static void AssertEntry(EntryRow expected, Entry actual, int index)
    {
      Assert.AreEqual(expected.Account, actual.Account, "Row {0} Account", index);
      Assert.AreEqual(expected.BookingDate, actual.BookingDate, "Row {0} BookingDate", index);
      Assert.AreEqual(expected.Description, actual.Description, "Row {0} Description", index);
      Assert.AreEqual(expected.Payee, actual.Payee, "Row {0} Payee", index);
      Assert.AreEqual(expected.ValueDate, actual.ValueDate, "Row {0} Value Date", index);
      Assert.AreEqual(expected.AmountIn, actual.AmountIn, "Row {0} Amount In", index);
      Assert.AreEqual(expected.AmountOut, actual.AmountOut, "Row {0} Amount Out", index);
      Assert.AreEqual(expected.Currency, actual.Currency, "Row {0} Currency", index);
      Assert.AreEqual(expected.IsNew, actual.IsNew, "Row {0} Is New", index);
    }
  }
}