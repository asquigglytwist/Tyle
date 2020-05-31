namespace Tyle.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StsMain = new System.Windows.Forms.StatusStrip();
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TssAfterOpen = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TssBeforeExit = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPrefs = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPHighlighting = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPFont = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWTileVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHAabout = new System.Windows.Forms.ToolStripMenuItem();
            this.DlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.TbcMDIChildren = new System.Windows.Forms.TabControl();
            this.ImlMainForm = new System.Windows.Forms.ImageList(this.components);
            this.DlgFontForLSV = new System.Windows.Forms.FontDialog();
            this.MnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsMain
            // 
            this.StsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StsMain.Location = new System.Drawing.Point(0, 565);
            this.StsMain.Name = "stsMain";
            this.StsMain.Size = new System.Drawing.Size(897, 22);
            this.StsMain.TabIndex = 1;
            this.StsMain.Text = "statusStrip1";
            // 
            // mnuMain
            // 
            this.MnuMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuPrefs,
            this.MnuWindows,
            this.MnuHelp});
            this.MnuMain.Location = new System.Drawing.Point(0, 0);
            this.MnuMain.MdiWindowListItem = this.MnuWindows;
            this.MnuMain.Name = "mnuMain";
            this.MnuMain.Size = new System.Drawing.Size(897, 33);
            this.MnuMain.TabIndex = 2;
            this.MnuMain.Text = "MainMenu";
            // 
            // mnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFOpen,
            this.TssAfterOpen,
            this.MnuFClose,
            this.MnuFCloseAll,
            this.TssBeforeExit,
            this.MnuFExit});
            this.MnuFile.Name = "mnuFile";
            this.MnuFile.Size = new System.Drawing.Size(54, 29);
            this.MnuFile.Text = "&File";
            // 
            // mnuFOpen
            // 
            this.MnuFOpen.Name = "mnuFOpen";
            this.MnuFOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MnuFOpen.Size = new System.Drawing.Size(298, 34);
            this.MnuFOpen.Text = "&Open";
            this.MnuFOpen.ToolTipText = "Open a new log file for viewing";
            this.MnuFOpen.Click += new System.EventHandler(this.MnuFOpen_Click);
            // 
            // tssAfterOpen
            // 
            this.TssAfterOpen.Name = "tssAfterOpen";
            this.TssAfterOpen.Size = new System.Drawing.Size(295, 6);
            // 
            // mnuFClose
            // 
            this.MnuFClose.Name = "mnuFClose";
            this.MnuFClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.MnuFClose.Size = new System.Drawing.Size(298, 34);
            this.MnuFClose.Text = "&Close";
            this.MnuFClose.ToolTipText = "Close the active log file";
            this.MnuFClose.Click += new System.EventHandler(this.MnuFClose_Click);
            // 
            // mnuFCloseAll
            // 
            this.MnuFCloseAll.Name = "mnuFCloseAll";
            this.MnuFCloseAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.MnuFCloseAll.Size = new System.Drawing.Size(298, 34);
            this.MnuFCloseAll.Text = "Close &All";
            this.MnuFCloseAll.ToolTipText = "Close all logs that are currently open";
            this.MnuFCloseAll.Click += new System.EventHandler(this.MnuFCloseAll_Click);
            // 
            // tssBeforeExit
            // 
            this.TssBeforeExit.Name = "tssBeforeExit";
            this.TssBeforeExit.Size = new System.Drawing.Size(295, 6);
            // 
            // mnuFExit
            // 
            this.MnuFExit.Name = "mnuFExit";
            this.MnuFExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.MnuFExit.Size = new System.Drawing.Size(298, 34);
            this.MnuFExit.Text = "E&xit";
            this.MnuFExit.Click += new System.EventHandler(this.MnuFExit_Click);
            // 
            // mnuPrefs
            // 
            this.MnuPrefs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPHighlighting,
            this.MnuPFont});
            this.MnuPrefs.Name = "mnuPrefs";
            this.MnuPrefs.Size = new System.Drawing.Size(118, 29);
            this.MnuPrefs.Text = "&Preferences";
            // 
            // mnuPHighlighting
            // 
            this.MnuPHighlighting.Name = "mnuPHighlighting";
            this.MnuPHighlighting.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.MnuPHighlighting.Size = new System.Drawing.Size(273, 34);
            this.MnuPHighlighting.Text = "&Highlighting";
            this.MnuPHighlighting.ToolTipText = "Display the Highlighting configuration";
            this.MnuPHighlighting.Click += new System.EventHandler(this.MnuPHighlighting_Click);
            // 
            // mnuPFont
            // 
            this.MnuPFont.Name = "mnuPFont";
            this.MnuPFont.Size = new System.Drawing.Size(273, 34);
            this.MnuPFont.Text = "&Font";
            this.MnuPFont.ToolTipText = "Pick a font for the Log Viewer";
            this.MnuPFont.Click += new System.EventHandler(this.MnuPFont_Click);
            // 
            // mnuWindows
            // 
            this.MnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuWCascade,
            this.MnuWTileHorizontally,
            this.MnuWTileVertically,
            this.MnuWArrangeIcons});
            this.MnuWindows.Name = "mnuWindows";
            this.MnuWindows.Size = new System.Drawing.Size(102, 29);
            this.MnuWindows.Text = "&Windows";
            // 
            // mnuWCascade
            // 
            this.MnuWCascade.Name = "mnuWCascade";
            this.MnuWCascade.Size = new System.Drawing.Size(240, 34);
            this.MnuWCascade.Text = "&Cascade";
            this.MnuWCascade.Click += new System.EventHandler(this.MnuWCascade_Click);
            // 
            // mnuWTileHorizontally
            // 
            this.MnuWTileHorizontally.Name = "mnuWTileHorizontally";
            this.MnuWTileHorizontally.Size = new System.Drawing.Size(240, 34);
            this.MnuWTileHorizontally.Text = "Tile &Horizontally";
            this.MnuWTileHorizontally.Click += new System.EventHandler(this.MnuWTileHorizontally_Click);
            // 
            // mnuWTileVertically
            // 
            this.MnuWTileVertically.Name = "mnuWTileVertically";
            this.MnuWTileVertically.Size = new System.Drawing.Size(240, 34);
            this.MnuWTileVertically.Text = "Tile &Vertically";
            this.MnuWTileVertically.Click += new System.EventHandler(this.MnuWTileVertically_Click);
            // 
            // mnuWArrangeIcons
            // 
            this.MnuWArrangeIcons.Name = "mnuWArrangeIcons";
            this.MnuWArrangeIcons.Size = new System.Drawing.Size(240, 34);
            this.MnuWArrangeIcons.Text = "&Iconify";
            this.MnuWArrangeIcons.Click += new System.EventHandler(this.MnuWArrangeIcons_Click);
            // 
            // mnuHelp
            // 
            this.MnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuHAabout});
            this.MnuHelp.Name = "mnuHelp";
            this.MnuHelp.Size = new System.Drawing.Size(65, 29);
            this.MnuHelp.Text = "&Help";
            // 
            // mnuHAabout
            // 
            this.MnuHAabout.Name = "mnuHAabout";
            this.MnuHAabout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.MnuHAabout.Size = new System.Drawing.Size(234, 34);
            this.MnuHAabout.Text = "&About";
            this.MnuHAabout.Click += new System.EventHandler(this.MnuHAabout_Click);
            // 
            // dlgOpenFile
            // 
            this.DlgOpenFile.DefaultExt = "log";
            this.DlgOpenFile.Filter = "Common Log File Types (.txt; .log)|*.txt;*.log|All files (*.*)|*.*";
            this.DlgOpenFile.Multiselect = true;
            // 
            // tbcMDIChildren
            // 
            this.TbcMDIChildren.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TbcMDIChildren.Dock = System.Windows.Forms.DockStyle.Top;
            this.TbcMDIChildren.ImageList = this.ImlMainForm;
            this.TbcMDIChildren.Location = new System.Drawing.Point(0, 33);
            this.TbcMDIChildren.Multiline = true;
            this.TbcMDIChildren.Name = "tbcMDIChildren";
            this.TbcMDIChildren.SelectedIndex = 0;
            this.TbcMDIChildren.ShowToolTips = true;
            this.TbcMDIChildren.Size = new System.Drawing.Size(897, 32);
            this.TbcMDIChildren.TabIndex = 4;
            this.TbcMDIChildren.Visible = false;
            this.TbcMDIChildren.SelectedIndexChanged += new System.EventHandler(this.TbcMDIChildren_SelectedIndexChanged);
            // 
            // imlMainForm
            // 
            this.ImlMainForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMainForm.ImageStream")));
            this.ImlMainForm.TransparentColor = System.Drawing.Color.Transparent;
            this.ImlMainForm.Images.SetKeyName(0, "NewLinesFound.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 587);
            this.Controls.Add(this.TbcMDIChildren);
            this.Controls.Add(this.StsMain);
            this.Controls.Add(this.MnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnuMain;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.FrmMain_MdiChildActivate);
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StsMain;
        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem MnuFile;
        private System.Windows.Forms.ToolStripMenuItem MnuPrefs;
        private System.Windows.Forms.ToolStripMenuItem MnuWindows;
        private System.Windows.Forms.ToolStripMenuItem MnuHelp;
        private System.Windows.Forms.ToolStripMenuItem MnuFOpen;
        private System.Windows.Forms.ToolStripSeparator TssAfterOpen;
        private System.Windows.Forms.ToolStripMenuItem MnuFClose;
        private System.Windows.Forms.ToolStripMenuItem MnuFCloseAll;
        private System.Windows.Forms.ToolStripSeparator TssBeforeExit;
        private System.Windows.Forms.ToolStripMenuItem MnuFExit;
        private System.Windows.Forms.OpenFileDialog DlgOpenFile;
        private System.Windows.Forms.ToolStripMenuItem MnuWCascade;
        private System.Windows.Forms.ToolStripMenuItem MnuWTileHorizontally;
        private System.Windows.Forms.ToolStripMenuItem MnuWTileVertically;
        private System.Windows.Forms.ToolStripMenuItem MnuWArrangeIcons;
        private System.Windows.Forms.TabControl TbcMDIChildren;
        private System.Windows.Forms.ImageList ImlMainForm;
        private System.Windows.Forms.ToolStripMenuItem MnuHAabout;
        private System.Windows.Forms.ToolStripMenuItem MnuPHighlighting;
        private System.Windows.Forms.FontDialog DlgFontForLSV;
        private System.Windows.Forms.ToolStripMenuItem MnuPFont;
    }
}

