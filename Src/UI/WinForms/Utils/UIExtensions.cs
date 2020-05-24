using Core.LogFile;
using Core.Rules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyle.Utils
{
    public static class UIExtensions
    {
        public static ListViewItem ToListViewItem(this LogEntry entryToDisplay,
            int lineNumber, bool isFilterMode)
        {
            string line = entryToDisplay.Line;
            if (isFilterMode)
            {
                lineNumber = (entryToDisplay as FilteredLogEntry).SourceLineNumber;
            }
            var lvi = new ListViewItem(lineNumber.ToString())
            {
                UseItemStyleForSubItems = false,
                ToolTipText = line
            };

            if (isFilterMode)
            {
                lvi.BackColor = SystemColors.HighlightText;
                lvi.ForeColor = SystemColors.Highlight;
            }
            var cfg = RulesEngine.TryGetRuleFor(entryToDisplay)?.Decoration;
            if (cfg != null)
            {
                _ = lvi.SubItems.Add(line, cfg.ForeGround, cfg.BackGround, cfg.DisplayFont);
            }
            else
            {
                _ = lvi.SubItems.Add(line);
                //_ = lvi.SubItems.Add(, SystemColors.ControlText, SystemColors.Control, SystemFonts.DefaultFont);
            }
            return lvi;
        }
    }
}
