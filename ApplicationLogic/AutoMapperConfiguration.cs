using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class AutoMapperConfiguration
  {
    public AutoMapperConfiguration()
    {
      AutoMapper.Mapper.CreateMap<DomainModel.Entry, Dto.Entry>();
    }
  }
}