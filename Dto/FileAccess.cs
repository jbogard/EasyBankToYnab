using System;
using System.Collections.Generic;
using System.IO;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

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
      if (lines == null) throw new ArgumentNullException("lines");

      using (StreamWriter writer = File.CreateText(path))
      {
        writer.Write(string.Join(Environment.NewLine, lines));
      }
    }

    public void BackupFile(string path, string backupFolder)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (!File.Exists(path)) throw new ArgumentException("Path must exist", "path");

      string directoryName = Path.GetDirectoryName(path);

      if (directoryName == null) throw new ApplicationException("Directory of file was not found.");

      string backupDirectory = Path.Combine(directoryName, backupFolder);

      if (!Directory.Exists(backupDirectory))
      {
        Directory.CreateDirectory(backupDirectory);
      }

      string backupFilename = Path.GetFileNameWithoutExtension(path) + "." + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") +
                              Path.GetExtension(path);

      string backupPath = Path.Combine(backupDirectory, backupFilename);

      File.Copy(path, backupPath);
    }

    public void Write(string path, object dataContract)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");

      using (Stream stream = File.Create(path))
      {
        stream.Serialize(dataContract);
      }
    }

    public T Read<T>(string path)
    {
      if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
      if (!File.Exists(path)) throw new ArgumentException("Path must exist", "path");

      T result;

      using (Stream stream = File.OpenRead(path))
      {
        result = stream.Deserialize<T>();
      }

      return result;
    }
  }
}