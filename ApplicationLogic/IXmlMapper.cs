using System;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IXmlMapper
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
  }
}