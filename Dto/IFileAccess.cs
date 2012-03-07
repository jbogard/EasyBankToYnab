using System;
using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.Gateways
{
  public interface IFileAccess
  {
    string[] ReadLines(string path);
    void WriteLines(string path, IEnumerable<string> lines);
    void BackupFile(string path, string backupFolder);
    void Write(string path, object dataContract);
    T Read<T>(string path);
  }
}