using System;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Tables
{
  internal static class TableExtensions
  {
    public static int AsInt32(this TableRow row, string header)
    {
      return Int32.Parse(row[header]);
    }

    public static DateTime AsDateTime(this TableRow tableRow, string header)
    {
      return Convert.ToDateTime(tableRow[header]);
    }

    public static Decimal AsDecimal(this TableRow tableRow, string header)
    {
      return Convert.ToDecimal(tableRow[header]);
    }

    public static Boolean AsBoolean(this TableRow tableRow, string header)
    {
      return Convert.ToBoolean(tableRow[header]);
    }
  }
}