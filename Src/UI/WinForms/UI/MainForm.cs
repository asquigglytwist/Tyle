using Core.Rules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyle.Core;

namespace Tyle.UI
{
    public partial class MainForm : TyleFormBase
    {
        //private Dictionary<string, TailViewerForm> mapOpenFiles;
        private Dictionary<string, LogFileViewer> mapOpenFiles;
        private Font fontForListView;

        public MainForm()
        {
            InitializeComponent();
            MnuFExit.ToolTipText = $"Quit {AppMetaData.ApplicationName}{Environment.NewLine}(Closes all files open for viewing)";
#if DEBUG
            DlgOpenFile.CheckFileExists = false;
            DlgOpenFile.CheckPathExists = false;
#endif
            Icon = Properties.Resources.Tyle;
            Text = AppMetaData.ApplicationName;
            fontForListView = this.Font;
            ResetAppState();
            // [BIB]:  https://stackoverflow.com/questions/1792470/subset-of-array-in-c-sharp
            OpenFilesForTailing(Environment.GetCommandLineArgs().Skip(1).ToArray());
        }

        private void ResetAppState()
        {
            mapOpenFiles?.Clear();
            mapOpenFiles = new Dictionary<string, LogFileViewer>();
            Preferences.Load();
#if DEBUG
            var exclude = new Rule("Exclude", true, false, true);
            var interesting = new Rule("interesting", false, false, true, true, false, false, Color.Crimson, Color.AliceBlue, this.Font);
            var boring = new Rule("Boring", true, false, true, true, false, false, Color.LimeGreen, Color.Navy, this.Font);
            RulesEngine.Rules.Add(exclude);
            RulesEngine.Rules.Add(interesting);
            RulesEngine.Rules.Add(boring);
#endif
        }

        private void OpenFilesForTailing(string[] fileNames)
        {
#if DEBUG
            foreach (string file in fileNames)
#else
            System.Threading.Tasks.Parallel.ForEach(fileNames, file =>
#endif
            {
                var temp = file.ToLower();
                if (mapOpenFiles.ContainsKey(temp))
                {
                    mapOpenFiles[temp]?.ActivateAndMaximize();
                }
                else
                {
                    var tailForm = new LogFileViewer(this, file, true);
                    tailForm.SetLSVFont(fontForListView);
                    mapOpenFiles[temp] = tailForm;
                    var newPage = new TabPage(tailForm.Text)
                    {
                        ToolTipText = file
                    };
                    TbcMDIChildren.TabPages.Add(newPage);
                    TbcMDIChildren.SelectedTab = newPage;
                    TbcMDIChildren.Show();
                }
#if DEBUG
            }
#else
            });
#endif
        }

        public void NotifyStoppedTailing(string fileName, string title)
        {
            mapOpenFiles.Remove(fileName.ToLower());
            foreach (TabPage page in TbcMDIChildren.TabPages)
            {
                if (page.Text.Equals(title))
                {
                    TbcMDIChildren.TabPages.Remove(page);
                    break;
                }
            }
            if (TbcMDIChildren.TabPages.Count < 1)
            {
                TbcMDIChildren.Hide();
            }
        }

        public void NotifyFileUpdate(string title)
        {
            foreach (TabPage page in TbcMDIChildren.TabPages)
            {
                if (page.Text.Equals(title))
                {
                    page.ImageKey = "NewLinesFound.png";
                    break;
                }
            }
        }

        #region MenuEventHandlers
        private void MnuFOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == DlgOpenFile.ShowDialog())
            {
                OpenFilesForTailing(DlgOpenFile.FileNames);
            }
        }

        private void MnuFClose_Click(object sender, EventArgs e)
        {
            ActiveMdiChild?.Close();
        }

        private void MnuFExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnuFCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }
        }

        private void MnuWCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MnuWTileHorizontally_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuWTileVertically_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuWArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        #endregion

        #region EventHandlers
        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            var temp = (ActiveMdiChild as LogFileViewer)?.Text;
            foreach (TabPage page in TbcMDIChildren.TabPages)
            {
                if (page.Text.Equals(temp))
                {
                    TbcMDIChildren.SelectedTab = page;
                    break;
                }
            }
        }

        private void TbcMDIChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbcMDIChildren.SelectedTab != null && mapOpenFiles.TryGetValue(TbcMDIChildren.SelectedTab.ToolTipText.ToLower(), out LogFileViewer childForm))
            {
                childForm.Activate();
            }
        }

        private void MnuHAabout_Click(object sender, EventArgs e)
        {
            AboutBox.AppAbout.ShowDialog();
        }

        private void MnuPHighlighting_Click(object sender, EventArgs e)
        {
            Highlighter.ShowAsDialog(this);
        }

        private void MnuPFont_Click(object sender, EventArgs e)
        {
            if (DlgFontForLSV.ShowDialog() == DialogResult.OK)
            {
                var selFont = DlgFontForLSV.Font;
                if (selFont != fontForListView)
                {
                    foreach (var openFile in mapOpenFiles.Values)
                    {
                        openFile.SetLSVFont(selFont);
                    }
                    VisualCue.UpdateDecorationForUnMatchedLogEntries(null, null, selFont);
                }
                fontForListView = selFont;
            }
        }
        #endregion // EventHandlers
    }
}
