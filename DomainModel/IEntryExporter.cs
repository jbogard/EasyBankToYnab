using System;
using System.Collections.Generic;

namespace QuestMaster.EasyBankRepository.DomainModel
{
  public interface IEntryExporter
  {
    string ExportEntries(IEnumerable<Entry> entries);
  }
}