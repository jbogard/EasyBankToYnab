using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class YnabGateway : IYnabGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly IPathProvider pathProvider;
    private readonly CultureSettings cultureSettings;

    public YnabGateway(IFileAccess fileAccess, IPathProvider pathProvider, CultureSettings cultureSettings)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (pathProvider == null) throw new ArgumentNullException("pathProvider");
      if (cultureSettings == null) throw new ArgumentNullException("cultureSettings");

      this.fileAccess = fileAccess;
      this.pathProvider = pathProvider;
      this.cultureSettings = cultureSettings;
    }

    public void Write(YnabEntryCollection ynabEntries)
    {
      if (ynabEntries == null) throw new ArgumentNullException("ynabEntries");

      fileAccess.WriteLines(this.pathProvider.PathToYnabFile, ynabEntries.ToYnabStrings(cultureSettings));
    }
  }
}