using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Ynab
{
  public class YnabGateway : IYnabGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly string path;

    public YnabGateway(IFileAccess fileAccess, string path)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

      this.fileAccess = fileAccess;
      this.path = path;
    }

    public void Write(EntryCollection entries)
    {
      if (entries == null) throw new ArgumentNullException("entries");

      fileAccess.WriteLines(this.path, entries.ToYnabStrings());
    }
  }
}