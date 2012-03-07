using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  public class FakeFileAccess : IFileAccess
  {
    public string[] ReadLinesResult;
    public string[] ReadLines(string path)
    {
      return ReadLinesResult;
    }

    public string[] LinesWritten;
    public void WriteLines(string path, IEnumerable<string> lines)
    {
      LinesWritten = lines.ToArray();
    }

    public void BackupFile(string path, string backupFolder)
    {
    }

    public void Write(string path, object dataContract)
    {
    }

    public T Read<T>(string path)
    {
      return default(T);
    }
  }
}