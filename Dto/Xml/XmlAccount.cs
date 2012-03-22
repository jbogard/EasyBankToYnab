using System;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  [DataContract(Name = "account", Namespace = "")]
  public class XmlAccount
  {
    [DataMember(Name = "number")]
    public string Number { get; set; }

    [DataMember(Name = "xmlEntries")]
    public XmlEntryCollection Entries { get; set; }
  }
}
