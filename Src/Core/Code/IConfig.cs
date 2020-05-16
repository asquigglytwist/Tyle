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

        public virtual bool DoesLineMatch(string line)
        {
            if (IsRegex)
            {
                throw new NotImplementedException($"{nameof(IsRegex)} is not supported, yet...");
            }
            if (IgnoreCase)
            {
                // [BIB]:  https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings
                return line.IndexOf(Pattern, StringComparison.OrdinalIgnoreCase) > -1;
            }
            return line.Contains(Pattern);
        }
    }
}
