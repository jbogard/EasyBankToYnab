using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Tables
{
  public class LineTable
  {
    private readonly Table mTable;

    public LineTable(Table table)
    {
      mTable = table;
    }

    public int RowCount
    {
      get { return mTable.RowCount; }
    }

    public IEnumerable<string> Header
    {
      get { return mTable.Header; }
    }

    public IEnumerable<LineRow> Lines
    {
      get { return this.mTable.Rows.Select(row => new LineRow(row)); }
    }
  }
}