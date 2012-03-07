using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuestMaster.EasyBankToYnab.Gateways.EasyBank
{
  public class Entry
  {
    private readonly Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
    private static readonly CultureInfo cultureInfo = new CultureInfo("de-DE");

    private const int AccountIndex = 0;
    private const int DescriptionIndex = 1;
    private const int BookingDateIndex = 2;
    private const int ValueDateIndex = 3;
    private const int AmountIndex = 4;
    private const int CurrencyIndex = 5;
    
    public Entry(string statement)
    {
      string[] parts = statement.Split(';');
      var amount = decimal.Parse(parts[AmountIndex], cultureInfo);

      string description = RetrieveDescription(parts);
      string payee = RetrievePayee(parts);
      string account = parts[AccountIndex];

      if (IsCreditCardAccount(account))
      {
        var t = description;
        description = payee;
        payee = t;
      }

      this.Account = account;
      this.Description = description;
      this.Payee = payee;
      this.BookingDate = DateTime.ParseExact(parts[BookingDateIndex], "dd.MM.yyyy", CultureInfo.CurrentCulture);
      this.ValueDate = DateTime.ParseExact(parts[ValueDateIndex], "dd.MM.yyyy", CultureInfo.CurrentCulture);
      this.AmountIn = Math.Max(0, amount);
      this.AmountOut = Math.Abs(Math.Min(0, amount));
      this.Currency = parts[CurrencyIndex];
    }

    public string Currency { get; set; }

    public decimal AmountOut { get; set; }

    public decimal AmountIn { get; set; }

    public DateTime ValueDate { get; set; }

    public DateTime BookingDate { get; set; }

    public string Payee { get; set; }

    public string Description { get; set; }

    protected string Account { get; set; }

    private static bool IsCreditCardAccount(string account)
    {
      return account.StartsWith("2000");
    }

    private string RetrieveDescription(string[] parts)
    {
      var descriptionParts = RetrieveDescriptionParts(parts);

      string result = descriptionParts[0];
      return result;
    }

    private string RetrievePayee(string[] parts)
    {
      var descriptionParts = RetrieveDescriptionParts(parts);

      string payee = string.Join(" ", descriptionParts.Skip(1).ToArray());
      return payee;
    }

    private string[] RetrieveDescriptionParts(string[] parts)
    {
      var description = parts[DescriptionIndex];
      description = regex.Replace(description, @" ");

      string[] descriptionParts = description.Split('#');
      return descriptionParts;
    }
  }
}