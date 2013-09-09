using System;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  [DataContract(Name = "account", Namespace = "")]
  public class XmlAccount
  {
    [DataMember(Name = "number")]
    public string Number { get; set; }

    [DataMember(Name = "description", IsRequired = false, EmitDefaultValue = false)]
    public string Description { get; set; }

    [DataMember(Name = "entries")]
    public XmlEntryCollection Entries { get; set; }
  }
}
