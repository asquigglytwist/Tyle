using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Code
{
    public class Rule
    {
        public readonly string UniqueID;
        public readonly string Pattern;
        public readonly bool IgnoreCase;
        public readonly bool IsRegex;
#if COMPILED_REGEX_FOR_CONFIG
        protected readonly Regex rxPattern;
#endif
        public readonly VisualCue Decoration;

        protected Rule(string pattern, bool ignoreCase = true, bool isRegex = false)
        {
            UniqueID = Guid.NewGuid().ToString("N").ToLowerInvariant();
            Pattern = pattern;
            IgnoreCase = ignoreCase;
            IsRegex = isRegex;
#if COMPILED_REGEX_FOR_CONFIG
            if (isRegex)
            {
                RegexOptions rxOpt = RegexOptions.Compiled;
                if (ignoreCase)
                {
                    rxOpt |= RegexOptions.IgnoreCase;
                }
                rxPattern = new Regex(Pattern, rxOpt);
            }
#endif
        }

        public Rule(string pattern, bool ignoreCase, bool isRegex,
            bool bold, bool italic, bool underline, bool strikeout,
            Color foreGround, Color backGround,
            Font displayFont)
            : this(pattern, ignoreCase, isRegex)
        {
            Decoration = new VisualCue(bold, italic, underline, strikeout,
                foreGround, backGround, displayFont);
        }

        protected virtual bool DoesLineMatch(string line)
        {
            if (IsRegex)
            {
#if COMPILED_REGEX_FOR_CONFIG
                return rxPattern.IsMatch(line);
#else
                if (IgnoreCase)
                {
                    return Regex.IsMatch(line, Pattern, RegexOptions.IgnoreCase);
                }
                return Regex.IsMatch(line, Pattern);
#endif
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
