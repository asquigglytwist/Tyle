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
}
