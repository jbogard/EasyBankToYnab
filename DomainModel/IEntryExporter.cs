using System;
using System.Collections.Generic;

namespace QuestMaster.EasyBankToYnab.DomainModel
{
  public interface IEntryExporter
  {
    string ExportEntries(IEnumerable<Entry> entries);
  }
}