using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Prefs
{
    public class LogEntry
    {
        public LogEntry(string line)
        {
            Line = line;
            MatchingRule = null;
        }

        public string Line
        { get; private set; }

        public Rule MatchingRule
        { get; set; }
    }

    public class FilteredLogEntry : LogEntry
    {
        public FilteredLogEntry(LogEntry entry, int srcLineNumber) : base(entry.Line)
        {
            SourceLineNumber = srcLineNumber;
        }

        public readonly int SourceLineNumber;
        //{ get; private set; }
    }
}
