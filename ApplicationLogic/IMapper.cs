using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    TOutput Map<TInput, TOutput>(TInput input);

    Gateways.Xml.Entry MapDomainToXml(Entry entry); 
    Entry MapXmlToDomain(Gateways.Xml.Entry entry);

    Gateways.Xml.EntryCollection MapDomainToXml(EntryCollection entries);
    EntryCollection MapXmlToDomain(Gateways.Xml.EntryCollection entries);

    Gateways.Xml.Account MapDomainToXml(Account account);
    Gateways.Xml.AccountCollection MapDomainToXml(AccountCollection accounts);
    EasyBank MapDomainToXml(EasyBankContext easyBank);

    //Account MapXmlToDomain(Gateways.Xml.Account account);
    //AccountCollection MapXmlToDomain(Gateways.Xml.AccountCollection accounts);
    //EasyBankContext MapXmlToDomain(EasyBank easyBank);

    Gateways.Ynab.Entry MapDomainToYnab(Entry entry);
    Gateways.Ynab.EntryCollection MapDomainToYnab(Entry[] entries);
    Entry MapEasyBankToDomain(Gateways.EasyBank.Entry entry);
  }
}