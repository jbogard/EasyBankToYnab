namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  public interface IXmlGateway
  {
    void Write(XmlEasyBank xmlEasyBank);

    XmlEasyBank Read();
  }
}