using System;
using System.Collections.Generic;
using System.Linq;
using QuestMaster.EasyBankToYnab.ApplicationLogic.Mappers;
using QuestMaster.EasyBankToYnab.Gateways.Xml;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic.Agents
{
  public class XmlAgent : IXmlAgent
  {
    private readonly IXmlMapper mapper;
    private readonly IXmlGateway gateway;

    public XmlAgent(IXmlGateway gateway)
      : this(gateway, new XmlMapper())
    {
    }

    public XmlAgent(IXmlGateway gateway, IXmlMapper mapper)
    {
      this.mapper = mapper;
      this.gateway = gateway;
    }

    public void Write(EasyBankContext easyBank)
    {
      this.gateway.Write(this.mapper.MapToXml(easyBank));
    }

    public IEnumerable<Entry> Read()
    {
      return this.gateway.Read().Accounts.SelectMany(a => a.Entries).Select(this.mapper.MapToDomain);
    }
  }
}