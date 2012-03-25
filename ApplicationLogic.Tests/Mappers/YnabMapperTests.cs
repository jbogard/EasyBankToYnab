using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers
{
  public class YnabMapperTests
  {
    private static YnabMapper ConstructMapper()
    {
      return new YnabMapper();
    }

    [TestClass]
    public class ConstructorTests
    {
      [TestMethod]
      public void ConfigurationShouldBeValid()
      {
        ConstructMapper();

        AutoMapper.Mapper.AssertConfigurationIsValid();
      }
    }

    [TestClass]
    public class MapToYnabTests
    {
      private YnabMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapDomainEntryToYnabEntry()
      {
        var domainEntry = new Entry(
          amountIn: 1m,
          amountOut: 2m,
          description: "some description",
          payee: "some payee",
          valueDate: new DateTime(2012, 1, 1),
          account: "some account",
          bookingDate: new DateTime(2012, 1, 2),
          currency: "EUR");

        Gateways.Ynab.YnabEntry ynabYnabEntry = this.mapper.MapToYnab(domainEntry);

        Assert.AreEqual(1m, ynabYnabEntry.AmountIn);
        Assert.AreEqual(2m, ynabYnabEntry.AmountOut);
        Assert.AreEqual("some description", ynabYnabEntry.Description);
        Assert.AreEqual("some payee", ynabYnabEntry.Payee);
        Assert.AreEqual(new DateTime(2012, 1, 1), ynabYnabEntry.ValueDate);
      }

      [TestMethod]
      public void MapDomainEntrySequenceToYnabEntryCollection()
      {
        var domainEntry1 = new Entry(
          amountIn: 1m,
          amountOut: 2m,
          description: "some description",
          payee: "some payee",
          valueDate: new DateTime(2012, 1, 1),
          account: "some account",
          bookingDate: new DateTime(2012, 1, 2),
          currency: "EUR");

        var domainEntry2 = new Entry(
          amountIn: 3m,
          amountOut: 4m,
          description: "some other description",
          payee: "some other payee",
          valueDate: new DateTime(2012, 1, 3),
          account: "some other account",
          bookingDate: new DateTime(2012, 1, 4),
          currency: "USD");

        Gateways.Ynab.YnabEntryCollection ynabEntries = this.mapper.MapToYnab(new[] { domainEntry1, domainEntry2 });

        Assert.IsNotNull(ynabEntries);
      }
    }
  }
}