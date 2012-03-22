using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Agents
{
  public class YnabAgent : IYnabAgent
  {
    private readonly IYnabMapper mapper;
    private readonly IYnabGateway gateway;

    public YnabAgent(IYnabGateway gateway)
      : this(gateway, new YnabMapper())
    {
    }

    public YnabAgent(IYnabGateway gateway, IYnabMapper mapper)
    {
      this.mapper = mapper;
      this.gateway = gateway;
    }

    public void Write(IEnumerable<Entry> entries)
    {
      var ynabEntries = this.mapper.MapToYnab(entries.ToArray());

      this.gateway.Write(ynabEntries);
    }
  }
}