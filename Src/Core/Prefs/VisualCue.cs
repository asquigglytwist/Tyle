using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Code
{
    #region VisualCue
    public class VisualCue
    {
        #region Fields
        /// <summary>
        /// Bold-style for the text
        /// </summary>
        public readonly bool Bold;
        /// <summary>
        /// Italicizes the text
        /// </summary>
        public readonly bool Italic;
        /// <summary>
        /// Underlines the text
        /// </summary>
        public readonly bool Underline;
        /// <summary>
        /// Strike-out the text
        /// </summary>
        public readonly bool Strikeout;
        /// <summary>
        /// The text color to be used
        /// </summary>
        public readonly Color ForeGround;
        /// <summary>
        /// Background color for the text
        /// </summary>
        public readonly Color BackGround;
        /// <summary>
        /// Font to be used for displaying the text
        /// </summary>
        public readonly Font DisplayFont;
        #endregion // Fields

        #region Constructor
        /// <summary>
        /// Creates a new instance of <see cref="VisualCue"/>
        /// </summary>
        /// <param name="bold">Bold style for the text</param>
        /// <param name="italic">Italicizes the text</param>
        /// <param name="underline">Underlines the text</param>
        /// <param name="strikeout">Strike-out the text</param>
        /// <param name="foreGround">Foreground color for the text</param>
        /// <param name="backGround">Background color for the text</param>
        /// <param name="displayFont">Font to be used for displaying the text</param>
        public VisualCue(bool bold, bool italic, bool underline, bool strikeout,
            Color foreGround, Color backGround, Font displayFont)
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
        #endregion // Constructor
    }
    #endregion // VisualCue
}
