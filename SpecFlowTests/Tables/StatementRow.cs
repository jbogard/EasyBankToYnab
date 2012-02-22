using System;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Tables
{
  public class StatementRow
  {
    private readonly TableRow row;

    public StatementRow(TableRow row)
    {
      this.row = row;
    }

    public int Id
    {
      get { return this.row.AsInt32("Id"); }
    }

    public string Statement
    {
      get { return this.row["Statement"]; }
    }
  }
}