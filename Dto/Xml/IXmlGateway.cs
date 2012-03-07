namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  public interface IXmlGateway
  {
    void Write(EasyBank easyBank);

    EasyBank Read();
  }
}