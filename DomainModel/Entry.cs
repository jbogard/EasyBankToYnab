using System;

namespace QuestMaster.EasyBankToYnab.DomainModel
{
  public class Entry
  {
    public string Account { get; set; }

    public DateTime BookingDate { get; set; }

    public string Description { get; set; }

    public string Payee { get; set; }

    public DateTime ValueDate { get; set; }

    public decimal AmountIn { get; set; }

    public decimal AmountOut { get; set; }

    public string Currency { get; set; }

    public bool IsNew { get; set; }
  }
}