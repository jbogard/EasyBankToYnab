using System;
using QuestMaster.EasyBankRepository.DomainModel;

namespace QuestMaster.EasyBankRepository.ApplicationLogic
{
  public interface IFileGateway
  {
    void Save(EasyBankContext easyBankContext, string path);
    EasyBankContext Open(string path);
  }
}