using System;
using System.Linq;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.DomainTests.Tables;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  [Binding]
  public class StatementBindings
  {
    [Given(@"the following statements")]
    public void GivenTheFollowingStatements(Table table)
    {
      GivenTheFollowingStatements(new StatementTable(table));
    }

    public void GivenTheFollowingStatements(StatementTable table)
    {
      CurrentScenarioContext.Statements = table.Statements.ToDictionary(s => s.Id);
    }


    [When(@"I import statements")]
    public void WhenIImportStatements(Table table)
    {
      WhenIImportStatements(new StatementTable(table));
    }

    public void WhenIImportStatements(StatementTable statementsTable)
    {
      var statements = statementsTable.Statements.Select(s => s.Statement).ToList();

      EasyBankContext bankContext = CurrentScenarioContext.EasyBankContext;

      foreach (var statement in statements)
      {
        bankContext.ImportStatement(statement);
      }
    }

    [When(@"I import statement '(.*)'")]
    public void WhenIImportStatement(int statementId)
    {
      var statement = CurrentScenarioContext.Statements[statementId].Statement;
      CurrentScenarioContext.EasyBankContext.ImportStatement(statement);
    }
  }
}
