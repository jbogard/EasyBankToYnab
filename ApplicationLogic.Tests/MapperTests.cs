using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class MapperTests
  {
    private static IMapper ConstructMapper()
    {
      return new Mapper();
    }

    [TestClass]
    public class MapDomainToXmlTests
    {
      private IMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapEntry()
      {
        var domainEntry = new Entry
                            {
                              Account = "account number",
                              AmountIn = 1m,
                              AmountOut = 2m,
                              BookingDate = new DateTime(2012, 1, 1),
                              Currency = "EUR",
                              Description = "my description",
                              IsNew = true,
                              Payee = "the payee",
                              ValueDate = new DateTime(2012, 1, 16)
                            };

        Gateways.Xml.Entry xmlEntry = mapper.MapDomainToXml(domainEntry);

        Assert.AreEqual("account number", xmlEntry.Account);
        Assert.AreEqual(1m, xmlEntry.AmountIn);
        Assert.AreEqual(2m, xmlEntry.AmountOut);
        Assert.AreEqual(new DateTime(2012, 1, 1), xmlEntry.BookingDate);
        Assert.AreEqual("EUR", xmlEntry.Currency);
        Assert.AreEqual("my description", xmlEntry.Description);
        Assert.AreEqual(true, xmlEntry.IsNew);
        Assert.AreEqual("the payee", xmlEntry.Payee);
        Assert.AreEqual(new DateTime(2012, 1, 16), xmlEntry.ValueDate);
      }

      [TestMethod]
      public void MapEntryCollection()
      {
        var domainEntry1 = new Entry
        {
          Account = "account number 1",
        };

        var domainEntry2 = new Entry
        {
          Account = "account number 2",
        };

        var collection = new EntryCollection
                           {
                             domainEntry1,
                             domainEntry2
                           };

        Gateways.Xml.EntryCollection xmlCollection = this.mapper.MapDomainToXml(collection);

        Assert.AreEqual(2, xmlCollection.Count);
        Assert.AreEqual("account number 1", xmlCollection[0].Account);
        Assert.AreEqual("account number 2", xmlCollection[1].Account);
      }
    }

    [TestClass]
    public class MapXmlToDomainTests
    {
      private IMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapXmlEntryToDomainEntry()
      {
        var mapper = new Mapper();

        var xmlEntry = new Gateways.Xml.Entry
                         {
                           Account = "account number",
                           AmountIn = 1m,
                           AmountOut = 2m,
                           BookingDate = new DateTime(2012, 1, 1),
                           Currency = "EUR",
                           Description = "my description",
                           IsNew = true,
                           Payee = "the payee",
                           ValueDate = new DateTime(2012, 1, 16)
                         };

        Entry domainEntry = mapper.MapXmlToDomain(xmlEntry);

        Assert.AreEqual("account number", domainEntry.Account);
        Assert.AreEqual(1m, domainEntry.AmountIn);
        Assert.AreEqual(2m, domainEntry.AmountOut);
        Assert.AreEqual(new DateTime(2012, 1, 1), domainEntry.BookingDate);
        Assert.AreEqual("EUR", domainEntry.Currency);
        Assert.AreEqual("my description", domainEntry.Description);
        Assert.AreEqual(true, domainEntry.IsNew);
        Assert.AreEqual("the payee", domainEntry.Payee);
        Assert.AreEqual(new DateTime(2012, 1, 16), domainEntry.ValueDate);
      }

      [TestMethod]
      public void MapEntryCollection()
      {
        var xmlEntry1 = new Gateways.Xml.Entry
        {
          Account = "account number 1",
        };

        var xmlEntry2 = new Gateways.Xml.Entry
        {
          Account = "account number 2",
        };

        var xmlCollection = new Gateways.Xml.EntryCollection
                           {
                             xmlEntry1,
                             xmlEntry2
                           };

        EntryCollection domainCollection = this.mapper.MapXmlToDomain(xmlCollection);

        Assert.AreEqual(2, domainCollection.Count);
        Assert.AreEqual("account number 1", domainCollection[0].Account);
        Assert.AreEqual("account number 2", domainCollection[1].Account);
      }
    }
  }
}