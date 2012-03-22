using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.Gateways.Csv;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public interface ICsvAgent
  {
    IEnumerable<Entry> Read(); 
  }

  public class CsvAgent : ICsvAgent
  {
    private readonly ICsvGateway gateway;
    private readonly ICsvMapper mapper;

    public CsvAgent(ICsvGateway gateway, ICsvMapper mapper)
    {
      this.gateway = gateway;
      this.mapper = mapper;
    }

    public IEnumerable<Entry> Read()
    {
      return this.gateway.Read().Select(this.mapper.MapToDomain);
    }
  }
}