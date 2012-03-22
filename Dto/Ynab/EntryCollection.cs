using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class EntryCollection
  {
    private readonly Entry[] entries;

    public EntryCollection(Entry[] entries)
    {
      if (entries == null) throw new ArgumentNullException("entries");

      this.entries = entries;
    }

    private string GetHeaderLine(CultureSettings cultureSettings)
    {
      var result = string.Format(cultureSettings.CultureInfo, "Date{0}Category{0}Payee{0}Memo{0}Outflow{0}Inflow", new object[] { cultureSettings.Separator });
      return result;
    }

    internal IEnumerable<string> ToYnabStrings(CultureSettings cultureSettings)
    {
      return new[] { GetHeaderLine(cultureSettings) }.Concat(this.entries.Select(entry => entry.ToYnabString(cultureSettings)));
    }
  }
}