using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Code
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
}
