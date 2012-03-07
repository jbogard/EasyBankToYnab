using System;
using Microsoft.Win32;
using QuestMaster.EasyBankToYnab.ApplicationLogic;

namespace QuestMaster.EasyBankToYnab.UI
{
  internal class FileLookupService : IFileLookupService
  {
    public Tuple<string, bool> LookForFile(string fileName, string filter, Mode mode)
    {
      FileDialog dialog;
      if (mode == Mode.Save)
      {
        dialog = new SaveFileDialog();
      }
      else
      {
        dialog = new OpenFileDialog();
      }
      dialog.FileName = fileName;
      dialog.Filter = filter;

      return (bool)dialog.ShowDialog()
               ? new Tuple<string, bool>(dialog.FileName, true)
               : new Tuple<string, bool>(dialog.FileName, false);
    }
  }
}