namespace Tyle.UI
{
    partial class LogFileViewer
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                tailedFile.Dispose();
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
            this.lsvTailViewer = new Tyle.UI.TailListView();
            this.mnuTailForm.SuspendLayout();
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
            this.mnuTailForm.Size = new System.Drawing.Size(800, 33);
            this.mnuTailForm.TabIndex = 2;
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
            this.mnuEdit.Size = new System.Drawing.Size(58, 29);
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
            // lsvTailViewer
            // 
            this.lsvTailViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTailViewer.FullRowSelect = true;
            this.lsvTailViewer.GridLines = true;
            this.lsvTailViewer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvTailViewer.HideSelection = false;
            this.lsvTailViewer.Location = new System.Drawing.Point(0, 0);
            this.lsvTailViewer.Name = "lsvTailViewer";
            this.lsvTailViewer.OwnerDraw = true;
            this.lsvTailViewer.ShowGroups = false;
            this.lsvTailViewer.ShowItemToolTips = true;
            this.lsvTailViewer.Size = new System.Drawing.Size(800, 450);
            this.lsvTailViewer.TabIndex = 3;
            this.lsvTailViewer.UseCompatibleStateImageBehavior = false;
            this.lsvTailViewer.View = System.Windows.Forms.View.Details;
            this.lsvTailViewer.VirtualMode = true;
            this.lsvTailViewer.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.LsvTailViewer_RetrieveVirtualItem);
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsvTailViewer);
            this.Controls.Add(this.mnuTailForm);
            this.Name = "LogFileViewer";
            this.Text = "LogFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileViewer_FormClosing);
            this.mnuTailForm.ResumeLayout(false);
            this.mnuTailForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTailForm;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuECopy;
        private System.Windows.Forms.ToolStripSeparator tssAfterCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEFind;
        private System.Windows.Forms.ToolStripMenuItem mnuEFindNext;
        private TailListView lsvTailViewer;
    }
}