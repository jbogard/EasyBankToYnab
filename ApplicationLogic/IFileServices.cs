using System;

namespace QuestMaster.EasyBankRepository.ApplicationLogic
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
