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
        // [TIP]:  Learn some manners, will ya?
        static readonly List<HighlightConfig> HighlightConfigList;

        static HighlightsHandler()
        {
            HighlightConfigList = new List<HighlightConfig>();
        }

        public static void Add(HighlightConfig config)
        {
            HighlightConfigList.Add(config);
        }

        public static void Remove(int index)
        {
            var count = HighlightConfigList.Count;
            if (count > 0 && index > 0 && count < index)
            {
                HighlightConfigList.RemoveAt(index);
            }
            var exMsg = $"Index {index} out of range for {nameof(HighlightConfigList)} with {count} items.";
            throw new IndexOutOfRangeException(exMsg);
        }

        public static HighlightConfig? TryGetConfigFor(string line)
        {
            var temp = HighlightConfigList.FindIndex(
                c => line.IndexOf(c.Pattern, StringComparison.CurrentCultureIgnoreCase) > -1);
            if(temp >= 0)
            {
                return HighlightConfigList[temp];
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
            DisplayFont = new Font(displayFont, style);
        }
    }
}
