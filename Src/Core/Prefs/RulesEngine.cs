using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Prefs
{
    public static class RulesEngine
    {
        #region Properties
        /// <summary>
        /// <see cref="List{T}"/> of all <see cref="Rule"/>(s)
        /// </summary>
        public static List<Rule> Rules
        { get; set; }
        #endregion // Properties

        public static VisualCue TryGetDecorationFor(LogEntry entry)
        {
            return Rules.Find(c => c.DoesLineMatch(entry.Line))?.Decoration;
        }

        public static List<LogEntry> UpdateLogEntries(List<LogEntry> logEntries)
        {
            var filteredLogEntries = new List<LogEntry>();
            lock (Rules)
            {
                var itrRules = new Queue<Rule>(Rules);
                for (int i = 0; i < logEntries.Count; i++)
                {
                    var entry = logEntries[i];
                    var match = Rules.Find(r => r.DoesLineMatch(entry.Line));
                    if (match != null)
                    {
                        if (match.IsAnExcludeFilter)
                        {
                            continue;
                        }
                        entry.MatchingRule = match;
                    }
                    filteredLogEntries.Add(entry);
                }
            }
            return filteredLogEntries;
        }
    }
}
