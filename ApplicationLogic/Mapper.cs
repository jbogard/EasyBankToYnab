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
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Xml.Entry>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.Entry, Entry>();
      AutoMapper.Mapper.CreateMap<Account, Gateways.Xml.Account>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.Account, Account>()
        .ConstructUsing(xmlAccount => new Account(xmlAccount.Number, xmlAccount.Entries.Select(Map<Gateways.Xml.Entry, Entry>)));
      AutoMapper.Mapper.CreateMap<EasyBankContext, Gateways.Xml.EasyBank>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.EasyBank, EasyBankContext>()
        .ConstructUsing(xmlEasyBank => new EasyBankContext(null, null, null, null, null, null, xmlEasyBank.Accounts.SelectMany(a => a.Entries).Select(Map<Gateways.Xml.Entry, Entry>)));

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

    public Gateways.Xml.Entry MapToXml(Entry entry)
    {
      return this.Map<Entry, Gateways.Xml.Entry>(entry);
    }

    public Entry MapToDomain(Gateways.Xml.Entry entry)
    {
      return this.Map<Gateways.Xml.Entry, Entry>(entry);
    }

    public Gateways.Xml.EntryCollection MapToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, Gateways.Xml.EntryCollection>(entries);
    }

    public EntryCollection MapToDomain(Gateways.Xml.EntryCollection entries)
    {
      return this.Map<Gateways.Xml.EntryCollection, EntryCollection>(entries);
    }

    public Gateways.Xml.EasyBank MapToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, Gateways.Xml.EasyBank>(easyBank);
    }

    public Gateways.Xml.Account MapDomainToXml(Account account)
    {
      return this.Map<Account, Gateways.Xml.Account>(account);
    }

    public Gateways.Xml.AccountCollection MapDomainToXml(AccountCollection accounts)
    {
      return this.Map<AccountCollection, Gateways.Xml.AccountCollection>(accounts);
    }

    public Account MapXmlToDomain(Gateways.Xml.Account account)
    {
      return this.Map<Gateways.Xml.Account, Account>(account);
    }

    public AccountCollection MapXmlToDomain(Gateways.Xml.AccountCollection accounts)
    {
      return this.Map<Gateways.Xml.AccountCollection, AccountCollection>(accounts);
    }

    public Gateways.Xml.EasyBank MapDomainToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, Gateways.Xml.EasyBank>(easyBank);
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

    public EasyBankContext MapXmlToDomain(Gateways.Xml.EasyBank easyBank)
    {
      return this.Map<Gateways.Xml.EasyBank, EasyBankContext>(easyBank);
    }
  }
}