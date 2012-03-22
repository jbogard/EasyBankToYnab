using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class YnabEntry
  {
    public string Payee { get; set; }

    public string Description { get; set; }

    public decimal AmountOut { get; set; }

    public decimal AmountIn { get; set; }

    public DateTime ValueDate { get; set; }

    internal string ToYnabString(CultureSettings cultureSettings)
    {
      var result = string.Format(
        cultureSettings.CultureInfo,
        "{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
        new object[]
          {
            cultureSettings.Separator,
            this.ValueDate.ToString(cultureSettings.DateTimeFormatString, cultureSettings.CultureInfo),
            "Import Statements",
            ReplaceSeparator(this.Payee, cultureSettings),
            ReplaceSeparator(this.Description, cultureSettings),
            this.AmountOut.ToString("0.00"),
            this.AmountIn.ToString("0.00")
          });

      return result;
    }

    private string ReplaceSeparator(string s, CultureSettings cultureSettings)
    {
      return s.Replace(cultureSettings.Separator, cultureSettings.ReplacementForSeparator);
    }
  }
}