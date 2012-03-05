using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class AccountBindings
  {
    [Given(@"I have an empty list of accounts")]
    public void GivenIHaveAnEmptyListOfAccounts()
    {
      CurrentScenarioContext.EasyBankContext.Clear();
    }

    [Given(@"I have an account with number '(.*)'")]
    public void GivenIHaveAnAccountWithNumber(string accountNumber)
    {
      CurrentScenarioContext.EasyBankContext.AddAcount(accountNumber);
      CurrentScenarioContext.CurrentAccountNumber = accountNumber;
    }
    
    [Then(@"the list of accounts should contain '(.*)'")]
    public void ThenTheListOfAccountsShouldContain(string account)
    {
      Assert.IsTrue(CurrentScenarioContext.EasyBankContext.HasAccount(account));
    }
  }
}