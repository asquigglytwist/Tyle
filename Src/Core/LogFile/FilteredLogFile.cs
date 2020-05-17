using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Code
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
