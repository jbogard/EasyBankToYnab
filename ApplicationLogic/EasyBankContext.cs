using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContext : List<Account>
  {
    private readonly IStatementImporter statementImporter;
    private readonly IYnabExporter ynabExporter;
    private readonly IMapper mapper;

    public EasyBankContext(IStatementImporter statementImporter, IYnabExporter ynabExporter, IMapper mapper)
    {
      this.statementImporter = statementImporter;
      this.ynabExporter = ynabExporter;
      this.mapper = mapper;
    }

    public Account this[string accountNumber]
    {
      get { return this.SelectMatchingAccounts(accountNumber).SingleOrDefault(); }
    }

    public void AddEntry(Entry entry)
    {
      string accountNumber = entry.Account;
      if (!this.HasAccount(accountNumber))
      {
        this.AddAcount(accountNumber);
      }

      this[accountNumber].AddEntry(entry);
    }

    public bool HasAccount(string accountNumber)
    {
      return SelectMatchingAccounts(accountNumber).Any();
    }

    private IEnumerable<Account> SelectMatchingAccounts(string accountNumber)
    {
      return this.Where(a => a.Number == accountNumber);
    }

    public void AddAcount(string accountNumber)
    {
      this.Add(new Account(this.ynabExporter, this.mapper, accountNumber));
    }

    public void ImportStatement(string statement)
    {
      this.AddEntry(this.statementImporter.Import(statement));
    }

    public void ImportStatements(IEnumerable<string> statements)
    {
      foreach (var statement in statements)
      {
        this.ImportStatement(statement);
      }
    }
  }
}