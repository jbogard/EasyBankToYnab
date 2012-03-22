using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    Gateways.Xml.Entry MapToXml(Entry entry);
    Entry MapToDomain(Gateways.Xml.Entry entry);

    Gateways.Xml.EntryCollection MapToXml(EntryCollection entries);
    EntryCollection MapToDomain(Gateways.Xml.EntryCollection entries);

    //Gateways.Xml.Account MapToXml(Account account);
    //Gateways.Xml.AccountCollection MapToXml(AccountCollection accounts);
    EasyBank MapToXml(EasyBankContext easyBank);

    //Account MapToDomain(Gateways.Xml.Account account);
    //AccountCollection MapToDomain(Gateways.Xml.AccountCollection accounts);
    //EasyBankContext MapToDomain(EasyBank easyBank);
    Gateways.Ynab.YnabEntry MapToYnab(Entry entry);
    Gateways.Ynab.YnabEntryCollection MapToYnab(Entry[] entries);
     Entry MapToDomain(Gateways.Csv.CsvEntry csvEntry);
}

  public interface IXmlMapper
  {
  }

  public interface IYnabMapper
  {
  }

  public interface IEasyBankMapper
  {
  }
}