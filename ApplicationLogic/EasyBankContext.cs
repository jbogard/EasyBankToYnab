using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContext
  {
    private readonly ICsvAgent statementImporter;
    private readonly IYnabAgent ynabExporter;
    private readonly IXmlAgent xmlAgent;
    private readonly AccountCollection accounts = new AccountCollection();
    private readonly IFileAccess fileAccess;
    private readonly IPathProvider pathProvider;

    public EasyBankContext(
      ICsvAgent statementImporter,
      IYnabAgent ynabExporter,
      IXmlAgent xmlAgent, 
      IFileAccess fileAccess, 
      IPathProvider pathProvider)
    {
      if (statementImporter == null) throw new ArgumentNullException("statementImporter");
      if (ynabExporter == null) throw new ArgumentNullException("ynabExporter");
      if (xmlAgent == null) throw new ArgumentNullException("xmlAgent");
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");

      this.statementImporter = statementImporter;
      this.ynabExporter = ynabExporter;
      this.xmlAgent = xmlAgent;
      this.fileAccess = fileAccess;
      this.pathProvider = pathProvider;
    }

    public Account this[string accountNumber]
    {
      get { return this.SelectMatchingAccounts(accountNumber).SingleOrDefault(); }
    }

    public ObservableCollection<Account> Accounts
    {
      get { return this.accounts; }
    }

    public void AddEntry(Entry entry)
    {
      string accountNumber = entry.Account;
      if (!this.HasAccount(accountNumber))
      {
        this.AddAcount(accountNumber, string.Empty);
      }

      this[accountNumber].AddEntry(entry);
    }

    public bool HasAccount(string accountNumber)
    {
      return SelectMatchingAccounts(accountNumber).Any();
    }

    public void AddAcount(string accountNumber, string description)
    {
      this.accounts.Add(new Account(accountNumber, description));
    }

    public void Save()
    {
      if(System.IO.File.Exists(this.pathProvider.PathToXmlFile))
      {
        this.fileAccess.BackupFile(this.pathProvider.PathToXmlFile, "Backup");
      }

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

    public void ExportEntries(string accountNumber, bool newOnly)
    {
      IEnumerable<Entry> entries = this.accounts.Where(acc => acc.Number == accountNumber).SelectMany(acc => acc.Entries);

      if (newOnly)
      {
        entries = entries.Where(entry => entry.IsNew);
      }

      this.ynabExporter.Write(entries);
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