using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Account
  {
    private readonly EntryCollection entries;
    private readonly IYnabGateway ynabExporter;
    private readonly IMapper mapper;
    private readonly string number;

    public Account(IYnabGateway ynabExporter, IMapper mapper, string number)
    {
      this.ynabExporter = ynabExporter;
      this.mapper = mapper;
      this.number = number;
      this.entries = new EntryCollection();
    }

    public string Number
    {
      get { return number; }
    }

    public IEnumerable<Entry> Entries
    {
      get { return this.entries; }
    }

    public void AddEntry(Entry entry)
    {
      this.entries.Add(entry);
    }

    public void ExportNewEntries()
    {
      ExportTheseEntries(this.Entries.Where(e => e.IsNew));
    }

    private void ExportTheseEntries(IEnumerable<Entry> selection)
    {
      this.ynabExporter.Write(new Gateways.Ynab.EntryCollection(null, selection.Select(mapper.Map<Entry, Gateways.Ynab.Entry>).ToArray()));
    }

    public void ExportAllEntries()
    {
      this.ExportTheseEntries(this.Entries);
    }

      public void MarkStatementsOfAccountAsOld()
      {
          foreach (var entry in Entries)
          {
              entry.IsNew = false;
          }
      }
  }
}