using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    XmlEntry MapToXml(Entry entry);
    Entry MapToDomain(XmlEntry xmlEntry);

    XmlEntryCollection MapToXml(EntryCollection entries);
    EntryCollection MapToDomain(XmlEntryCollection xmlEntries);

    //XmlAccount MapToXml(XmlAccount account);
    //XmlAccountCollection MapToXml(XmlAccountCollection accounts);
    XmlEasyBank MapToXml(EasyBankContext easyBank);

    //XmlAccount MapToDomain(XmlAccount account);
    //XmlAccountCollection MapToDomain(XmlAccountCollection accounts);
    //EasyBankContext MapToDomain(XmlEasyBank easyBank);
    Gateways.Ynab.YnabEntry MapToYnab(Entry entry);
    Gateways.Ynab.YnabEntryCollection MapToYnab(Entry[] entries);
    Entry MapToDomain(Gateways.Csv.CsvEntry csvEntry);
}

  public interface IXmlMapper : IMapper
  {
  }

  public interface IYnabMapper : IMapper
  {
  }

  public interface IEasyBankMapper : IMapper
  {
  }
}