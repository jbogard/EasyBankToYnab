using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.Csv
{
  public class CsvEntryCollection : IEnumerable<CsvEntry>
  {
    private readonly CsvEntry[] csvEntries;

    public CsvEntryCollection(string[] lines)
    {
      if (lines == null) throw new ArgumentNullException("lines");
      if (lines.Length < 1) throw new ArgumentException("Array 'lines' must not be empty.", "lines");

      this.csvEntries = lines.Select(line => new CsvEntry(line)).ToArray();
    }

    public IEnumerator<CsvEntry> GetEnumerator()
    {
      return this.csvEntries.OfType<CsvEntry>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}