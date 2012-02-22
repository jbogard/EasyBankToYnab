using System;

namespace QuestMaster.EasyBankRepository.ApplicationLogic
{
  public class AutoMapperConfiguration
  {
    public AutoMapperConfiguration()
    {
      AutoMapper.Mapper.CreateMap<DomainModel.Entry, Dto.Entry>();
    }
  }
}