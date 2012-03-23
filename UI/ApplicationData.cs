using System;
using QuestMaster.EasyBankToYnab.ApplicationLogic;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.UI
{
  internal class ApplicationData
  {
    private readonly DataContextProvider dataContextProvider = new DataContextProvider(new PathProvider(), CultureSettings.German());
    private readonly PathProvider pathProvider = new PathProvider();

    public ApplicationData()
    {
    }

    public DataContextProvider DataContextProvider
    {
      get { return this.dataContextProvider; }
    }

    public IPathProvider PathProvider
    {
      get { return pathProvider; }
    }
  }
}