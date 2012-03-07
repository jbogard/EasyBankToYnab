using System;
using System.Collections.Generic;
using System.IO;

namespace QuestMaster.EasyBankToYnab.Gateways
{
  public class FileAccess : IFileAccess
  {
    public string[] ReadLines(string path)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (!File.Exists(path)) throw new ArgumentException("Path must exist", "path");

      List<string> list = new List<string>();

      using (Stream stream = File.OpenRead(path))
      {
        using (StreamReader reader = new StreamReader(stream))
        {
          while (!reader.EndOfStream)
          {
            list.Add(reader.ReadLine());
          }
        }
      }

      return list.ToArray();
    }

    public void WriteLines(string path, IEnumerable<string> lines)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (!File.Exists(path)) throw new ArgumentException("Path must exist", "path");
      if (lines == null) throw new ArgumentNullException("lines");
      
      using (Stream stream = File.OpenWrite(path))
      {
        using (StreamWriter writer = new StreamWriter(stream))
        {
          writer.Write(string.Join(Environment.NewLine, lines));
        }
      }
    }

    public void BackupFile(string path)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (!File.Exists(path)) throw new ArgumentException("Path must exist", "path");

      string backupDirectory = Path.Combine(
        Path.GetDirectoryName(path),
        "Backup");

      if (!Directory.Exists(backupDirectory))
      {
        Directory.CreateDirectory(backupDirectory);
      }

      string backupFilename = Path.GetFileNameWithoutExtension(path) + "." + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") +
                              Path.GetExtension(path);

      string backupPath = Path.Combine(backupDirectory, backupFilename);

      File.Copy(path, backupPath);
    }
  }
}