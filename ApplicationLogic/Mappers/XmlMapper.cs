using System;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers
{
  public class XmlMapper : IXmlMapper
  {
    public XmlMapper()
    {
      AutoMapper.Mapper.CreateMap<Entry, XmlEntry>();
      AutoMapper.Mapper.CreateMap<XmlEntry, Entry>();
      AutoMapper.Mapper.CreateMap<Account, XmlAccount>();
      AutoMapper.Mapper.CreateMap<EasyBankContext, XmlEasyBank>();
    }

    public Entry MapToDomain(XmlEntry xmlEntry)
    {
      return this.Map<XmlEntry, Entry>(xmlEntry);
    }

    public EntryCollection MapToDomain(XmlEntryCollection xmlEntries)
    {
      return this.Map<XmlEntryCollection, EntryCollection>(xmlEntries);
    }

    public XmlEntry MapToXml(Entry entry)
    {
      return this.Map<Entry, XmlEntry>(entry);
    }

    public XmlEntryCollection MapToXml(EntryCollection entries)
    {
      return this.Map<EntryCollection, XmlEntryCollection>(entries);
    }

    public XmlEasyBank MapToXml(EasyBankContext easyBank)
    {
      return this.Map<EasyBankContext, XmlEasyBank>(easyBank);
    }

    private TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }
  }
}