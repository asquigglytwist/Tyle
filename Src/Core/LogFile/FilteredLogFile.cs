using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Prefs
{
    public class FilteredLogFile : LogFileStream
    {
        List<LogEntry> filteredLogEntries;

        public FilteredLogFile(string filePath)
            : base(filePath)
        {
            filteredLogEntries = new List<LogEntry>();
        }
    }
}
