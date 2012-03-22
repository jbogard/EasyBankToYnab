using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface ICsvAgent
  {
    IEnumerable<Entry> Read(); 
  }
}