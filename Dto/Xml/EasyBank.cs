using System;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  [DataContract(Name = "easyBank", Namespace = "")]
  public class EasyBank
  {
    [DataMember(Name = "number")]
    public AccountCollection Accounts { get; set; }
  }
}
