using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Code
{
    /// <summary>
    /// Represents an individual Rule against which a <see cref="LogEntry"/> will be tested
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// An ID (<see cref="string"/>) to uniquely identify this instance of <see cref="Rule"/>
        /// </summary>
        public readonly string UniqueID;
        /// <summary>
        /// The Pattern (Needle) to be tested against
        /// </summary>
        public readonly string Pattern;
        /// <summary>
        /// Indicates Case-Sensitivity for the test against <see cref="Pattern"/>
        /// </summary>
        public readonly bool IgnoreCase;
        /// <summary>
        /// Indicates if the <see cref="Pattern"/> is a Regular Expression (<seealso cref="Regex"/>)
        /// </summary>
        public readonly bool IsRegex;
#if COMPILED_REGEX_FOR_CONFIG
        protected readonly Regex rxPattern;
#endif
        /// <summary>
        /// The <see cref="VisualCue"/> to be used when displaying any <see cref="LogEntry"/> that match this <see cref="Rule"/>
        /// </summary>
        public readonly VisualCue Decoration;

        /// <summary>
        /// Constructs a new <see cref="Rule"/>
        /// </summary>
        /// <param name="pattern"><inheritdoc cref="Pattern"/></param>
        /// <param name="ignoreCase"><inheritdoc cref="IgnoreCase"/></param>
        /// <param name="isRegex"><inheritdoc cref="IsRegex"/></param>
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

        /// <summary>
        /// <inheritdoc cref="Rule.Rule"/>
        /// </summary>
        /// <param name="pattern"><inheritdoc cref="Pattern"/></param>
        /// <param name="ignoreCase"><inheritdoc cref="IgnoreCase"/></param>
        /// <param name="isRegex"><inheritdoc cref="IsRegex"/></param>
        /// <param name="bold"><inheritdoc cref="VisualCue.Bold"/></param>
        /// <param name="italic"><inheritdoc cref="VisualCue.Italic"/></param>
        /// <param name="underline"><inheritdoc cref="VisualCue.Underline"/></param>
        /// <param name="strikeout"><inheritdoc cref="VisualCue.Strikeout"/></param>
        /// <param name="foreGround"><inheritdoc cref="VisualCue.ForeGround"/></param>
        /// <param name="backGround"><inheritdoc cref="VisualCue.BackGround"/></param>
        /// <param name="displayFont"><inheritdoc cref="VisualCue.DisplayFont"/></param>
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
