using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankRepository.DomainModel
{
  public class Account
  {
    private readonly List<Entry> entries;
    private readonly IEntryExporter entryExporter;
    private readonly string number;

    public Account(IEntryExporter entryExporter, string number)
    {
      this.entryExporter = entryExporter;
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
      return this.entryExporter.ExportEntries(selection);
    }

    public string ExportAllEntries()
    {
      return this.ExportTheseEntries(this.Entries);
    }
  }
}