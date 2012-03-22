using System;
using QuestMaster.EasyBankToYnab.Gateways.Csv;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers
{
  public class CsvMapper : ICsvMapper
  {
    public CsvMapper()
    {
      AutoMapper.Mapper.CreateMap<CsvEntry, Entry>().ForMember(e => e.IsNew, expr => expr.UseValue(true));
    }

    public Entry MapToDomain(CsvEntry csvEntry)
    {
      return this.Map<CsvEntry, Entry>(csvEntry);
    }

    private TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }
  }
}