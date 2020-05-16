using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Code
{
    public enum ConfigAction
    {
        Highlight,
        Filter,
        React
    }

    public abstract class IConfig
    {
        public readonly string UniqueID;
        public readonly string Pattern;
        public readonly bool IgnoreCase;
        public readonly bool IsRegex;
        public readonly ConfigAction Action;

        public IConfig(string pattern)
        {
            UniqueID = Guid.NewGuid().ToString("N").ToLowerInvariant();
            Pattern = pattern;
        }

        public abstract bool DoesLineMatch(string line);
    }
}
