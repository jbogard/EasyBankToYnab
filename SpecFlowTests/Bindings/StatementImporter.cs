﻿using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using QuestMaster.EasyBankRepository.DomainModel;

namespace QuestMaster.EasyBankRepository.DomainTests.Bindings
{
  public class StatementImporter : IStatementImporter
  {
    private readonly Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
    private static readonly CultureInfo cultureInfo = new CultureInfo("de-DE");

    private const int AccountIndex = 0;
    private const int DescriptionIndex = 1;
    private const int BookingDateIndex = 2;
    private const int ValueDateIndex = 3;
    private const int AmountIndex = 4;
    private const int CurrencyIndex = 5;

    public Entry Import(string statement)
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

      return new Entry
               {
                 Account = account,
                 Description = description,
                 Payee = payee,
                 BookingDate = DateTime.ParseExact(parts[BookingDateIndex], "dd.MM.yyyy", CultureInfo.CurrentCulture),
                 ValueDate = DateTime.ParseExact(parts[ValueDateIndex], "dd.MM.yyyy", CultureInfo.CurrentCulture),
                 AmountIn = Math.Max(0, amount),
                 AmountOut = Math.Abs(Math.Min(0, amount)),
                 Currency = parts[CurrencyIndex],
                 IsNew = true
               };
    }

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