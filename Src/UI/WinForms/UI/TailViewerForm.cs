using Core.Code;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Tyle.UI
{
    #region TailViewerForm
    public partial class TailViewerForm : TyleFormBase
    {
        #region Fields
        readonly MainForm MainForm;
        readonly TailedStream tailedFile;
        #endregion

        public TailViewerForm(MainForm mdiParentForm, string fileToTail)
        {
            Hide();
            InitializeComponent();
            MdiParent = MainForm = mdiParentForm;
            Text = Path.GetFileName(fileToTail);
            WindowState = FormWindowState.Maximized;
            tailedFile = new TailedStream(fileToTail, TailedFile_OnTailedFileChanged);
            Show();
#if DEBUG
            var hi = new HighlightConfig("Hi", false, true, true, true, true,
                Color.Green, Color.AliceBlue, lsvTailViewer.Font);
            var hello = new HighlightConfig("hello", true, false, true, true, true,
                Color.DarkSeaGreen, Color.Aquamarine, lsvTailViewer.Font);
            var yo = new HighlightConfig("yo!", true, false, true, true, true,
                Color.Red, Color.LightGoldenrodYellow, lsvTailViewer.Font);
            var yoyo = new HighlightConfig("yoyo", true, true, true, true, false,
                Color.Green, Color.Navy, lsvTailViewer.Font);
            HighlightsHandler.Add(hi);
            HighlightsHandler.Add(hello);
            HighlightsHandler.Add(yo);
            HighlightsHandler.Add(yoyo);
#endif
        }

        private void TailedFile_OnTailedFileChanged(object sender, TailedFileChangedArgs args)
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

        protected void UpdateTailView()
        {
            int lineCount = tailedFile.LineCount;
            MainForm.NotifyFileUpdate(Text);
            lsvTailViewer.VirtualListSize = lineCount;
            lsvTailViewer.AutoFitColumnsToContent(tailedFile.LongestLine, lsvTailViewer.Font);
            lsvTailViewer.SelectVirtualItem(tailedFile.LineCount - 1);
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

        #region EventHandlers
        private void lsvTailViewer_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var lineToDisplay = tailedFile[e.ItemIndex];
            e.Item = new ListViewItem((e.ItemIndex + 1).ToString())
            {
                UseItemStyleForSubItems = false,
                ToolTipText = lineToDisplay
            };
            var matchingConfig = HighlightsHandler.TryGetConfigFor(lineToDisplay);
            if (matchingConfig.HasValue)
            {
                var cfg = matchingConfig.Value;
                e.Item.SubItems.Add(lineToDisplay, cfg.ForeGround, cfg.BackGround, cfg.DisplayFont);
            }
            else
            {
                e.Item.SubItems.Add(lineToDisplay, Color.Black, Color.White, lsvTailViewer.Font);
            }
        }

        private void frmTailViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MainForm.NotifyStoppedTailing(tailedFile.TailedFilePath, Text);
            }
            catch (Exception)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show(string.Format("Unable to close:{0}{1}{0}Would you like to cancel closure and continue tailing?", Environment.NewLine, tailedFile.TailedFilePath), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void mnuECopy_Click(object sender, EventArgs e)
        {
            var buffer = new StringBuilder();
            foreach (int selIndex in lsvTailViewer.SelectedIndices)
            {
                buffer.AppendLine(tailedFile[selIndex]);
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
                if(FindNextItem())
                {
                    if(!mnuEFindNext.Enabled)
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
            if(!FindNextItem())
            {
                //TODO:  Visual cue (or auditory)
            }
        }

        private void mnuEFindPrev_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
    #endregion
}
