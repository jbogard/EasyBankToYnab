using System;
using QuestMaster.EasyBankToYnab.Gateways.Csv;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface ICsvMapper
  {
    Entry MapToDomain(CsvEntry csvEntry);
  }
}