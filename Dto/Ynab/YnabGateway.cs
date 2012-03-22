using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class YnabGateway : IYnabGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly string path;
    private readonly CultureSettings cultureSettings;

    public YnabGateway(IFileAccess fileAccess, string path, CultureSettings cultureSettings)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
      if (cultureSettings == null) throw new ArgumentNullException("cultureSettings");

      this.fileAccess = fileAccess;
      this.path = path;
      this.cultureSettings = cultureSettings;
    }

    public void Write(YnabEntryCollection ynabEntries)
    {
      if (ynabEntries == null) throw new ArgumentNullException("ynabEntries");

      fileAccess.WriteLines(this.path, ynabEntries.ToYnabStrings(cultureSettings));
    }
  }
}