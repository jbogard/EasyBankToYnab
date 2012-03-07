using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.EasyBank;
using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContext
  {
    private readonly IEasyBankGateway statementImporter;
    private readonly IYnabGateway ynabExporter;
    private readonly IMapper mapper;
    private readonly IXmlGateway xmlGateway;
    private readonly List<Account> accounts = new List<Account>();

    public EasyBankContext(IEasyBankGateway statementImporter, IYnabGateway ynabExporter, IMapper mapper, IXmlGateway xmlGateway)
    {
      this.statementImporter = statementImporter;
      this.ynabExporter = ynabExporter;
      this.mapper = mapper;
      this.xmlGateway = xmlGateway;
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
      return this.accounts.Where(a => a.Number == accountNumber);
    }

    public void AddAcount(string accountNumber)
    {
      this.accounts.Add(new Account(this.ynabExporter, this.mapper, accountNumber));
    }

    //public void ImportStatement(string statement)
    //{
    //  this.AddEntry(this.statementImporter.Import(statement));
    //}

    //public void ImportStatements(IEnumerable<string> statements)
    //{
    //  foreach (var statement in statements)
    //  {
    //    this.ImportStatement(statement);
    //  }
    //}


    //public void Save()
    //{
    //  if (!File.Exists(path))
    //  {
    //    throw new ArgumentException("Path must exist", "path");
    //  }

    //  BackupCurrentFile(path);

    //  EasyBank dto = this.Convert(this);

    //  this.Write(dto);
    //}
  }
}