using System;
using System.ComponentModel;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class Entry : INotifyPropertyChanged, IEquatable<Entry>
  {
    private readonly string account;
    private readonly DateTime bookingDate;
    private readonly string description;
    private readonly string payee;
    private readonly DateTime valueDate;
    private readonly decimal amountIn;
    private readonly decimal amountOut;
    private readonly string currency;
    private bool isNew;

    public Entry(string account, DateTime bookingDate, string description, string payee, DateTime valueDate, decimal amountIn, decimal amountOut, string currency)
    {
      this.account = account;
      this.bookingDate = bookingDate;
      this.description = description;
      this.payee = payee;
      this.valueDate = valueDate;
      this.amountIn = amountIn;
      this.amountOut = amountOut;
      this.currency = currency;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public string Account
    {
      get { return account; }
    }

    public DateTime BookingDate
    {
      get { return bookingDate; }
    }

    public string Description
    {
      get { return description; }
    }

    public string Payee
    {
      get { return payee; }
    }

    public DateTime ValueDate
    {
      get { return valueDate; }
    }

    public decimal AmountIn
    {
      get { return amountIn; }
    }

    public decimal AmountOut
    {
      get { return amountOut; }
    }

    public string Currency
    {
      get { return currency; }
    }

    public bool IsNew
    {
      get { return isNew; }
      set
      {
        if(isNew != value)
        {
          isNew = value;

          this.PropertyChanged.Raise(this, () => this.IsNew);
        }
      }
    }

    public bool Equals(Entry other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Equals(other.account, account) && other.bookingDate.Equals(bookingDate) && Equals(other.description, description) && Equals(other.payee, payee) && other.valueDate.Equals(valueDate) && other.amountIn == amountIn && other.amountOut == amountOut && Equals(other.currency, currency);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Entry)) return false;
      return Equals((Entry) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int result = (account != null ? account.GetHashCode() : 0);
        result = (result*397) ^ bookingDate.GetHashCode();
        result = (result*397) ^ (description != null ? description.GetHashCode() : 0);
        result = (result*397) ^ (payee != null ? payee.GetHashCode() : 0);
        result = (result*397) ^ valueDate.GetHashCode();
        result = (result*397) ^ amountIn.GetHashCode();
        result = (result*397) ^ amountOut.GetHashCode();
        result = (result*397) ^ (currency != null ? currency.GetHashCode() : 0);
        return result;
      }
    }

    public static bool operator ==(Entry left, Entry right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Entry left, Entry right)
    {
      return !Equals(left, right);
    }
  }
}