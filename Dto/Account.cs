﻿using System.Runtime.Serialization;

namespace QuestMaster.EasyBankRepository.Dto
{
  [DataContract(Name = "account", Namespace = "")]
  public class Account
  {
    [DataMember(Name = "number")]
    public string Number { get; set; }

    [DataMember(Name = "entries")]
    public EntryCollection Entries { get; set; }
  }
}
