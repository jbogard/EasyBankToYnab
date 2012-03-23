using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  public class XmlGateway : IXmlGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly IPathProvider pathProvider;

    public XmlGateway(IFileAccess fileAccess, IPathProvider pathProvider)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");

      this.fileAccess = fileAccess;
      this.pathProvider = pathProvider;
    }

    public void Write(XmlEasyBank xmlEasyBank)
    {
      if (xmlEasyBank == null) throw new ArgumentNullException("xmlEasyBank");

      fileAccess.Write(pathProvider.PathToXmlFile, xmlEasyBank);
    }

    public XmlEasyBank Read()
    {
      XmlEasyBank xmlEasyBank = this.fileAccess.Read<XmlEasyBank>(pathProvider.PathToXmlFile);

      if (xmlEasyBank == null)
      {
        throw new ApplicationException();
      }

      return xmlEasyBank;
    }
  }
}