using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class EntryCollection
  {
    private readonly CultureSettings cultureSettings;
    private readonly Entry[] entries;

    public EntryCollection(CultureSettings cultureSettings, Entry[] entries)
    {
      if (cultureSettings == null) throw new ArgumentNullException("cultureSettings");
      if (entries == null) throw new ArgumentNullException("entries");

      this.cultureSettings = cultureSettings;
      this.entries = entries;
    }

    private string GetHeaderLine()
    {
      var result = string.Format(this.cultureSettings.CultureInfo, "Date{0}Category{0}Payee{0}Memo{0}Outflow{0}Inflow", new object[] { this.cultureSettings.Separator });
      return result;
    }

    internal IEnumerable<string> ToYnabStrings()
    {
      return new[] { GetHeaderLine() }.Concat(this.entries.Select(entry => entry.ToYnabString()));
    }
  }
}