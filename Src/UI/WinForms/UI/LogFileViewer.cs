using Core.LogFile;
using Core.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyle.Utils;

namespace Tyle.UI
{
    public partial class LogFileViewer : TyleFormBase
    {
        readonly LogFileStream tailedFile;
        private readonly MainForm MainForm;

        public LogFileViewer(MainForm mdiParentForm, string fileToTail, bool tail = false)
        {
            Hide();
            InitializeComponent();
            TailedStream.TailedFileChangedHandler tailedFileChanged = null;
            if (tail)
            {
                tailedFileChanged = TailedFile_OnTailedFileChanged;
            }
            tailedFile = LogStreamFactory.GetStreamFor(fileToTail, tailedFileChanged);
            Text = tailedFile.FileName;
            MdiParent = MainForm = mdiParentForm;
            WindowState = FormWindowState.Maximized;
            tailedFile.IsInFilterMode = false;
            UpdateTailView();
            Show();
        }

        protected void UpdateTailView()
        {
            int lineCount = tailedFile.LineCount;
            MainForm.NotifyFileUpdate(Text);
            LsvTailViewer.VirtualListSize = lineCount;
            LsvTailViewer.AutoFitColumnsToContent(tailedFile.LongestLine, LsvTailViewer.Font);
            LsvTailViewer.SelectVirtualItem(lineCount - 1);
            // [BIB]:  https://stackoverflow.com/a/30104935
            LsvTailViewer.Refresh();
        }

        protected bool FindNextItem()
        {
            if (LsvTailViewer.VirtualListSize > 0)
            {
                var foundItemIndex = tailedFile.FindItem(FindDialog.findDialog.SearchText, LsvTailViewer.SearchBeginIndex, FindDialog.findDialog.WrapSearch);
                if (foundItemIndex != -1)
                {
                    LsvTailViewer.SelectVirtualItem(foundItemIndex);
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
            LsvTailViewer.Font = selFont;
        }

        private void TailedFile_OnTailedFileChanged(object sender, TailedFileChangedEventArgs args)
        {
            switch (args.ChangeType)
            {
                case TailedFileChangeType.InitialReadComplete:
                case TailedFileChangeType.LastLineExtended:
                case TailedFileChangeType.LinesAdded:
                case TailedFileChangeType.Shrunk:
                    // [BIB]:  https://stackoverflow.com/a/661662
                    Invoke((MethodInvoker)delegate { UpdateTailView(); });
                    break;
                case TailedFileChangeType.Renamed:
                    MessageBox.Show("File has been Renamed.");
                    break;
                case TailedFileChangeType.Deleted:
                    MessageBox.Show("File has been deleted.");
                    break;
                case TailedFileChangeType.NoContentChange:
                default:
                    break;
            }
        }

        private void MnuECopy_Click(object sender, EventArgs e)
        {
            var buffer = new StringBuilder();
            foreach (int selIndex in LsvTailViewer.SelectedIndices)
            {
                buffer.AppendLine(tailedFile[selIndex].Line);
            }
            var temp = buffer.ToString();
            if (temp.Length > 0)
            {
                Clipboard.SetText(temp);
            }
        }

        private void MnuEFind_Click(object sender, EventArgs e)
        {
            if (FindDialog.findDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (FindNextItem())
                {
                    if (!MnuEFindNext.Enabled)
                    {
                        MnuEFindNext.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(FindDialog.findDialog.SearchText, "Unable to find string searched for", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void MnuEFindNext_Click(object sender, EventArgs e)
        {
        }

        private void LsvTailViewer_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int lineNumber = e.ItemIndex;
            var entryToDisplay = tailedFile[lineNumber];
            e.Item = entryToDisplay.ToListViewItem(lineNumber, tailedFile.IsInFilterMode);
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
