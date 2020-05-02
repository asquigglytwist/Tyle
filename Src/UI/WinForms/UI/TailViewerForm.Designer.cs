using System.Drawing;

namespace Tyle.UI
{
    partial class TailViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (tailedFile != null)
            {
                tailedFile.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuTailForm = new System.Windows.Forms.MenuStrip();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuECopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterCopy = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.olvTailViewer = new BrightIdeasSoftware.FastObjectListView();
            this.olvColLineNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColLine = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.mnuTailForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTailViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuTailForm
            // 
            this.mnuTailForm.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuTailForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuTailForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit});
            this.mnuTailForm.Location = new System.Drawing.Point(0, 0);
            this.mnuTailForm.Name = "mnuTailForm";
            this.mnuTailForm.Size = new System.Drawing.Size(282, 28);
            this.mnuTailForm.TabIndex = 1;
            this.mnuTailForm.Text = "mnuTail";
            this.mnuTailForm.Visible = false;
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuECopy,
            this.tssAfterCopy,
            this.mnuEFind,
            this.mnuEFindNext});
            this.mnuEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuEdit.MergeIndex = 1;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(58, 24);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuECopy
            // 
            this.mnuECopy.Name = "mnuECopy";
            this.mnuECopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuECopy.Size = new System.Drawing.Size(220, 34);
            this.mnuECopy.Text = "&Copy";
            this.mnuECopy.Click += new System.EventHandler(this.mnuECopy_Click);
            // 
            // tssAfterCopy
            // 
            this.tssAfterCopy.Name = "tssAfterCopy";
            this.tssAfterCopy.Size = new System.Drawing.Size(217, 6);
            // 
            // mnuEFind
            // 
            this.mnuEFind.Name = "mnuEFind";
            this.mnuEFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEFind.Size = new System.Drawing.Size(220, 34);
            this.mnuEFind.Text = "&Find";
            this.mnuEFind.Click += new System.EventHandler(this.mnuEFind_Click);
            // 
            // mnuEFindNext
            // 
            this.mnuEFindNext.Enabled = false;
            this.mnuEFindNext.Name = "mnuEFindNext";
            this.mnuEFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuEFindNext.Size = new System.Drawing.Size(220, 34);
            this.mnuEFindNext.Text = "Find &Next";
            this.mnuEFindNext.Click += new System.EventHandler(this.mnuEFindNext_Click);
            // 
            // olvTailViewer
            // 
            this.olvTailViewer.AllColumns.Add(this.olvColLineNumber);
            this.olvTailViewer.AllColumns.Add(this.olvColLine);
            this.olvTailViewer.AutoArrange = false;
            this.olvTailViewer.CellEditUseWholeCell = false;
            this.olvTailViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColLineNumber,
            this.olvColLine});
            this.olvTailViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvTailViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvTailViewer.FullRowSelect = true;
            this.olvTailViewer.GridLines = true;
            this.olvTailViewer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.olvTailViewer.HideSelection = false;
            this.olvTailViewer.Location = new System.Drawing.Point(0, 0);
            this.olvTailViewer.Name = "olvTailViewer";
            this.olvTailViewer.ShowFilterMenuOnRightClick = false;
            this.olvTailViewer.ShowGroups = false;
            this.olvTailViewer.Size = new System.Drawing.Size(282, 253);
            this.olvTailViewer.SortGroupItemsByPrimaryColumn = false;
            this.olvTailViewer.TabIndex = 2;
            this.olvTailViewer.UseAlternatingBackColors = true;
            this.olvTailViewer.UseCompatibleStateImageBehavior = false;
            this.olvTailViewer.View = System.Windows.Forms.View.Details;
            this.olvTailViewer.VirtualMode = true;
            // 
            // olvColLineNumber
            // 
            this.olvColLineNumber.AspectName = "LineNumber";
            this.olvColLineNumber.AutoCompleteEditor = false;
            this.olvColLineNumber.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColLineNumber.Groupable = false;
            this.olvColLineNumber.Hideable = false;
            this.olvColLineNumber.IsEditable = false;
            this.olvColLineNumber.Searchable = false;
            this.olvColLineNumber.Sortable = false;
            this.olvColLineNumber.Text = "#";
            // 
            // olvColLine
            // 
            this.olvColLine.AspectName = "LogLine";
            this.olvColLine.AutoCompleteEditor = false;
            this.olvColLine.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColLine.FillsFreeSpace = true;
            this.olvColLine.Groupable = false;
            this.olvColLine.Hideable = false;
            this.olvColLine.IsEditable = false;
            this.olvColLine.MinimumWidth = 60;
            this.olvColLine.Sortable = false;
            this.olvColLine.Text = "Line";
            this.olvColLine.WordWrap = true;
            // 
            // TailViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.olvTailViewer);
            this.Controls.Add(this.mnuTailForm);
            this.MainMenuStrip = this.mnuTailForm;
            this.Name = "TailViewerForm";
            this.Text = "TailViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTailViewer_FormClosing);
            this.mnuTailForm.ResumeLayout(false);
            this.mnuTailForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTailViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private TailListView lsvTailViewer;
        private System.Windows.Forms.MenuStrip mnuTailForm;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuECopy;
        private System.Windows.Forms.ToolStripSeparator tssAfterCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEFind;
        private System.Windows.Forms.ToolStripMenuItem mnuEFindNext;
        private BrightIdeasSoftware.OLVColumn olvColLine;
        private BrightIdeasSoftware.OLVColumn olvColLineNumber;
        private BrightIdeasSoftware.FastObjectListView olvTailViewer;
    }

    #region TailListView
    class TailListView : System.Windows.Forms.ListView
    {
        public TailListView() : base()
        {
            DoubleBuffered = true;
            VirtualMode = true;
            View = System.Windows.Forms.View.Details;
            FullRowSelect = true;
            Dock = System.Windows.Forms.DockStyle.Fill;
            AutoArrange = false;
            //Font = new Font("Courier New", 12, FontStyle.Regular);
            ShowGroups = false;
            ShowItemToolTips = true;
            GridLines = true;
#if LINE_PRECEDES_LINENUMBER
            HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            Columns.Add("Line", -1, System.Windows.Forms.HorizontalAlignment.Left); 
            Columns.Add("LineNumber", -1, System.Windows.Forms.HorizontalAlignment.Left);
#else
            HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            Columns.Add("LineNumber", -1, System.Windows.Forms.HorizontalAlignment.Left);
            Columns.Add("Line", -1, System.Windows.Forms.HorizontalAlignment.Left);
#endif
            ColumnWidthChanged += TailListView_ColumnWidthChanged;
        }

        private void TailListView_ColumnWidthChanged(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e)
        {
#if !LINE_PRECEDES_LINENUMBER
            if (e.ColumnIndex == 1)
            {
                var total = this.Columns[0].Width + this.Columns[1].Width + 33;
                if (this.Width < total)
                {
                    this.Width = total;
                }
            }
#endif
        }

        public void AutoFitColumnsToContent(string longestLine)
        {
#if LINE_PRECEDES_LINENUMBER
            this.AutoResizeColumn(0, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
#else
            int longLineMaxWidth = (int)System.Math.Ceiling(MeasureString(longestLine).Width + 50f);
            Columns[0].Width = -2;
            Columns[1].Width = (Columns[1].Width < longLineMaxWidth ? longLineMaxWidth : Columns[1].Width);
#endif
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
                if(FocusedItem == null)
                {
                    return 0;
                }
                return ((FocusedItem.Index + 1) % VirtualListSize);
            }
        }
    }
    #endregion
}