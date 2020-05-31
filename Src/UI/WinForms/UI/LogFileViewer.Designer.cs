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
            this.MnuTailForm = new System.Windows.Forms.MenuStrip();
            this.MnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuECopy = new System.Windows.Forms.ToolStripMenuItem();
            this.TssAfterCopy = new System.Windows.Forms.ToolStripSeparator();
            this.MnuEFind = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuEFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.LsvTailViewer = new Tyle.UI.TailListView();
            this.MnuTailForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuTailForm
            // 
            this.MnuTailForm.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MnuTailForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuTailForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuEdit});
            this.MnuTailForm.Location = new System.Drawing.Point(0, 0);
            this.MnuTailForm.Name = "mnuTailForm";
            this.MnuTailForm.Size = new System.Drawing.Size(800, 33);
            this.MnuTailForm.TabIndex = 2;
            this.MnuTailForm.Text = "mnuTail";
            this.MnuTailForm.Visible = false;
            // 
            // mnuEdit
            // 
            this.MnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuECopy,
            this.TssAfterCopy,
            this.MnuEFind,
            this.MnuEFindNext});
            this.MnuEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.MnuEdit.MergeIndex = 1;
            this.MnuEdit.Name = "mnuEdit";
            this.MnuEdit.Size = new System.Drawing.Size(58, 29);
            this.MnuEdit.Text = "&Edit";
            // 
            // mnuECopy
            // 
            this.MnuECopy.Name = "mnuECopy";
            this.MnuECopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MnuECopy.Size = new System.Drawing.Size(220, 34);
            this.MnuECopy.Text = "&Copy";
            this.MnuECopy.Click += new System.EventHandler(this.MnuECopy_Click);
            // 
            // tssAfterCopy
            // 
            this.TssAfterCopy.Name = "tssAfterCopy";
            this.TssAfterCopy.Size = new System.Drawing.Size(217, 6);
            // 
            // mnuEFind
            // 
            this.MnuEFind.Name = "mnuEFind";
            this.MnuEFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MnuEFind.Size = new System.Drawing.Size(220, 34);
            this.MnuEFind.Text = "&Find";
            this.MnuEFind.Click += new System.EventHandler(this.MnuEFind_Click);
            // 
            // mnuEFindNext
            // 
            this.MnuEFindNext.Enabled = false;
            this.MnuEFindNext.Name = "mnuEFindNext";
            this.MnuEFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.MnuEFindNext.Size = new System.Drawing.Size(220, 34);
            this.MnuEFindNext.Text = "Find &Next";
            this.MnuEFindNext.Click += new System.EventHandler(this.MnuEFindNext_Click);
            // 
            // lsvTailViewer
            // 
            this.LsvTailViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LsvTailViewer.FullRowSelect = true;
            this.LsvTailViewer.GridLines = true;
            this.LsvTailViewer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LsvTailViewer.HideSelection = false;
            this.LsvTailViewer.Location = new System.Drawing.Point(0, 0);
            this.LsvTailViewer.Name = "lsvTailViewer";
            this.LsvTailViewer.OwnerDraw = true;
            this.LsvTailViewer.ShowGroups = false;
            this.LsvTailViewer.ShowItemToolTips = true;
            this.LsvTailViewer.Size = new System.Drawing.Size(800, 450);
            this.LsvTailViewer.TabIndex = 3;
            this.LsvTailViewer.UseCompatibleStateImageBehavior = false;
            this.LsvTailViewer.View = System.Windows.Forms.View.Details;
            this.LsvTailViewer.VirtualMode = true;
            this.LsvTailViewer.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.LsvTailViewer_RetrieveVirtualItem);
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LsvTailViewer);
            this.Controls.Add(this.MnuTailForm);
            this.Name = "LogFileViewer";
            this.Text = "LogFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileViewer_FormClosing);
            this.MnuTailForm.ResumeLayout(false);
            this.MnuTailForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuTailForm;
        private System.Windows.Forms.ToolStripMenuItem MnuEdit;
        private System.Windows.Forms.ToolStripMenuItem MnuECopy;
        private System.Windows.Forms.ToolStripSeparator TssAfterCopy;
        private System.Windows.Forms.ToolStripMenuItem MnuEFind;
        private System.Windows.Forms.ToolStripMenuItem MnuEFindNext;
        private TailListView LsvTailViewer;
    }
}