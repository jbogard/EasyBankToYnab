using System;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Csv
{
  public class CsvGateway : ICsvGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly IPathProvider pathProvider;

    public CsvGateway(IFileAccess fileAccess, IPathProvider pathProvider)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");

      this.fileAccess = fileAccess;
      this.pathProvider = pathProvider;
    }

    public CsvEntryCollection Read()
    {
      return new CsvEntryCollection(this.fileAccess.ReadLines(pathProvider.PathToCsvFile).ToArray());
    }
  }
}