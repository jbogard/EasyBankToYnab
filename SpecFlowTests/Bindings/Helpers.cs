using System;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  internal static class Helpers
  {
    internal static string[] SplitLines(string multilineText)
    {
      return multilineText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(line => line.Trim()).ToArray();
    }
  }
}