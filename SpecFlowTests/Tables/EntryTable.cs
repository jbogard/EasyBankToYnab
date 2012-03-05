using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Tables
{
  public class EntryTable
  {
    private readonly Table table;

    public EntryTable(Table table)
    {
      this.table = table;
    }

    public IEnumerable<EntryRow> Entries
    {
      get { return this.table.Rows.Select(row => new EntryRow(row)); }
    }

    public IEnumerable<string> Header
    {
      get { return table.Header; }
    }

    public int RowCount
    {
      get { return table.RowCount; }
    }
  }
}