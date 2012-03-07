using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Account
  {
    private readonly List<Entry> entries;
    private readonly IYnabGateway ynabExporter;
    private readonly IMapper mapper;
    private readonly string number;

    public Account(IYnabGateway ynabExporter, IMapper mapper, string number)
    {
      this.ynabExporter = ynabExporter;
      this.mapper = mapper;
      this.number = number;
      this.entries = new List<Entry>();
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

    public string ExportNewEntries()
    {
      return ExportTheseEntries(this.Entries.Where(e => e.IsNew));
    }

    private string ExportTheseEntries(IEnumerable<Entry> selection)
    {
      return this.ynabExporter.ExportEntries(selection.Select(mapper.Map<Entry, Gateways.Ynab.Entry>));
    }

    public string ExportAllEntries()
    {
      return this.ExportTheseEntries(this.Entries);
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