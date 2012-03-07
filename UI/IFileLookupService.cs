using System;

namespace QuestMaster.EasyBankToYnab.UI
{
  public enum Mode
  {
    Open,
    Save
  }

  public interface IFileLookupService
  {
    Tuple<string, bool> LookForFile(string fileName, string filter, Mode mode);
  }
 }
