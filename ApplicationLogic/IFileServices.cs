using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public enum Mode
  {
    Open,
    Save
  }

  public interface IFileServices
  {
    Tuple<string, bool> LookForFile(string fileName, string filter, Mode mode);
  }
 }
