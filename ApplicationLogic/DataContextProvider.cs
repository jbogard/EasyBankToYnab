using System;
using System.IO;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class DataContextProvider : IDataContextProvider
  {
    private readonly IXmlGateway xmlGateway;
    private string path;
    private readonly IMapper mapper;

    public DataContextProvider(IXmlGateway xmlGateway, IMapper mapper)
    {
      this.xmlGateway = xmlGateway;
      this.mapper = mapper;
    }

    public EasyBankContext DataContext
    {
      get; private set;
    }

    public void LoadDataContext(string fileName)
    {
      SaveAndClose();
      this.DataContext = DoLoadDataContext(fileName);
    }

    public void SaveAndClose()
    {
        var easyBank = this.DataContext;

        if (easyBank != null)
        {
          this.xmlGateway.Write(this.mapper.Map<EasyBankContext, EasyBank>(this.DataContext));
        }
    }

    private EasyBankContext DoLoadDataContext(string pathToDataFile)
    {
      if (File.Exists(pathToDataFile))
      {
        this.path = pathToDataFile;
        return this.mapper.Map<EasyBank, EasyBankContext>(this.xmlGateway.Read());
      }

      return null;
    }
  }
}