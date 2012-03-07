using System;
using System.Linq;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.DomainTests.Bindings.Tables;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class GivenDefinitions
  {
    [Given(@"I have an account with number '([0-9]*)'")]
    public void GivenIHaveAnAccountWithNumber(string accountNumber)
    {
      CurrentScenarioContext.EasyBankContext.AddAcount(accountNumber);
    }

    [Given(@"the following entries in the account with number '([0-9]*)'")]
    public void GivenTheFollowingEntriesInThatAccount(string accountNumber, Table table)
    {
      GivenTheFollowingEntriesInThatAccount(accountNumber, new EntryTable(table));
    }

    public void GivenTheFollowingEntriesInThatAccount(string accountNumber, EntryTable entryTable)
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
        CurrentScenarioContext.EasyBankContext[accountNumber].AddEntry(entry);
      }
    }

    [Given(@"I have an empty list of accounts")]
    public void GivenIHaveAnEmptyListOfAccounts()
    {
      CurrentScenarioContext.EasyBankContext.RemoveAllAccounts();
    }
  }
}