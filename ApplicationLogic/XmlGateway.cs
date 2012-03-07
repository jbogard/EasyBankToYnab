using System;
using System.IO;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class XmlGateway : IXmlGateway
  {
    private readonly IMapper mapper;
    private readonly string path;

    public XmlGateway(IMapper mapper, string path)
    {
      if (mapper == null) throw new ArgumentNullException("mapper");
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
 
      this.mapper = mapper;
      this.path = path;
    }

    public void Save(EasyBankContext easyBankContext)
    {
      if (!File.Exists(path))
      {
        throw new ArgumentException("Path must exist", "path");
      }

      if (easyBankContext == null) { throw new ArgumentNullException("easyBankContext"); }

      BackupCurrentFile(path);

      EasyBank dto = this.Convert(easyBankContext);

      this.Write(dto);
    }


    public EasyBankContext Open()
    {
      return Convert(this.Read());
    }

    private EasyBank Convert(EasyBankContext easyBank)
    {
      return this.mapper.Map<EasyBankContext, EasyBank>(easyBank);
    }

    private EasyBankContext Convert(EasyBank easyBank)
    {
      return  this.mapper.Map<EasyBank, EasyBankContext>(easyBank);
    }

    public void Write(EasyBank easyBank)
    {
      using (Stream stream = File.Create(path))
      {
        stream.Serialize(easyBank);
      }
    }

    public EasyBank Read()
    {
      if (!File.Exists(path))
      {
        throw new ArgumentException("Path must exist", "path");
      }

      EasyBank easyBank;

      using (Stream stream = File.OpenRead(path))
      {
        easyBank = stream.Deserialize<EasyBank>();
      }

      if (easyBank == null)
      {
        throw new ApplicationException();
      }

      return easyBank;
    }
  }
}