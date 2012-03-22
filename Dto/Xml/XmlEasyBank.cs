using System;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  [DataContract(Name = "easyBank", Namespace = "")]
  public class XmlEasyBank
  {
    [DataMember(Name = "number")]
    public XmlAccountCollection Accounts { get; set; }
  }
}
