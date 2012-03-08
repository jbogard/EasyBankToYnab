namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface IMapper
  {
    TOutput Map<TInput, TOutput>(TInput input);
    Gateways.Xml.Entry MapDomainToXml(Entry entry);
    Entry MapXmlToDomain(Gateways.Xml.Entry entry);
    Gateways.Xml.EntryCollection MapDomainToXml(EntryCollection entries);
    EntryCollection MapXmlToDomain(Gateways.Xml.EntryCollection entries);
  }
}