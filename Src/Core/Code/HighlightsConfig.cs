using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Code
{
    public class HighlightConfig : IConfig
    {
        public readonly bool Bold, Italic, Underline, Strikeout;
        public readonly Color ForeGround, BackGround;
        public readonly Font DisplayFont;

        public HighlightConfig(string pattern, bool ignoreCase, bool isRegex,
            bool bold, bool italic, bool underline, bool strikeout,
            Color foreGround, Color backGround,
            Font displayFont)
            : base(ConfigAction.Highlight, pattern, ignoreCase, isRegex)
        {
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
