using System;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IXmlMapper
  {
    Entry MapToDomain(XmlEntry xmlEntry);

    XmlEasyBank MapToXml(EasyBankContext easyBank);
  }
}