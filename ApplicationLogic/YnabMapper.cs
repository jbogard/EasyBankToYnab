using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class YnabMapper : IYnabMapper
  {
    public YnabMapper()
    {
      AutoMapper.Mapper.CreateMap<Entry, YnabEntry>()
        .ConstructUsing(
        entry =>
          new YnabEntry
          {
            AmountIn = entry.AmountIn,
            AmountOut = entry.AmountOut,
            Description = entry.Description,
            Payee = entry.Payee,
            ValueDate = entry.ValueDate
          });

      AutoMapper.Mapper.CreateMap<IEnumerable<Entry>, YnabEntryCollection>()
        .ConstructUsing(entries => new YnabEntryCollection(entries.Select(Map<Entry, YnabEntry>).ToArray()));
    }

    public YnabEntry MapToYnab(Entry entry)
    {
      return this.Map<Entry, YnabEntry>(entry);
    }

    public YnabEntryCollection MapToYnab(Entry[] entries)
    {
      return this.Map<IEnumerable<Entry>, YnabEntryCollection>(entries);
    }

    protected TOutput Map<TInput, TOutput>(TInput input)
    {
      return AutoMapper.Mapper.Map<TInput, TOutput>(input);
    }
  }
}