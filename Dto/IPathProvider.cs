using System;

namespace QuestMaster.EasyBankToYnab.Gateways
{
    public interface IPathProvider
    {
        string PathToXmlFile { get; set; }

        string PathToYnabFile { get; set; }

        string PathToCsvFile { get; set; }
    }
}