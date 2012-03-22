using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
//using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Mapper : IMapper, IXmlMapper, IYnabMapper, IEasyBankMapper
  {
    public Mapper()
    {
      // Xml mapping
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Xml.XmlEntry>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.XmlEntry, Entry>();
      AutoMapper.Mapper.CreateMap<Account, Gateways.Xml.XmlAccount>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.XmlAccount, Account>()
        .ConstructUsing(xmlAccount => new Account(xmlAccount.Number, xmlAccount.Entries.Select(Map<Gateways.Xml.XmlEntry, Entry>)));
      AutoMapper.Mapper.CreateMap<EasyBankContext, Gateways.Xml.XmlEasyBank>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.XmlEasyBank, EasyBankContext>()
        .ConstructUsing(xmlEasyBank => new EasyBankContext(null, null, null, null, null, null, xmlEasyBank.Accounts.SelectMany(a => a.Entries).Select(Map<Gateways.Xml.XmlEntry, Entry>)));

      AutoMapper.Mapper.CreateMap<Entry, Gateways.Ynab.YnabEntry>()
        .ConstructUsing(
        entry =>
          new Gateways.Ynab.YnabEntry
          {
            AmountIn = entry.AmountIn,
            AmountOut = entry.AmountOut,
            Description = entry.Description,
            Payee = entry.Payee,
            ValueDate = entry.ValueDate
          });

      AutoMapper.Mapper.CreateMap<IEnumerable<Entry>, Gateways.Ynab.YnabEntryCollection>()
        .ConstructUsing(entries => new Gateways.Ynab.YnabEntryCollection(entries.Select(Map<Entry, Gateways.Ynab.YnabEntry>).ToArray()));

      AutoMapper.Mapper.CreateMap<Gateways.Csv.CsvEntry, Entry>().ForMember(e => e.IsNew, expr => expr.UseValue(true));
    }

    private TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }

    public Gateways.Xml.XmlEntry MapToXml(Entry entry)
    {
      return this.Map<Entry, Gateways.Xml.XmlEntry>(entry);
    }

    public Entry MapToDomain(Gateways.Xml.XmlEntry xmlEntry)
    {
      return this.Map<Gateways.Xml.XmlEntry, Entry>(xmlEntry);
    }

    public Gateways.Xml.XmlEntryCollection MapToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, Gateways.Xml.XmlEntryCollection>(entries);
    }

    public EntryCollection MapToDomain(Gateways.Xml.XmlEntryCollection xmlEntries)
    {
      return this.Map<Gateways.Xml.XmlEntryCollection, EntryCollection>(xmlEntries);
    }

    public Gateways.Xml.XmlEasyBank MapToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, Gateways.Xml.XmlEasyBank>(easyBank);
    }

    public Gateways.Xml.XmlAccount MapDomainToXml(Account account)
    {
      return this.Map<Account, Gateways.Xml.XmlAccount>(account);
    }

    public Gateways.Xml.XmlAccountCollection MapDomainToXml(AccountCollection accounts)
    {
      return this.Map<AccountCollection, Gateways.Xml.XmlAccountCollection>(accounts);
    }

    public Account MapXmlToDomain(Gateways.Xml.XmlAccount xmlAccount)
    {
      return this.Map<Gateways.Xml.XmlAccount, Account>(xmlAccount);
    }

    public AccountCollection MapXmlToDomain(Gateways.Xml.XmlAccountCollection xmlAccounts)
    {
      return this.Map<Gateways.Xml.XmlAccountCollection, AccountCollection>(xmlAccounts);
    }

    public Gateways.Xml.XmlEasyBank MapDomainToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, Gateways.Xml.XmlEasyBank>(easyBank);
    }

    public Gateways.Ynab.YnabEntry MapToYnab(Entry entry)
    {
      return this.Map<Entry, Gateways.Ynab.YnabEntry>(entry);
    }

    public Gateways.Ynab.YnabEntryCollection MapToYnab(Entry[] entries)
    {
      return this.Map<IEnumerable<Entry>, Gateways.Ynab.YnabEntryCollection>(entries);
    }

    public Entry MapToDomain(Gateways.Csv.CsvEntry csvEntry)
    {
      return this.Map<Gateways.Csv.CsvEntry, Entry>(csvEntry);
    }

    public EasyBankContext MapXmlToDomain(Gateways.Xml.XmlEasyBank xmlEasyBank)
    {
      return this.Map<Gateways.Xml.XmlEasyBank, EasyBankContext>(xmlEasyBank);
    }
  }
}