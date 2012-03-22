using System;

namespace QuestMaster.EasyBankToYnab.Gateways.Csv
{
  public interface ICsvGateway
  {
    CsvEntryCollection Read();
  }
}