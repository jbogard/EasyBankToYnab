using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Agents;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.Gateways.Csv;
using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.UI
{
  public class DataContextProvider : IDataContextProvider
  {
    private readonly IPathProvider pathProvider;
    private readonly CultureSettings cultureSettings;

    public DataContextProvider(IPathProvider pathProvider, CultureSettings cultureSettings)
    {
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");
      if (cultureSettings == null) throw new ArgumentNullException("cultureSettings");
      
      this.pathProvider = pathProvider;
      this.cultureSettings = cultureSettings;
    }

    public EasyBankContext DataContext
    {
      get; private set;
    }

    public void LoadDataContext()
    {
      SaveAndClose();
      this.DataContext = DoLoadDataContext();
    }

    public void SaveAndClose()
    {
      var dataContext = this.DataContext;

      if (dataContext != null)
      {
        dataContext.Save();
        this.DataContext = null;
      }
    }

    private EasyBankContext DoLoadDataContext()
    {
      var context = new EasyBankContext(
        new CsvAgent(new CsvGateway(new FileAccess(), pathProvider)),
        new YnabAgent(new YnabGateway(new FileAccess(), pathProvider, cultureSettings)),
        new XmlAgent(new XmlGateway(new FileAccess(), pathProvider)),
        new FileAccess(),
        pathProvider);

      if (System.IO.File.Exists(pathProvider.PathToXmlFile))
      {
        context.Load();
      }

      return context;
    }
  }
}