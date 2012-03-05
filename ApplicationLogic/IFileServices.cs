using System;
using Microsoft.Win32;

namespace EasyBankRepository
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
