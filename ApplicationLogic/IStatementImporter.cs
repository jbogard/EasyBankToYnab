using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IStatementImporter
  {
    Entry Import(string statement);
  }
}