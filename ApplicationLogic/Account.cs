using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Account
  {
    private readonly EntryCollection entries;
    private readonly string number;

    public Account(string number)
      : this(number, new Entry[0])
    {
    }

    public Account(string number, IEnumerable<Entry> entries)
    {
      this.number = number;
      this.entries = new EntryCollection();

      foreach (var entry in entries)
      {
        this.AddEntry(entry);
      }
    }

    public string Number
    {
      get { return number; }
    }

    public ObservableCollection<Entry> Entries
    {
      get { return this.entries; }
    }

    public void AddEntry(Entry entry)
    {
      if (!this.entries.Contains(entry))
      {
        this.entries.Add(entry);
      }
    }

    public void MarkStatementsAsOld()
    {
      foreach (var entry in Entries)
      {
        entry.IsNew = false;
      }
    }
  }
}