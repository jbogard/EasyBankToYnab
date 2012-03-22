using System;
using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IYnabAgent
  {
    void Write(IEnumerable<Entry> entries);
  }
}