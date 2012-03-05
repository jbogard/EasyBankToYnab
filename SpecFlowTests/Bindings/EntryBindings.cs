using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestMaster.EasyBankToYnab.DomainModel;
using QuestMaster.EasyBankToYnab.DomainTests.Tables;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class EntryBindings
  {
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

    [Given(@"these expected entries")]
    public void GivenTheseExpectedEntries(Table table)
    {
      GivenTheseExpectedEntries(new EntryTable(table));
    }

    public void GivenTheseExpectedEntries(EntryTable table)
    {
      CurrentScenarioContext.ExpectedEntries = table.Entries.ToDictionary(e => e.Id);
    }

    [Given(@"the following entries in that account")]
    public void GivenTheFollowingEntriesInThatAccount(Table table)
    {
      GivenTheFollowingEntriesInThatAccount(new EntryTable(table));
    }

    public void GivenTheFollowingEntriesInThatAccount(EntryTable entryTable)
    {
      var entries = entryTable.Entries.Select(
        e => 
          new Entry
            {
              Account = e.Account,
              AmountIn = e.AmountIn,
              AmountOut = e.AmountOut,
              BookingDate = e.BookingDate,
              Currency = e.Currency,
              Description = e.Description,
              IsNew = e.IsNew,
              Payee = e.Payee,
              ValueDate = e.ValueDate
            })
          .ToArray();

      foreach (var entry in entries)
      {
        CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].AddEntry(entry);
      }
    }

    [Then(@"the resulting entries should be")]
    public void ThenTheResultingEntriesShouldBe(Table table)
    {
      ThenTheResultingEntriesShouldBe(new EntryTable(table));
    }

    public void ThenTheResultingEntriesShouldBe(EntryTable entryTable)
    {
      var rows = entryTable.Entries.ToArray();
      var importedEntries =
        CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].Entries.ToArray();
      for (int i = 0; i < rows.Length; i++)
      {
        AssertEntry(rows[i], importedEntries[i + 1]);
      }
    }

    [Then(@"the resulting entries in that account should be")]
    public void ThenTheResultingEntriesInThatAccountShouldBe(Table table)
    {
      ThenTheResultingEntriesInThatAccountShouldBe(new EntryTable(table));
    }

    public void ThenTheResultingEntriesInThatAccountShouldBe(EntryTable entryTable)
    {
      var rows = entryTable.Entries.ToArray();
      var importedEntries =
        CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].Entries.ToArray();
      for (int i = 0; i < rows.Length; i++)
      {
        AssertEntry(rows[i], importedEntries[i + 1]);
      }
    }
    
    [Then(@"that account should contain entry '(.*)'")]
    public void ThenThatAccountShouldContainEntry(int entryId)
    {
      EntryRow expected = CurrentScenarioContext.ExpectedEntries[entryId];
      Entry actual = CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].Entries.First();

      AssertEntry(expected, actual);
    }

    [When(@"I export all entries")]
    public void WhenIExportAllEntries()
    {
      CurrentScenarioContext.ResultOfExport = CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].ExportAllEntries();
    }

    [When(@"I export all new entries")]
    public void WhenIExportAllNewEntries()
    {
      CurrentScenarioContext.ResultOfExport = CurrentScenarioContext.EasyBankContext[CurrentScenarioContext.CurrentAccountNumber].ExportNewEntries();
    }

    [Then(@"the resulting string should be")]
    public void ThenTheResultingStringShouldBe(Table table)
    {
      this.ThenTheResultingStringShouldBe(new LineTable(table));
    }

    public void ThenTheResultingStringShouldBe(LineTable table)
    {
      var lines = string.Join(Environment.NewLine, table.Lines.Select(l => l.Line));

      string diff = CalculateDiff(lines, CurrentScenarioContext.ResultOfExport);

      Assert.AreEqual(
        lines,
        CurrentScenarioContext.ResultOfExport,
        diff);
    }

    private string CalculateDiff(string firstString, string secondString)
    {
      string result = string.Empty;

      if (firstString.Length != secondString.Length)
      {
        result += string.Format("Lengths differ: {0} vs. {1}", firstString.Length, secondString.Length);
      }

      for (int i = 0; i < Math.Min(firstString.Length, secondString.Length); i++)
      {
        if (firstString[i] == secondString[i])
        {
          continue;
        }

        result += firstString.Substring(i) + " vs. " + secondString.Substring(i);
      }

      return result;
    }
  }
}
