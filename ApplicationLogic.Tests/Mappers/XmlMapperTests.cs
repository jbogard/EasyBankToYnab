using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers
{
  public class XmlMapperTests
  {
    private static XmlMapper ConstructMapper()
    {
      return new XmlMapper();
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
    public class MapToDomainTests
    {
      private XmlMapper mapper;

      [TestInitialize]
      public void Setup()
      {
        this.mapper = ConstructMapper();
      }

      [TestMethod]
      public void MapXmlEntryToDomainEntry()
      {
        var xmlEntry = new Gateways.Xml.XmlEntry
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

        Entry domainEntry = mapper.MapToDomain(xmlEntry);

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
        var xmlEntry1 = new Gateways.Xml.XmlEntry
                          {
                            Account = "account number 1",
                          };

        var xmlEntry2 = new Gateways.Xml.XmlEntry
                          {
                            Account = "account number 2",
                          };

        var xmlCollection = new Gateways.Xml.XmlEntryCollection
                              {
                                xmlEntry1,
                                xmlEntry2
                              };

        EntryCollection domainCollection = this.mapper.MapToDomain(xmlCollection);

        Assert.AreEqual(2, domainCollection.Count);
        Assert.AreEqual("account number 1", domainCollection[0].Account);
        Assert.AreEqual("account number 2", domainCollection[1].Account);
      }

      //[TestMethod]
      //public void MapAccount()
      //{
      //  var domainAccount = new Gateways.Xml.XmlAccount
      //                        {
      //                          Number = "account number",
      //                          xmlEntries = new Gateways.Xml.CsvEntryCollection
      //                                      {
      //                                        new Gateways.Xml.CsvEntry { XmlAccount = "account number", Description = "description 1" },
      //                                        new Gateways.Xml.CsvEntry { XmlAccount = "account number", Description = "description 2" },
      //                                      }
      //                        };

      //  XmlAccount xmlAccount = this.mapper.MapToDomain(domainAccount);

      //  Assert.AreEqual("account number", xmlAccount.Number);
      //  Assert.AreEqual(2, xmlAccount.xmlEntries.Count());
      //  Assert.AreEqual("description 1", xmlAccount.xmlEntries.First().Description);
      //  Assert.AreEqual("description 2", xmlAccount.xmlEntries.Skip(1).First().Description);
      //}

      //[TestMethod]
      //public void MapAccountCollection()
      //{
      //  var xmlEntry1 = new Gateways.Xml.XmlAccount
      //  {
      //    Number = "account number 1",
      //    xmlEntries = new Gateways.Xml.CsvEntryCollection()
      //  };

      //  var xmlEntry2 = new Gateways.Xml.XmlAccount
      //  {
      //    Number = "account number 2",
      //    xmlEntries = new Gateways.Xml.CsvEntryCollection()
      //  };

      //  var xmlCollection = new Gateways.Xml.XmlAccountCollection
      //                     {
      //                       xmlEntry1,
      //                       xmlEntry2
      //                     };

      //  XmlAccountCollection domainCollection = this.mapper.MapToDomain(xmlCollection);

      //  Assert.AreEqual(2, domainCollection.Count);
      //  Assert.AreEqual("account number 1", domainCollection[0].Number);
      //  Assert.AreEqual("account number 2", domainCollection[1].Number);
      //}

      //[TestMethod]
      //public void MapEasyBankContext()
      //{
      //  var xmlEasyBank = new Gateways.Xml.XmlEasyBank
      //                         {
      //                           xmlAccounts = new Gateways.Xml.XmlAccountCollection
      //                                        {
      //                                          new Gateways.Xml.XmlAccount { Number = "account number 1", xmlEntries = new Gateways.Xml.CsvEntryCollection { new Gateways.Xml.CsvEntry { XmlAccount = "account number 1" } } },
      //                                          new Gateways.Xml.XmlAccount { Number = "account number 2", xmlEntries = new Gateways.Xml.CsvEntryCollection { new Gateways.Xml.CsvEntry { XmlAccount = "account number 2" } } }
      //                                        }
      //                         };

      //  EasyBankContext domainEasyBank = this.mapper.MapToDomain(xmlEasyBank);

      //  Assert.AreEqual(2, domainEasyBank.xmlAccounts.Count());
      //  Assert.AreEqual("account number 1", domainEasyBank.xmlAccounts.First().Number);
      //  Assert.AreEqual("account number 2", domainEasyBank.xmlAccounts.Skip(1).First().Number);
      //}
    }

    [TestClass]
    public class MapToXmlTests
    {
      private XmlMapper mapper;

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

        Gateways.Xml.XmlEntry xmlEntry = mapper.MapToXml(domainEntry);

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

        Gateways.Xml.XmlEntryCollection xmlCollection = this.mapper.MapToXml(collection);

        Assert.AreEqual(2, xmlCollection.Count);
        Assert.AreEqual("account number 1", xmlCollection[0].Account);
        Assert.AreEqual("account number 2", xmlCollection[1].Account);
      }

      //[TestMethod]
      //public void MapAccount()
      //{
      //  var domainAccount = new XmlAccount("account number");
      //  domainAccount.AddEntry(new CsvEntry { XmlAccount = "account number", Description = "description 1" });
      //  domainAccount.AddEntry(new CsvEntry { XmlAccount = "account number", Description = "description 2" });

      //  Gateways.Xml.XmlAccount xmlAccount = this.mapper.MapToXml(domainAccount);

      //  Assert.AreEqual("account number", xmlAccount.Number);
      //  Assert.AreEqual(2, xmlAccount.xmlEntries.Count);
      //  Assert.AreEqual("description 1", xmlAccount.xmlEntries[0].Description);
      //  Assert.AreEqual("description 2", xmlAccount.xmlEntries[1].Description);
      //}

      //[TestMethod]
      //public void MapAccountCollection()
      //{
      //  var domainAccounts = new XmlAccountCollection
      //                         {
      //                           new XmlAccount("account number 1"),
      //                           new XmlAccount("account number 2")
      //                         };

      //  Gateways.Xml.XmlAccountCollection xmlAccounts = this.mapper.MapToXml(domainAccounts);

      //  Assert.AreEqual(2, xmlAccounts.Count);
      //  Assert.AreEqual("account number 1", xmlAccounts[0].Number);
      //  Assert.AreEqual("account number 2", xmlAccounts[1].Number);
      //}

      //[TestMethod]
      //public void MapEasyBankContext()
      //{
      //  var domainEasyBank = new EasyBankContext(
      //    new Mock<Gateways.XmlEasyBank.ICsvGateway>().Object,
      //    new Mock<Gateways.Ynab.IYnabGateway>().Object,
      //    new Mock<Gateways.Xml.IXmlGateway>().Object,
      //    new Mock<IMapper>().Object,
      //    new Mock<IFileAccess>().Object,
      //    new Mock<IDefaultPathProvider>().Object);

      //  domainEasyBank.AddAcount("account number 1");
      //  domainEasyBank.AddAcount("account number 2");

      //  Gateways.Xml.XmlEasyBank xmlEasyBank = this.mapper.MapToXml(domainEasyBank);

      //  Assert.AreEqual(2, xmlEasyBank.xmlAccounts.Count);
      //  Assert.AreEqual("account number 1", xmlEasyBank.xmlAccounts[0].Number);
      //  Assert.AreEqual("account number 2", xmlEasyBank.xmlAccounts[1].Number);
      //}
    }
  }
}