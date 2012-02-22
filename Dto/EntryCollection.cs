using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankRepository.Dto
{
  [CollectionDataContract(Name = "entries", Namespace = "", ItemName = "entry")]
  public class EntryCollection : List<Entry>
  {
  }
}