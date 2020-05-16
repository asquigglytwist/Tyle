using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
        protected readonly Regex rxPattern;

        public IConfig(string pattern, bool ignoreCase = true, bool isRegex = false)
        {
            UniqueID = Guid.NewGuid().ToString("N").ToLowerInvariant();
            Pattern = pattern;
            IgnoreCase = ignoreCase;
            IsRegex = isRegex;
            if (isRegex)
            {
                RegexOptions rxOpt = RegexOptions.Compiled;
                if (ignoreCase)
                {
                    rxOpt |= RegexOptions.IgnoreCase;
                }
                rxPattern = new Regex(Pattern, rxOpt);
            }
        }

        public virtual bool DoesLineMatch(string line)
        {
            if (IsRegex)
            {
                return rxPattern.IsMatch(line);
            }
            else
            {
                if (IgnoreCase)
                {
                    // [BIB]:  https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings
                    return line.IndexOf(Pattern, StringComparison.OrdinalIgnoreCase) > -1;
                }
                return line.Contains(Pattern);
            }
        }
    }
}
