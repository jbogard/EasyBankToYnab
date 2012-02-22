using System;

namespace QuestMaster.EasyBankRepository.DomainModel
{
  public class CultureSettings
  {
    public CultureSettings()
    {
      this.Separator = string.Empty;
      this.DateTimeFormatString = string.Empty;
      this.ZeroMoney = string.Empty;
      this.CultureInfo = System.Globalization.CultureInfo.InvariantCulture;
    }

    public static CultureSettings American()
    {
      return new CultureSettings { CultureInfo = new System.Globalization.CultureInfo("en-US"), DateTimeFormatString = "dd.MM.yyyy", ReplacementForSeparator = "-", Separator = ",", ZeroMoney = "0.00", ThousandSeparator = "," };
    }

    public static CultureSettings German()
    {
      return new CultureSettings { CultureInfo = new System.Globalization.CultureInfo("de-DE"), DateTimeFormatString = "dd.MM.yyyy", ReplacementForSeparator = "-", Separator = ";", ZeroMoney = "0,00", ThousandSeparator = "." };
    }

    public System.Globalization.CultureInfo CultureInfo { get; set; }

    public string DateTimeFormatString { get; set; }

    public string ReplacementForSeparator { get; set; }

    public string Separator { get; set; }

    public string ThousandSeparator { get; set; }

    public string ZeroMoney { get; set; }
  }
}