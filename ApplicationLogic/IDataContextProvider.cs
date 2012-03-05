using System;
using QuestMaster.EasyBankRepository.DomainModel;

namespace QuestMaster.EasyBankRepository.ApplicationLogic
{
  public interface IDataContextProvider
  {
    EasyBankContext DataContext { get; }
    void LoadDataContext(string fileName);
    void SaveAndClose();
  }
}