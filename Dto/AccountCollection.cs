using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankRepository.Dto
{
  [CollectionDataContract(Name = "accounts", Namespace = "", ItemName = "account")]
  public class AccountCollection : List<Account>
  {
  }
}
