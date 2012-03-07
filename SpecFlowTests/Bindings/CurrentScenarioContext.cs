using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankToYnab.DomainTests.Bindings
{
  public static class CurrentScenarioContext
  {
    public static EasyBankContext EasyBankContext
    {
      get { return (EasyBankContext)ScenarioContext.Current["EasyBankContext"]; }
    }

    internal static void InitializeEasyBankContext(EasyBankContext value)
    {
      ScenarioContext.Current["EasyBankContext"] = value;
    }

    public static FakeFileAccess FakeFileAccess
    {
      get { return (FakeFileAccess)ScenarioContext.Current["FakeFileAccess"]; }
      set { ScenarioContext.Current["FakeFileAccess"] = value; }
    }
  }
}