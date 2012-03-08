using System;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Mapper : IMapper
  {
    public Mapper()
    {
      // Xml mapping
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Xml.Entry>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.Entry, Entry>();
      AutoMapper.Mapper.CreateMap<Account, Gateways.Xml.Account>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.Account, Account>()
        .ConstructUsing(xmlAccount => new Account(null, null, xmlAccount.Number, xmlAccount.Entries.Select(Map<Gateways.Xml.Entry, Entry>)));
      AutoMapper.Mapper.CreateMap<EasyBankContext, Gateways.Xml.EasyBank>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.EasyBank, EasyBankContext>()
        .ConstructUsing(xmlEasyBank => new EasyBankContext(null, null, null, null, xmlEasyBank.Accounts.SelectMany(a => a.Entries).Select(Map<Gateways.Xml.Entry, Entry>)));
    }

    public TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }

    public Gateways.Xml.Entry MapDomainToXml(Entry entry)
    {
      return this.Map<Entry, Gateways.Xml.Entry>(entry);
    }

    public Entry MapXmlToDomain(Gateways.Xml.Entry entry)
    {
      return this.Map<Gateways.Xml.Entry, Entry>(entry);
    }

    public Gateways.Xml.EntryCollection MapDomainToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, Gateways.Xml.EntryCollection>(entries);
    }

    public EntryCollection MapXmlToDomain(Gateways.Xml.EntryCollection entries)
    {
      return this.Map<Gateways.Xml.EntryCollection, EntryCollection>(entries);
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

    public EasyBankContext MapXmlToDomain(Gateways.Xml.EasyBank easyBank)
    {
      return this.Map<Gateways.Xml.EasyBank, EasyBankContext>(easyBank);
    }
  }
}