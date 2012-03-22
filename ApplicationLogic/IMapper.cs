using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    Gateways.Xml.XmlEntry MapToXml(Entry entry);
    Entry MapToDomain(Gateways.Xml.XmlEntry xmlEntry);

    Gateways.Xml.XmlEntryCollection MapToXml(EntryCollection entries);
    EntryCollection MapToDomain(Gateways.Xml.XmlEntryCollection xmlEntries);

    //Gateways.Xml.XmlAccount MapToXml(XmlAccount account);
    //Gateways.Xml.XmlAccountCollection MapToXml(XmlAccountCollection accounts);
    XmlEasyBank MapToXml(EasyBankContext easyBank);

    //XmlAccount MapToDomain(Gateways.Xml.XmlAccount account);
    //XmlAccountCollection MapToDomain(Gateways.Xml.XmlAccountCollection accounts);
    //EasyBankContext MapToDomain(XmlEasyBank easyBank);
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