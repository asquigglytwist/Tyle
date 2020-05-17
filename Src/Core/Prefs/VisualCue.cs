using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Code
{
    #region VisualCue
    /// <summary>
    /// Represents the VisualCue / Decoration for a matched <see cref="LogEntry"/>
    /// </summary>
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

        #region Constructor(s)
        /// <summary>
        /// Static constructor for <see cref="VisualCue"/>; Initializes <see cref="_VisCueForUnDecorated"/> with <see cref="SystemFonts.DefaultFont"/>
        /// </summary>
        static VisualCue()
        {
            DefaultDecoration = new VisualCue(SystemFonts.DefaultFont);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VisualCue"/>
        /// </summary>
        /// <param name="bold"><inheritdoc cref="Bold"/></param>
        /// <param name="italic"><inheritdoc cref="Italic"/></param>
        /// <param name="underline"><inheritdoc cref="Underline"/></param>
        /// <param name="strikeout"><inheritdoc cref="Strikeout"/></param>
        /// <param name="foreGround"><inheritdoc cref="ForeGround"/></param>
        /// <param name="backGround"><inheritdoc cref="BackGround"/></param>
        /// <param name="displayFont"><inheritdoc cref="DisplayFont"/></param>
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

        /// <summary>
        /// <inheritdoc cref="VisualCue.VisualCue"/> with all styling disabled
        /// </summary>
        /// <param name="unDecoratedFont">Font to be used for all UnDecorated <see cref="LogEntry"/></param>
        protected VisualCue(Font unDecoratedFont)
            : this(false, false, false, false, SystemColors.ControlText, SystemColors.Control, unDecoratedFont)
        {
        }
        #endregion // Constructor

        public static void UpdateFontForUnDecoratedEntries(Font undecoratedFont)
        {
            DefaultDecoration = new VisualCue(undecoratedFont);
        }

        /// <summary>
        /// <see cref="VisualCue"/> instance for all UnDecorated <see cref="LogEntry"/>
        /// </summary>
        public static VisualCue DefaultDecoration
        { get; private set; }
    }
    #endregion // VisualCue
}
