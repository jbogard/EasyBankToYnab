using System;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Tables
{
  public class EntryRow
  {
    private readonly TableRow row;

    public EntryRow(TableRow row)
    {
      this.row = row;
    }

    public int Id
    {
      get { return this.row.AsInt32("Id"); }
    }

    public string Account
    {
      get { return this.row["Account"]; }
    }

    public DateTime BookingDate
    {
      get { return this.row.AsDateTime("Booking Date"); }
    }

    public DateTime ValueDate
    {
      get { return this.row.AsDateTime("Value Date"); }
    }

    public string Description
    {
      get { return this.row["Description"]; }
    }

    public string Payee
    {
      get { return this.row["Payee"]; }
    }

    public decimal AmountIn
    {
      get { return this.row.AsDecimal("Amount In"); }
    }

    public decimal AmountOut
    {
      get { return this.row.AsDecimal("Amount Out"); }
    }

    public string Currency
    {
      get { return this.row["Currency"]; }
    }

    public bool IsNew
    {
      get { return this.row.AsBoolean("Is New"); }
    }
  }
}