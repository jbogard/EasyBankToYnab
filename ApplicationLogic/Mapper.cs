using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.Csv;
using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Mapper : IMapper, IXmlMapper, IYnabMapper, ICsvMapper
  {
    public Mapper()
    {
      // Xml mapping
      AutoMapper.Mapper.CreateMap<Entry, XmlEntry>();
      AutoMapper.Mapper.CreateMap<XmlEntry, Entry>();
      AutoMapper.Mapper.CreateMap<Account, XmlAccount>();
      AutoMapper.Mapper.CreateMap<XmlAccount, Account>()
        .ConstructUsing(xmlAccount => new Account(xmlAccount.Number, xmlAccount.Entries.Select(Map<XmlEntry, Entry>)));
      AutoMapper.Mapper.CreateMap<EasyBankContext, XmlEasyBank>();
      AutoMapper.Mapper.CreateMap<XmlEasyBank, EasyBankContext>()
        .ConstructUsing(xmlEasyBank => new EasyBankContext(null, null, null, null, null, xmlEasyBank.Accounts.SelectMany(a => a.Entries).Select(Map<XmlEntry, Entry>)));

      AutoMapper.Mapper.CreateMap<Entry, YnabEntry>()
        .ConstructUsing(
        entry =>
          new YnabEntry
          {
            AmountIn = entry.AmountIn,
            AmountOut = entry.AmountOut,
            Description = entry.Description,
            Payee = entry.Payee,
            ValueDate = entry.ValueDate
          });

      AutoMapper.Mapper.CreateMap<IEnumerable<Entry>, YnabEntryCollection>()
        .ConstructUsing(entries => new YnabEntryCollection(entries.Select(Map<Entry, YnabEntry>).ToArray()));

      AutoMapper.Mapper.CreateMap<CsvEntry, Entry>().ForMember(e => e.IsNew, expr => expr.UseValue(true));
    }

    private TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }

    public XmlEntry MapToXml(Entry entry)
    {
      return this.Map<Entry, XmlEntry>(entry);
    }

    public Entry MapToDomain(XmlEntry xmlEntry)
    {
      return this.Map<XmlEntry, Entry>(xmlEntry);
    }

    public XmlEntryCollection MapToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, XmlEntryCollection>(entries);
    }

    public EntryCollection MapToDomain(XmlEntryCollection xmlEntries)
    {
      return this.Map<XmlEntryCollection, EntryCollection>(xmlEntries);
    }

    public XmlEasyBank MapToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, XmlEasyBank>(easyBank);
    }

    public XmlAccount MapDomainToXml(Account account)
    {
      return this.Map<Account, XmlAccount>(account);
    }

    public XmlAccountCollection MapDomainToXml(AccountCollection accounts)
    {
      return this.Map<AccountCollection, XmlAccountCollection>(accounts);
    }

    public Account MapXmlToDomain(XmlAccount xmlAccount)
    {
      return this.Map<XmlAccount, Account>(xmlAccount);
    }

    public AccountCollection MapXmlToDomain(XmlAccountCollection xmlAccounts)
    {
      return this.Map<XmlAccountCollection, AccountCollection>(xmlAccounts);
    }

    public XmlEasyBank MapDomainToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, XmlEasyBank>(easyBank);
    }

    public YnabEntry MapToYnab(Entry entry)
    {
      return this.Map<Entry, YnabEntry>(entry);
    }

    public YnabEntryCollection MapToYnab(Entry[] entries)
    {
      return this.Map<IEnumerable<Entry>, YnabEntryCollection>(entries);
    }

    public Entry MapToDomain(CsvEntry csvEntry)
    {
      return this.Map<CsvEntry, Entry>(csvEntry);
    }

    public EasyBankContext MapXmlToDomain(XmlEasyBank xmlEasyBank)
    {
      return this.Map<XmlEasyBank, EasyBankContext>(xmlEasyBank);
    }
  }
}