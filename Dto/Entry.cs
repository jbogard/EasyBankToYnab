using System;
using System.Runtime.Serialization;

namespace QuestMaster.EasyBankRepository.Dto
{
  [DataContract(Name = "entry", Namespace = "")]
  public class Entry
  {
    [DataMember(Name = "account")]
    public string Account { get; set; }

    [DataMember(Name = "bookingDate")]
    public DateTime BookingDate { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "payee")]
    public string Payee { get; set; }

    [DataMember(Name = "valueDate")]
    public DateTime ValueDate { get; set; }

    [DataMember(Name = "amountIn")]
    public decimal AmountIn { get; set; }

    [DataMember(Name = "amountOut")]
    public decimal AmountOut { get; set; }

    [DataMember(Name = "currency")]
    public string Currency { get; set; }

    [DataMember(Name = "isNew")]
    public bool IsNew { get; set; }
  }
}