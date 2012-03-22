using System;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IYnabMapper
  {
    YnabEntryCollection MapToYnab(Entry[] entries);
  }
}