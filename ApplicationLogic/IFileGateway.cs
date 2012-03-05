using System;
using QuestMaster.EasyBankToYnab.DomainModel;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IFileGateway
  {
    void Save(EasyBankContext easyBankContext, string path);
    EasyBankContext Open(string path);
  }
}