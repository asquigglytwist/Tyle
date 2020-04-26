using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyle.Core
{
    public static class HighlightsHandler
    {
        // [TIP]:  We aren't talking about tooth or toothpaste; But, if you don't believe me, you can take it with a pinch of salt!!
        static readonly List<HighlightConfig> SensitiveList;
        // [TIP]:  Learn some manners, will ya?
        static readonly List<HighlightConfig> InSensitiveList;

        static HighlightsHandler()
        {
            SensitiveList = new List<Core.HighlightConfig>();
            InSensitiveList = new List<HighlightConfig>();
        }

        public static void Add(HighlightConfig config)
        {
            if(config.IgnoreCase)
            {
                InSensitiveList.Add(config);
            }
            else
            {
                SensitiveList.Add(config);
            }
        }

        public static HighlightConfig? TryGetConfigFor(string line)
        {
            var temp = InSensitiveList.FindIndex(c => line.IndexOf(c.Pattern, StringComparison.CurrentCultureIgnoreCase) > -1);
            if(temp >= 0)
            {
                return InSensitiveList[temp];
            }
            temp = SensitiveList.FindIndex(c => line.Contains(c.Pattern));
            if (temp >= 0)
            {
                return SensitiveList[temp];
            }
            return null;
        }
    }

    public struct HighlightConfig
    {
        public readonly string Pattern;
        public readonly bool IgnoreCase, Bold, Italic, Underline, Strikeout;
        public readonly Color ForeGround, BackGround;
        public readonly Font DisplayFont;

        public HighlightConfig(string pattern, bool ignoreCase,
            bool bold, bool italic, bool underline, bool strikeout,
            Color foreGround, Color backGround,
            Font displayFont)
        {
            Pattern = pattern;
            IgnoreCase = ignoreCase;
            Bold = bold;
            Italic = italic;
            Underline = underline;
            Strikeout = strikeout;
            ForeGround = foreGround;
            BackGround = backGround;
            FontStyle style = FontStyle.Regular
                | (bold ? FontStyle.Bold : FontStyle.Regular)
                | (italic ? FontStyle.Italic : FontStyle.Regular)
                | (underline ? FontStyle.Underline : FontStyle.Regular)
                | (strikeout ? FontStyle.Strikeout : FontStyle.Regular);
            //DisplayFont = new Font("Verdana", 14, style);
            DisplayFont = new Font(displayFont, style);
        }
    }
}
