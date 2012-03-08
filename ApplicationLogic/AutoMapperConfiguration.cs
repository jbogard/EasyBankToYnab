using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class AutoMapperConfiguration
  {
    public AutoMapperConfiguration()
    {
      AutoMapper.Mapper.CreateMap<Entry[], Gateways.Xml.EntryCollection>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.EntryCollection, Entry[]>();

      // YNAB mapping
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Ynab.Entry>();
      AutoMapper.Mapper.CreateMap<Entry[], Gateways.Ynab.EntryCollection>();

      // EasyBank mapping.
      AutoMapper.Mapper.CreateMap<Gateways.EasyBank.Entry, Entry>();
      AutoMapper.Mapper.CreateMap<Gateways.EasyBank.EntryCollection, Entry[]>();
    }
  }
}