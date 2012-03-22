using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class YnabEntryCollection
  {
    private readonly YnabEntry[] ynabEntries;

    public YnabEntryCollection(YnabEntry[] ynabEntries)
    {
      if (ynabEntries == null) throw new ArgumentNullException("ynabEntries");

      this.ynabEntries = ynabEntries;
    }

    private string GetHeaderLine(CultureSettings cultureSettings)
    {
      var result = string.Format(cultureSettings.CultureInfo, "Date{0}Category{0}Payee{0}Memo{0}Outflow{0}Inflow", new object[] { cultureSettings.Separator });
      return result;
    }

    internal IEnumerable<string> ToYnabStrings(CultureSettings cultureSettings)
    {
      return new[] { GetHeaderLine(cultureSettings) }.Concat(this.ynabEntries.Select(entry => entry.ToYnabString(cultureSettings)));
    }
  }
}