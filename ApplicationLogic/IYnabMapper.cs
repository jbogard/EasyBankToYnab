using System;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IYnabMapper
  {
    YnabEntry MapToYnab(Entry entry);
    YnabEntryCollection MapToYnab(Entry[] entries);
  }
}