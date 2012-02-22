using System;
using System.IO;
using EasyBankRepository;
using QuestMaster.EasyBankRepository.DomainModel;

namespace QuestMaster.EasyBankRepository.UI
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
            //easyBank.SubmitChanges();
            //easyBank.Dispose();
        }
    }

    private static EasyBankContext DoLoadDataContext(string pathToDataFile)
    {
      if (File.Exists(pathToDataFile))
      {
        //return new EasyBank(pathToDataFile);
      }
      return null;
    }


  }
}