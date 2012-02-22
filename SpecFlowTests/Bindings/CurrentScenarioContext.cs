using System;
using System.Collections.Generic;
using QuestMaster.EasyBankRepository.DomainModel;
using QuestMaster.EasyBankRepository.DomainTests.Tables;
using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Bindings
{
  public static class CurrentScenarioContext
  {
    public static Dictionary<int, StatementRow> Statements
    {
      get { return (Dictionary<int, StatementRow>)ScenarioContext.Current["Statements"]; }
      set { ScenarioContext.Current["Statements"] = value; }
    }

    public static EasyBankContext EasyBankContext
    {
      get { return (EasyBankContext)ScenarioContext.Current["EasyBankContext"]; }
    }

    internal static void InitializeEasyBankContext(EasyBankContext value)
    {
      ScenarioContext.Current["EasyBankContext"] = value;
    }

    public static string CurrentAccountNumber
    {
      get { return (string)ScenarioContext.Current["CurrentAccountNumber"]; }
      set { ScenarioContext.Current["CurrentAccountNumber"] = value; }
    }

    public static Dictionary<int, EntryRow> ExpectedEntries
    {
      get { return (Dictionary<int, EntryRow>)ScenarioContext.Current["ExpectedEntries"]; }
      set { ScenarioContext.Current["ExpectedEntries"] = value; }
    }

    public static string ResultOfExport
    {
      get { return (string)ScenarioContext.Current["ResultOfExport"]; }
      set { ScenarioContext.Current["ResultOfExport"] = value; }
    }
  }
}