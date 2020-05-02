using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyle.UI
{
    #region TailListView
    class TailListView : System.Windows.Forms.ListView
    {
        const TextFormatFlags TFFlags = TextFormatFlags.Left | TextFormatFlags.ExpandTabs | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix;

        public TailListView() : base()
        {
            DoubleBuffered = true;
            VirtualMode = true;
            View = System.Windows.Forms.View.Details;
            FullRowSelect = true;
            Dock = System.Windows.Forms.DockStyle.Fill;
            ShowGroups = false;
            ShowItemToolTips = true;
            GridLines = true;
            HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            Columns.Add("LineNumber", -1, System.Windows.Forms.HorizontalAlignment.Left);
            Columns.Add("Line", -1, System.Windows.Forms.HorizontalAlignment.Left);
            LabelWrap = true;
            ShowGroups = false;
            OwnerDraw = true;
            DrawSubItem += TailListView_DrawSubItem;
        }

        private void TailListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.SubItem.BackColor = SystemColors.Highlight;
                e.SubItem.ForeColor = SystemColors.HighlightText;
            }
            // Draw the standard header background.
            e.DrawBackground();
            e.DrawFocusRectangle(e.Bounds);
            System.Windows.Forms.TextRenderer.DrawText(e.Graphics, e.SubItem.Text, Font, e.Bounds, e.SubItem.ForeColor, TFFlags);
        }

        public void AutoFitColumnsToContent(string longestLine, Font currentFont)
        {
            int longLineMaxWidth = (int)System.Math.Ceiling(MeasureString(longestLine).Width + 50f);
            Columns[0].Width = -2;
            Columns[1].Width = (Columns[1].Width < longLineMaxWidth ? longLineMaxWidth : Columns[1].Width);
        }

        public void SelectVirtualItem(int index)
        {
            SelectedIndices.Clear();
            if (index > -1)
            {
                SelectedIndices.Add(index);
                EnsureVisible(index);
                Items[index].Focused = true;
            }
            Focus();
        }

        protected SizeF MeasureString(string stringToMeasure)
        {
            // [BIB]:  https://stackoverflow.com/a/6705023
            SizeF measuredSize;
            using (Graphics g = this.CreateGraphics())
            {
                measuredSize = g.MeasureString(stringToMeasure, Font);
            }
            return measuredSize;
        }

        public int SearchBeginIndex
        {
            get
            {
                if (FocusedItem == null)
                {
                    return 0;
                }
                return ((FocusedItem.Index + 1) % VirtualListSize);
            }
        }
    }
    #endregion
}
