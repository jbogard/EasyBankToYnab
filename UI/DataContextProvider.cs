using System;
using System.IO;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.DomainModel;

namespace QuestMaster.EasyBankToYnab.UI
{
  public class DataContextProvider : IDataContextProvider
  {
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
          // TODO: implement
            // easyBank.SubmitChanges();
            // easyBank.Dispose();
        }
    }

    private static EasyBankContext DoLoadDataContext(string pathToDataFile)
    {
      if (File.Exists(pathToDataFile))
      {
        // TODO: implement
        // return new EasyBank(pathToDataFile);
      }
      return null;
    }
  }
}