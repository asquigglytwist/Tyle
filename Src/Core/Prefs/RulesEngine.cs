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

        public static Rule TryGetRuleFor(LogEntry entry)
        {
            return Rules.Find(c => c.DoesLineMatch(entry.Line));
        }

        public static List<FilteredLogEntry> FilterLogEntries(List<LogEntry> rawLogEntries)
        {
            var filteredLogEntries = new List<FilteredLogEntry>();
            lock (Rules)
            {
                //var itrRules = new Queue<Rule>(Rules);
                for (int i = 0; i < rawLogEntries.Count; i++)
                {
                    var entry = rawLogEntries[i];
                    var match = Rules.Find(r => r.DoesLineMatch(entry.Line));
                    if (match != null)
                    {
                        if (match.IsAnExcludeFilter)
                        {
                            continue;
                        }
                        entry.MatchingRule = match;
                    }
                    filteredLogEntries.Add(new FilteredLogEntry(entry, i));
                }
            }
            return filteredLogEntries;
        }
    }
}
