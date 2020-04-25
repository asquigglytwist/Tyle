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
        static List<HighlightConfig> SensitiveList;        // [TIP]:  Change your toothpase
        static List<HighlightConfig> InSensitiveList;  // [TIP]:  Learn some manners, will ya?

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

        public HighlightConfig(string pattern, bool ignoreCase, bool bold, bool italic,
            bool underline, bool strikeout, Color foreGround, Color backGround)
        {
            Pattern = pattern;
            IgnoreCase = ignoreCase;
            Bold = bold;
            Italic = italic;
            Underline = underline;
            Strikeout = strikeout;
            ForeGround = foreGround;
            BackGround = backGround;
        }
    }
}
