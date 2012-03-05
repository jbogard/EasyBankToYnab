using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.DomainModel
{
  public class EntryExporter : IEntryExporter
  {
    private readonly CultureSettings cultureSettings;

    public EntryExporter(CultureSettings cultureSettings)
    {
      this.cultureSettings = cultureSettings;
    }

    public string ExportEntries(IEnumerable<Entry> entries)
    {
      var stringBuilder = this.GetHeaderLine();

      var lines = string.Join(Environment.NewLine, entries.Select(ToYnab).ToArray());

      return stringBuilder + Environment.NewLine + lines;
    }

    private string GetHeaderLine()
    {
      var result = string.Format(this.cultureSettings.CultureInfo, "Date{0}Category{0}Payee{0}Memo{0}Outflow{0}Inflow", new object[] { this.cultureSettings.Separator });
      return result;
    }

    private string ReplaceSeparator(string s)
    {
      return s.Replace(cultureSettings.Separator, cultureSettings.ReplacementForSeparator);
    }

    private string ToYnab(Entry entry)
    {
      var result = string.Format(
        cultureSettings.CultureInfo,
        "{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
        new object[]
          {
            cultureSettings.Separator,
            entry.ValueDate.ToString(cultureSettings.DateTimeFormatString, cultureSettings.CultureInfo),
            "Import Statements",
            ReplaceSeparator(entry.Payee),
            ReplaceSeparator(entry.Description),
            entry.AmountOut.ToString("0.00"),
            entry.AmountIn.ToString("0.00")
          });

      return result;
    }
  }
}