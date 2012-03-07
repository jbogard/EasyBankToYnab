using System;
using System.IO;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class DataContextProvider : IDataContextProvider
  {
    private readonly IFileGateway fileGateway;
    private string path;

    public DataContextProvider(IFileGateway fileGateway)
    {
      this.fileGateway = fileGateway;
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
          this.fileGateway.Save(this.DataContext, this.path);
        }
    }

    private EasyBankContext DoLoadDataContext(string pathToDataFile)
    {
      if (File.Exists(pathToDataFile))
      {
        this.path = pathToDataFile;
        return this.fileGateway.Open(this.path);
      }
      return null;
    }
  }
}