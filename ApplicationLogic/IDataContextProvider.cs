using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IDataContextProvider
  {
    EasyBankContext DataContext { get; }
    void LoadDataContext(string fileName);
    void SaveAndClose();
  }
}