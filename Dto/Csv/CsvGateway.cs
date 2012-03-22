using System;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Csv
{
  public class CsvGateway : ICsvGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly string path;

    public CsvGateway(IFileAccess fileAccess, string path)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

      this.fileAccess = fileAccess;
      this.path = path;
    }

    public CsvEntryCollection Read()
    {
      return new CsvEntryCollection(this.fileAccess.ReadLines(path).ToArray());
    }
  }
}