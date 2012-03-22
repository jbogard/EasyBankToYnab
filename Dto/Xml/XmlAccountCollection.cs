using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Gateways.Xml
{
  [CollectionDataContract(Name = "accounts", Namespace = "", ItemName = "account")]
  public class XmlAccountCollection : List<XmlAccount>
  {
  }
}
