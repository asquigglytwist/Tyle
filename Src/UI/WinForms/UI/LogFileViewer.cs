using Core.Prefs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyle.UI
{
    public partial class LogFileViewer : TyleFormBase
    {
        readonly LogFileStream tailedFile;
        private readonly MainForm MainForm;

        public LogFileViewer(MainForm mdiParentForm, string fileToTail)
        {
            Hide();
            InitializeComponent();
            tailedFile = new LogFileStream(fileToTail);
            Text = tailedFile.FileName;
            MdiParent = MainForm = mdiParentForm;
            WindowState = FormWindowState.Maximized;
            tailedFile.IsInFilterMode = true;
            UpdateTailView();
            Show();
        }

        protected void UpdateTailView()
        {
            int lineCount = tailedFile.LineCount;
            MainForm.NotifyFileUpdate(Text);
            lsvTailViewer.VirtualListSize = lineCount;
            lsvTailViewer.AutoFitColumnsToContent(tailedFile.LongestLine, lsvTailViewer.Font);
            lsvTailViewer.SelectVirtualItem(lineCount - 1);
            // [BIB]:  https://stackoverflow.com/a/30104935
            lsvTailViewer.Refresh();
        }

        protected bool FindNextItem()
        {
            if (lsvTailViewer.VirtualListSize > 0)
            {
                var foundItemIndex = tailedFile.FindItem(FindDialog.findDialog.SearchText, lsvTailViewer.SearchBeginIndex, FindDialog.findDialog.WrapSearch);
                if (foundItemIndex != -1)
                {
                    lsvTailViewer.SelectVirtualItem(foundItemIndex);
                    return true;
                }
            }
            return false;
        }

        internal void ActivateAndMaximize()
        {
            WindowState = FormWindowState.Maximized;
            Activate();
        }

        internal void SetLSVFont(Font selFont)
        {
            lsvTailViewer.Font = selFont;
        }

        private void mnuECopy_Click(object sender, EventArgs e)
        {
            var buffer = new StringBuilder();
            foreach (int selIndex in lsvTailViewer.SelectedIndices)
            {
                buffer.AppendLine(tailedFile[selIndex].Line);
            }
            var temp = buffer.ToString();
            if (temp.Length > 0)
            {
                Clipboard.SetText(temp);
            }
        }

        private void mnuEFind_Click(object sender, EventArgs e)
        {
            if (FindDialog.findDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (FindNextItem())
                {
                    if (!mnuEFindNext.Enabled)
                    {
                        mnuEFindNext.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(FindDialog.findDialog.SearchText, "Unable to find string searched for", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void mnuEFindNext_Click(object sender, EventArgs e)
        {
        }

        private void LsvTailViewer_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int lineNumber = e.ItemIndex;
            var entryToDisplay = tailedFile[lineNumber];
            string line = entryToDisplay.Line;
            if (tailedFile.IsInFilterMode)
            {
                lineNumber = (entryToDisplay as FilteredLogEntry).SourceLineNumber;
            }
            e.Item = new ListViewItem(lineNumber.ToString())
            {
                ForeColor = SystemColors.HighlightText,
                BackColor = SystemColors.Highlight,
                Checked = true,
                UseItemStyleForSubItems = false,
                ToolTipText = line
            };
            var cfg = RulesEngine.TryGetRuleFor(entryToDisplay)?.Decoration;
            if (cfg != null)
            {
                _ = e.Item.SubItems.Add(line, cfg.ForeGround, cfg.BackGround, cfg.DisplayFont);
            }
            else
            {
                _ = e.Item.SubItems.Add(line, lsvTailViewer.ForeColor, lsvTailViewer.BackColor, lsvTailViewer.Font);
            }
        }

        private void LogFileViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MainForm.NotifyStoppedTailing(tailedFile.FilePath, Text);
            }
        }
    }
}
