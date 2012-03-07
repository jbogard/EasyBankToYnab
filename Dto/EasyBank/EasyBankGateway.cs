using System;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.EasyBank
{
  public class EasyBankGateway : IEasyBankGateway
  {
    private readonly IFileAccess fileAccess;
    private readonly string path;

    public EasyBankGateway(IFileAccess fileAccess, string path)
    {
      if (fileAccess == null) throw new ArgumentNullException("fileAccess");
      if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

      this.fileAccess = fileAccess;
      this.path = path;
    }

    public EntryCollection Read()
    {
      return new EntryCollection(this.fileAccess.ReadLines(path).ToArray());
    }
  }
}