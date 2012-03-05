using System;
using System.IO;
using AutoMapper;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class FileGateway : IFileGateway
  {
    public void Save(DomainModel.EasyBankContext easyBankContext, string path)
    {
      if (!File.Exists(path))
      {
        throw new ArgumentException("Path must exist", "path");
      }

      if (easyBankContext == null) { throw new ArgumentNullException("easyBankContext"); }

      BackupCurrentFile(path);

      Dto.EasyBank dto = this.Convert(easyBankContext);

      using (Stream stream = File.Create(path))
      {
        stream.Serialize(dto);
      }
    }

    private static void BackupCurrentFile(string path)
    {
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

    public DomainModel.EasyBankContext Open(string path)
    {
      if (!File.Exists(path))
      {
        throw new ArgumentException("Path must exist", "path");
      }

      Dto.EasyBank easyBank;

      using (Stream stream = File.OpenRead(path))
      {
        easyBank = stream.Deserialize<Dto.EasyBank>();
      }

      if (easyBank == null)
      {
        throw new ApplicationException();
      }
      
      return Convert(easyBank);
    }

    private Dto.EasyBank Convert(DomainModel.EasyBankContext easyBank)
    {
      return Mapper.Map<DomainModel.EasyBankContext, Dto.EasyBank>(easyBank);
    }

    private DomainModel.EasyBankContext Convert(Dto.EasyBank easyBank)
    {
      return Mapper.Map<Dto.EasyBank, DomainModel.EasyBankContext>(easyBank);
    }
  }
}