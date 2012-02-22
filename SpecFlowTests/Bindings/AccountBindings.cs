using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestMaster.EasyBankRepository.DomainModel;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Bindings
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