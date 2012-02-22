using System.Runtime.Serialization;

namespace QuestMaster.EasyBankRepository.Dto
{
  [DataContract(Name = "easyBank", Namespace = "")]
  public class EasyBank
  {
    [DataMember(Name = "number")]
    public AccountCollection Accounts { get; set; }
  }
}
