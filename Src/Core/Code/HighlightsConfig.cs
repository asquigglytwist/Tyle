using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Code
{
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
