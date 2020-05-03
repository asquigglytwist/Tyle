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
        static readonly List<HighlightConfig> HighlightConfigMap;

        static HighlightsHandler()
        {
            HighlightConfigMap = new List<HighlightConfig>();
        }

        public static void Add(HighlightConfig config)
        {
            lock (HighlightConfigMap)
            {
                HighlightConfigMap.Add(config);
            }
        }

        public static void Remove(string uniqueID)
            => Remove(HighlightConfigMap.FindIndex(x => x.UniqueID.Equals(uniqueID)));

        public static void Remove(int index)
        {
            lock (HighlightConfigMap)
            {
                var count = HighlightConfigMap.Count;
                if (count > 0 && index > 0 && count < index)
                {
                    HighlightConfigMap.RemoveAt(index);
                }
            }
            var exMsg = $"Index {index} out of range for {nameof(HighlightConfigMap)} with {HighlightConfigMap.Count} items.";
            throw new IndexOutOfRangeException(exMsg);
        }

        public static List<HighlightConfig> AllConfigs
        {
            get
            {
                return HighlightConfigMap;
            }
        }

        public static HighlightConfig? TryGetConfigFor(string line)
        {
            var temp = HighlightConfigMap.FindIndex(
                c => line.IndexOf(c.Pattern, StringComparison.CurrentCultureIgnoreCase) > -1);
            if(temp >= 0)
            {
                return HighlightConfigMap[temp];
            }
            return null;
        }
    }

    public struct HighlightConfig
    {
        public readonly string UniqueID;
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
            UniqueID = Guid.NewGuid().ToString("N").ToLowerInvariant();
        }
    }
}
