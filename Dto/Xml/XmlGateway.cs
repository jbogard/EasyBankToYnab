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

    public void Write(EasyBank easyBank)
    {
      if (easyBank == null) throw new ArgumentNullException("easyBank");

      fileAccess.Write(path, easyBank);
    }

    public EasyBank Read()
    {
      EasyBank easyBank = this.fileAccess.Read<EasyBank>(path);

      if (easyBank == null)
      {
        throw new ApplicationException();
      }

      return easyBank;
    }
  }
}