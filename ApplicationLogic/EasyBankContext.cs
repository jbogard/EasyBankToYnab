using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContext
  {
    private readonly ICsvAgent statementImporter;
    private readonly IYnabGateway ynabExporter;
    private readonly IMapper mapper;
    private readonly IXmlAgent xmlAgent;
    private readonly AccountCollection accounts = new AccountCollection();
    private readonly IFileAccess fileAccess;
    private readonly IDefaultPathProvider pathProvider;

    public EasyBankContext(
      ICsvAgent statementImporter,
      IYnabGateway ynabExporter,
      IXmlAgent xmlAgent,
      IMapper mapper,
      IFileAccess fileAccess,
      IDefaultPathProvider pathProvider)
      : this(statementImporter, ynabExporter, xmlAgent, mapper, fileAccess, pathProvider, new Entry[0])
    {
    }

    public EasyBankContext(
      ICsvAgent statementImporter,
      IYnabGateway ynabExporter,
      IXmlAgent xmlAgent, 
      IMapper mapper, 
      IFileAccess fileAccess, 
      IDefaultPathProvider pathProvider,
      IEnumerable<Entry> entries)
    {
      if (statementImporter == null) throw new ArgumentNullException("statementImporter");
      if (ynabExporter == null) throw new ArgumentNullException("ynabExporter");
      if (xmlAgent == null) throw new ArgumentNullException("xmlAgent");
      if (mapper == null) throw new ArgumentNullException("mapper");
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");

      this.statementImporter = statementImporter;
      this.ynabExporter = ynabExporter;
      this.mapper = mapper;
      this.xmlAgent = xmlAgent;
      this.fileAccess = fileAccess;
      this.pathProvider = pathProvider;

      foreach (var entry in entries)
      {
        this.AddEntry(entry);
      }
    }

    public Account this[string accountNumber]
    {
      get { return this.SelectMatchingAccounts(accountNumber).SingleOrDefault(); }
    }

    public IEnumerable<Account> Accounts
    {
      get { return this.accounts; }
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

    public void AddAcount(string accountNumber)
    {
      this.accounts.Add(new Account(accountNumber));
    }

    public void Save()
    {
      this.fileAccess.BackupFile(this.pathProvider.PathToDataFile, "Backup");

      this.xmlAgent.Write(this);
    }

    public void Load()
    {
      var entries = this.xmlAgent.Read();

      foreach (var entry in entries)
      {
        this.AddEntry(entry);
      }
    }

    public void RemoveAllAccounts()
    {
      this.accounts.Clear();
    }

    public void ExportEntries(bool newOnly)
    {
      IEnumerable<Entry> entries = this.accounts.SelectMany(acc => acc.Entries);

      if (newOnly)
      {
        entries = entries.Where(entry => entry.IsNew);
      }

      this.ynabExporter.Write(this.mapper.MapToYnab(entries.ToArray()));
    }

    public void ImportEntries()
    {
      var entries = this.statementImporter.Read();

      foreach (var entry in entries)
      {
        this.AddEntry(entry);
      }
    }

    private IEnumerable<Account> SelectMatchingAccounts(string accountNumber)
    {
      return this.accounts.Where(a => a.Number == accountNumber);
    }
  }
}