using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace EasyBankRepository
{
  class FileServices : IFileServices
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

    internal static IEnumerable<string> ReadLines(string path)
    {
      List<string> list = new List<string>();
      if (!File.Exists(path))
      {
        throw new ArgumentException("Path must exist", "path");
      }
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
      return list;
    }
  }
}