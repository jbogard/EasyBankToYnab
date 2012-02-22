using QuestMaster.EasyBankRepository.DomainModel;

namespace EasyBankRepository
{
  public interface IDataContextProvider
  {
    EasyBankContext DataContext { get; }
    void LoadDataContext(string fileName);
    void SaveAndClose();
  }
}