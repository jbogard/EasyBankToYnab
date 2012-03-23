using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  public class FakePathProvider : IPathProvider
  {
    public string PathToXmlFile { get; set; }

    public string PathToYnabFile { get; set; }

    public string PathToCsvFile { get; set; }
  }
}