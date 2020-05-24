using Core.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.LogFile
{
    public class LogEntry
    {
        public LogEntry(string line)
        {
            Line = line;
        }

        public string Line
        { get; private set; }
    }

    public class FilteredLogEntry : LogEntry
    {
        public FilteredLogEntry(LogEntry entry, int srcLineNumber) : base(entry?.Line)
        {
            SourceLineNumber = srcLineNumber;
            MatchingRule = null;
        }

        public readonly int SourceLineNumber;
        //{ get; private set; }

        public Rule MatchingRule
        { get; set; }
    }
}
