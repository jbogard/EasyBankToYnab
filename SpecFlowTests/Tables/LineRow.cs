using TechTalk.SpecFlow;

namespace QuestMaster.EasyBankRepository.DomainTests.Tables
{
  public class LineRow
  {
    private readonly TableRow row;

    public LineRow(TableRow row)
    {
      this.row = row;
    }

    public int Id
    {
      get { return this.row.AsInt32("Id"); }
    }

    public string Line
    {
      get { return this.row["Line"]; }
    }
  }
}