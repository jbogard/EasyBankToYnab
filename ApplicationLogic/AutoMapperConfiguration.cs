using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class AutoMapperConfiguration
  {
    public AutoMapperConfiguration()
    {
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Xml.Entry>();
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Ynab.Entry>();
    }
  }
}