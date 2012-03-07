namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public interface IYnabGateway
  {
    void Write(EntryCollection entries);
  }
}