using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class YnabMapperTests
  {
    private static IYnabMapper ConstructMapper()
    {
      return new YnabMapper();
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
      private IYnabMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapDomainEntryToYnabEntry()
      {
        var domainEntry = new Entry
        {
          AmountIn = 1m,
          AmountOut = 2m,
          Description = "some description",
          Payee = "some payee",
          ValueDate = new DateTime(2012, 1, 1)
        };

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
        var domainEntry1 = new Entry
        {
          Description = "some description",
        };
        var domainEntry2 = new Entry
        {
          Description = "some description",
        };

        Gateways.Ynab.YnabEntryCollection ynabEntries = this.mapper.MapToYnab(new[] { domainEntry1, domainEntry2 });

        Assert.IsNotNull(ynabEntries);
      }
    }
  }
}