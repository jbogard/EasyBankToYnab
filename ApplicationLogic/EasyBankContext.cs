using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContext
  {
    private readonly Gateways.EasyBank.IEasyBankGateway statementImporter;
    private readonly Gateways.Ynab.IYnabGateway ynabExporter;
    private readonly IMapper mapper;
    private readonly Gateways.Xml.IXmlGateway xmlGateway;
    private readonly List<Account> accounts = new List<Account>();

    public EasyBankContext(
      Gateways.EasyBank.IEasyBankGateway statementImporter,
      Gateways.Ynab.IYnabGateway ynabExporter,
      Gateways.Xml.IXmlGateway xmlGateway,
      IMapper mapper)
    {
      if (statementImporter == null) throw new ArgumentNullException("statementImporter");
      if (ynabExporter == null) throw new ArgumentNullException("ynabExporter");
      if (xmlGateway == null) throw new ArgumentNullException("xmlGateway");
      if (mapper == null) throw new ArgumentNullException("mapper");

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

      this.ynabExporter.Write(this.mapper.Map<Entry[], Gateways.Ynab.EntryCollection>(entries.ToArray()));
    }

    public void ImportEntries()
    {
      Gateways.EasyBank.EntryCollection entryCollection = this.statementImporter.Read();

      Entry[] entries = this.mapper.Map<Gateways.EasyBank.EntryCollection, Entry[]>(entryCollection);

      foreach (var entry in entries)
      {
        this.AddEntry(entry);
      }
    }
  }
}