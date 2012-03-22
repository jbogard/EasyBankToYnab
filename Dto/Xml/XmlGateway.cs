using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  public class XmlGateway : IXmlGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly string path;

    public XmlGateway(IFileAccess fileAccess, string path)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");

      this.fileAccess = fileAccess;
      this.path = path;
    }

    public void Write(XmlEasyBank xmlEasyBank)
    {
      if (xmlEasyBank == null) throw new ArgumentNullException("xmlEasyBank");

      fileAccess.Write(path, xmlEasyBank);
    }

    public XmlEasyBank Read()
    {
      XmlEasyBank xmlEasyBank = this.fileAccess.Read<XmlEasyBank>(path);

      if (xmlEasyBank == null)
      {
        throw new ApplicationException();
      }

      return xmlEasyBank;
    }
  }
}