﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankToYnab.Dto
{
  [CollectionDataContract(Name = "entries", Namespace = "", ItemName = "entry")]
  public class EntryCollection : List<Entry>
  {
  }
}