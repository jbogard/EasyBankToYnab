using System;
using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.Gateways
{
  public interface IFileAccess
  {
    string[] ReadLines(string path);
    void WriteLines(string path, IEnumerable<string> lines);
    void BackupFile(string path, string backupFolder);
    void Write<T>(string path, T dataContract);
    T Read<T>(string path);
  }
}