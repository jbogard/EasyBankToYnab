using System;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Mapper : IMapper
  {
    public Mapper()
    {
      // Xml mapping
      AutoMapper.Mapper.CreateMap<Entry, Gateways.Xml.Entry>();
      AutoMapper.Mapper.CreateMap<Gateways.Xml.Entry, Entry>();
    }

    public TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }

    public Gateways.Xml.Entry MapDomainToXml(Entry entry)
    {
      return this.Map<Entry, Gateways.Xml.Entry>(entry);
    }

    public Entry MapXmlToDomain(Gateways.Xml.Entry entry)
    {
      return this.Map<Gateways.Xml.Entry, Entry>(entry);
    }

    public Gateways.Xml.EntryCollection MapDomainToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, Gateways.Xml.EntryCollection>(entries);
    }

    public EntryCollection MapXmlToDomain(Gateways.Xml.EntryCollection entries)
    {
      return this.Map<Gateways.Xml.EntryCollection, EntryCollection>(entries);
    }
  }
}