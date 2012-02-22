using System;

namespace QuestMaster.EasyBankRepository.DomainModel
{
  public interface IStatementImporter
  {
    Entry Import(string statement);
  }
}