using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestMaster.EasyBankToYnab.Gateways.EasyBank
{
  public class EntryCollection : IEnumerable<Entry>
  {
    private readonly Entry[] entries;

    public EntryCollection(string[] lines)
    {
      if (lines == null) throw new ArgumentNullException("lines");
      if (lines.Length < 1) throw new ArgumentException("Array 'lines' must not be empty.", "lines");

      this.entries = lines.Skip(1).Select(line => new Entry(line)).ToArray();
    }

    public IEnumerator<Entry> GetEnumerator()
    {
      return this.entries.OfType<Entry>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}