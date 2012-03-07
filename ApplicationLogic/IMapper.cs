namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    TOutput Map<TInput, TOutput>(TInput input);
  }
}