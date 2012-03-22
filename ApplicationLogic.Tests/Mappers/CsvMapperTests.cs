using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers
{
  public class CsvMapperTests
  {
    private static ICsvMapper ConstructMapper()
    {
      return new CsvMapper();
    }

    [TestClass]
    public class ConfigurationTests
    {
      [TestMethod]
      public void ConfigurationShouldBeValid()
      {
        ConstructMapper();

        AutoMapper.Mapper.AssertConfigurationIsValid();
      }
    }

    [TestClass]
    public class MapDomainToYnab
    {
      private ICsvMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }
    }

    [TestClass]
    public class MapEasyBankToDomain
    {
      private ICsvMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapEntry()
      {
        var entry = new Gateways.Csv.CsvEntry("account;some description|some payee;01.01.2012;02.01.2012;-2;EUR");

        Entry domainEntry = this.mapper.MapToDomain(entry);

        Assert.AreEqual("account", domainEntry.Account);
        Assert.AreEqual(0m, domainEntry.AmountIn);
        Assert.AreEqual(2m, domainEntry.AmountOut);
        Assert.AreEqual(new DateTime(2012, 1, 1), domainEntry.BookingDate);
        Assert.AreEqual("EUR", domainEntry.Currency);
        Assert.AreEqual("some description", domainEntry.Description);
        Assert.AreEqual(true, domainEntry.IsNew);
        Assert.AreEqual("some payee", domainEntry.Payee);
        Assert.AreEqual(new DateTime(2012, 1, 2), domainEntry.ValueDate);
      }
    }
  }
}