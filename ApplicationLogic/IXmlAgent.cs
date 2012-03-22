using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IXmlAgent
  {
    void Write(EasyBankContext easyBank);

    IEnumerable<Entry> Read();
  }
}