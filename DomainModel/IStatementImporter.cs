using System;

namespace QuestMaster.EasyBankToYnab.DomainModel
{
  public interface IStatementImporter
  {
    Entry Import(string statement);
  }
}