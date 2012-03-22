using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class MapperTests
  {
    private static IMapper ConstructMapper()
    {
      return new Mapper();
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

        Gateways.Xml.Entry xmlEntry = mapper.MapToXml(domainEntry);

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

        Gateways.Xml.EntryCollection xmlCollection = this.mapper.MapToXml(collection);

        Assert.AreEqual(2, xmlCollection.Count);
        Assert.AreEqual("account number 1", xmlCollection[0].Account);
        Assert.AreEqual("account number 2", xmlCollection[1].Account);
      }

      //[TestMethod]
      //public void MapAccount()
      //{
      //  var domainAccount = new Account("account number");
      //  domainAccount.AddEntry(new CsvEntry { Account = "account number", Description = "description 1" });
      //  domainAccount.AddEntry(new CsvEntry { Account = "account number", Description = "description 2" });

      //  Gateways.Xml.Account xmlAccount = this.mapper.MapToXml(domainAccount);

      //  Assert.AreEqual("account number", xmlAccount.Number);
      //  Assert.AreEqual(2, xmlAccount.Entries.Count);
      //  Assert.AreEqual("description 1", xmlAccount.Entries[0].Description);
      //  Assert.AreEqual("description 2", xmlAccount.Entries[1].Description);
      //}

      //[TestMethod]
      //public void MapAccountCollection()
      //{
      //  var domainAccounts = new AccountCollection
      //                         {
      //                           new Account("account number 1"),
      //                           new Account("account number 2")
      //                         };

      //  Gateways.Xml.AccountCollection xmlAccounts = this.mapper.MapToXml(domainAccounts);

      //  Assert.AreEqual(2, xmlAccounts.Count);
      //  Assert.AreEqual("account number 1", xmlAccounts[0].Number);
      //  Assert.AreEqual("account number 2", xmlAccounts[1].Number);
      //}

      //[TestMethod]
      //public void MapEasyBankContext()
      //{
      //  var domainEasyBank = new EasyBankContext(
      //    new Mock<Gateways.EasyBank.ICsvGateway>().Object,
      //    new Mock<Gateways.Ynab.IYnabGateway>().Object,
      //    new Mock<Gateways.Xml.IXmlGateway>().Object,
      //    new Mock<IMapper>().Object,
      //    new Mock<IFileAccess>().Object,
      //    new Mock<IDefaultPathProvider>().Object);

      //  domainEasyBank.AddAcount("account number 1");
      //  domainEasyBank.AddAcount("account number 2");

      //  Gateways.Xml.EasyBank xmlEasyBank = this.mapper.MapToXml(domainEasyBank);

      //  Assert.AreEqual(2, xmlEasyBank.Accounts.Count);
      //  Assert.AreEqual("account number 1", xmlEasyBank.Accounts[0].Number);
      //  Assert.AreEqual("account number 2", xmlEasyBank.Accounts[1].Number);
      //}
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

        EntryCollection domainCollection = this.mapper.MapToDomain(xmlCollection);

        Assert.AreEqual(2, domainCollection.Count);
        Assert.AreEqual("account number 1", domainCollection[0].Account);
        Assert.AreEqual("account number 2", domainCollection[1].Account);
      }

      //[TestMethod]
      //public void MapAccount()
      //{
      //  var domainAccount = new Gateways.Xml.Account
      //                        {
      //                          Number = "account number",
      //                          Entries = new Gateways.Xml.CsvEntryCollection
      //                                      {
      //                                        new Gateways.Xml.CsvEntry { Account = "account number", Description = "description 1" },
      //                                        new Gateways.Xml.CsvEntry { Account = "account number", Description = "description 2" },
      //                                      }
      //                        };

      //  Account xmlAccount = this.mapper.MapToDomain(domainAccount);

      //  Assert.AreEqual("account number", xmlAccount.Number);
      //  Assert.AreEqual(2, xmlAccount.Entries.Count());
      //  Assert.AreEqual("description 1", xmlAccount.Entries.First().Description);
      //  Assert.AreEqual("description 2", xmlAccount.Entries.Skip(1).First().Description);
      //}

      //[TestMethod]
      //public void MapAccountCollection()
      //{
      //  var xmlEntry1 = new Gateways.Xml.Account
      //  {
      //    Number = "account number 1",
      //    Entries = new Gateways.Xml.CsvEntryCollection()
      //  };

      //  var xmlEntry2 = new Gateways.Xml.Account
      //  {
      //    Number = "account number 2",
      //    Entries = new Gateways.Xml.CsvEntryCollection()
      //  };

      //  var xmlCollection = new Gateways.Xml.AccountCollection
      //                     {
      //                       xmlEntry1,
      //                       xmlEntry2
      //                     };

      //  AccountCollection domainCollection = this.mapper.MapToDomain(xmlCollection);

      //  Assert.AreEqual(2, domainCollection.Count);
      //  Assert.AreEqual("account number 1", domainCollection[0].Number);
      //  Assert.AreEqual("account number 2", domainCollection[1].Number);
      //}
      
      //[TestMethod]
      //public void MapEasyBankContext()
      //{
      //  var xmlEasyBank = new Gateways.Xml.EasyBank
      //                         {
      //                           Accounts = new Gateways.Xml.AccountCollection
      //                                        {
      //                                          new Gateways.Xml.Account { Number = "account number 1", Entries = new Gateways.Xml.CsvEntryCollection { new Gateways.Xml.CsvEntry { Account = "account number 1" } } },
      //                                          new Gateways.Xml.Account { Number = "account number 2", Entries = new Gateways.Xml.CsvEntryCollection { new Gateways.Xml.CsvEntry { Account = "account number 2" } } }
      //                                        }
      //                         };

      //  EasyBankContext domainEasyBank = this.mapper.MapToDomain(xmlEasyBank);

      //  Assert.AreEqual(2, domainEasyBank.Accounts.Count());
      //  Assert.AreEqual("account number 1", domainEasyBank.Accounts.First().Number);
      //  Assert.AreEqual("account number 2", domainEasyBank.Accounts.Skip(1).First().Number);
      //}
    }

    [TestClass]
    public class MapDomainToYnab
    {
      private IMapper mapper;

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

    [TestClass]
    public class MapEasyBankToDomain
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