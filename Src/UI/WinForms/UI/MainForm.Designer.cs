﻿namespace Tyle.UI
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
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterOpen = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tssBeforeExit = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrefs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPHighlighting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWTileVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHAabout = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tbcMDIChildren = new System.Windows.Forms.TabControl();
            this.imlMainForm = new System.Windows.Forms.ImageList(this.components);
            this.dlgFontForLSV = new System.Windows.Forms.FontDialog();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Location = new System.Drawing.Point(0, 565);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(897, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // mnuMain
            // 
            this.mnuMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPrefs,
            this.mnuWindows,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.mnuWindows;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(897, 33);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "MainMenu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFOpen,
            this.tssAfterOpen,
            this.mnuFClose,
            this.mnuFCloseAll,
            this.tssBeforeExit,
            this.mnuFExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(54, 29);
            this.mnuFile.Text = "&File";
            // 
            // mnuFOpen
            // 
            this.mnuFOpen.Name = "mnuFOpen";
            this.mnuFOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFOpen.Size = new System.Drawing.Size(298, 34);
            this.mnuFOpen.Text = "&Open";
            this.mnuFOpen.ToolTipText = "Open a new log file for viewing";
            this.mnuFOpen.Click += new System.EventHandler(this.mnuFOpen_Click);
            // 
            // tssAfterOpen
            // 
            this.tssAfterOpen.Name = "tssAfterOpen";
            this.tssAfterOpen.Size = new System.Drawing.Size(295, 6);
            // 
            // mnuFClose
            // 
            this.mnuFClose.Name = "mnuFClose";
            this.mnuFClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mnuFClose.Size = new System.Drawing.Size(298, 34);
            this.mnuFClose.Text = "&Close";
            this.mnuFClose.ToolTipText = "Close the active log file";
            this.mnuFClose.Click += new System.EventHandler(this.mnuFClose_Click);
            // 
            // mnuFCloseAll
            // 
            this.mnuFCloseAll.Name = "mnuFCloseAll";
            this.mnuFCloseAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.mnuFCloseAll.Size = new System.Drawing.Size(298, 34);
            this.mnuFCloseAll.Text = "Close &All";
            this.mnuFCloseAll.ToolTipText = "Close all logs that are currently open";
            this.mnuFCloseAll.Click += new System.EventHandler(this.mnuFCloseAll_Click);
            // 
            // tssBeforeExit
            // 
            this.tssBeforeExit.Name = "tssBeforeExit";
            this.tssBeforeExit.Size = new System.Drawing.Size(295, 6);
            // 
            // mnuFExit
            // 
            this.mnuFExit.Name = "mnuFExit";
            this.mnuFExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFExit.Size = new System.Drawing.Size(298, 34);
            this.mnuFExit.Text = "E&xit";
            this.mnuFExit.Click += new System.EventHandler(this.mnuFExit_Click);
            // 
            // mnuPrefs
            // 
            this.mnuPrefs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPHighlighting,
            this.mnuPFont});
            this.mnuPrefs.Name = "mnuPrefs";
            this.mnuPrefs.Size = new System.Drawing.Size(118, 29);
            this.mnuPrefs.Text = "&Preferences";
            // 
            // mnuPHighlighting
            // 
            this.mnuPHighlighting.Name = "mnuPHighlighting";
            this.mnuPHighlighting.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuPHighlighting.Size = new System.Drawing.Size(273, 34);
            this.mnuPHighlighting.Text = "&Highlighting";
            this.mnuPHighlighting.ToolTipText = "Display the Highlighting configuration";
            this.mnuPHighlighting.Click += new System.EventHandler(this.mnuPHighlighting_Click);
            // 
            // mnuPFont
            // 
            this.mnuPFont.Name = "mnuPFont";
            this.mnuPFont.Size = new System.Drawing.Size(273, 34);
            this.mnuPFont.Text = "&Font";
            this.mnuPFont.ToolTipText = "Pick a font for the Log Viewer";
            this.mnuPFont.Click += new System.EventHandler(this.mnuPFont_Click);
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWCascade,
            this.mnuWTileHorizontally,
            this.mnuWTileVertically,
            this.mnuWArrangeIcons});
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(102, 29);
            this.mnuWindows.Text = "&Windows";
            // 
            // mnuWCascade
            // 
            this.mnuWCascade.Name = "mnuWCascade";
            this.mnuWCascade.Size = new System.Drawing.Size(240, 34);
            this.mnuWCascade.Text = "&Cascade";
            this.mnuWCascade.Click += new System.EventHandler(this.mnuWCascade_Click);
            // 
            // mnuWTileHorizontally
            // 
            this.mnuWTileHorizontally.Name = "mnuWTileHorizontally";
            this.mnuWTileHorizontally.Size = new System.Drawing.Size(240, 34);
            this.mnuWTileHorizontally.Text = "Tile &Horizontally";
            this.mnuWTileHorizontally.Click += new System.EventHandler(this.mnuWTileHorizontally_Click);
            // 
            // mnuWTileVertically
            // 
            this.mnuWTileVertically.Name = "mnuWTileVertically";
            this.mnuWTileVertically.Size = new System.Drawing.Size(240, 34);
            this.mnuWTileVertically.Text = "Tile &Vertically";
            this.mnuWTileVertically.Click += new System.EventHandler(this.mnuWTileVertically_Click);
            // 
            // mnuWArrangeIcons
            // 
            this.mnuWArrangeIcons.Name = "mnuWArrangeIcons";
            this.mnuWArrangeIcons.Size = new System.Drawing.Size(240, 34);
            this.mnuWArrangeIcons.Text = "&Iconify";
            this.mnuWArrangeIcons.Click += new System.EventHandler(this.mnuWArrangeIcons_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHAabout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(65, 29);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHAabout
            // 
            this.mnuHAabout.Name = "mnuHAabout";
            this.mnuHAabout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mnuHAabout.Size = new System.Drawing.Size(234, 34);
            this.mnuHAabout.Text = "&About";
            this.mnuHAabout.Click += new System.EventHandler(this.mnuHAabout_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.DefaultExt = "log";
            this.dlgOpenFile.Filter = "Common Log File Types (.txt; .log)|*.txt;*.log|All files (*.*)|*.*";
            this.dlgOpenFile.Multiselect = true;
            // 
            // tbcMDIChildren
            // 
            this.tbcMDIChildren.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcMDIChildren.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcMDIChildren.ImageList = this.imlMainForm;
            this.tbcMDIChildren.Location = new System.Drawing.Point(0, 33);
            this.tbcMDIChildren.Multiline = true;
            this.tbcMDIChildren.Name = "tbcMDIChildren";
            this.tbcMDIChildren.SelectedIndex = 0;
            this.tbcMDIChildren.ShowToolTips = true;
            this.tbcMDIChildren.Size = new System.Drawing.Size(897, 32);
            this.tbcMDIChildren.TabIndex = 4;
            this.tbcMDIChildren.Visible = false;
            this.tbcMDIChildren.SelectedIndexChanged += new System.EventHandler(this.tbcMDIChildren_SelectedIndexChanged);
            // 
            // imlMainForm
            // 
            this.imlMainForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMainForm.ImageStream")));
            this.imlMainForm.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMainForm.Images.SetKeyName(0, "NewLinesFound.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 587);
            this.Controls.Add(this.tbcMDIChildren);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuPrefs;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuFOpen;
        private System.Windows.Forms.ToolStripSeparator tssAfterOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFClose;
        private System.Windows.Forms.ToolStripMenuItem mnuFCloseAll;
        private System.Windows.Forms.ToolStripSeparator tssBeforeExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFExit;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolStripMenuItem mnuWCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuWTileHorizontally;
        private System.Windows.Forms.ToolStripMenuItem mnuWTileVertically;
        private System.Windows.Forms.ToolStripMenuItem mnuWArrangeIcons;
        private System.Windows.Forms.TabControl tbcMDIChildren;
        private System.Windows.Forms.ImageList imlMainForm;
        private System.Windows.Forms.ToolStripMenuItem mnuHAabout;
        private System.Windows.Forms.ToolStripMenuItem mnuPHighlighting;
        private System.Windows.Forms.FontDialog dlgFontForLSV;
        private System.Windows.Forms.ToolStripMenuItem mnuPFont;
    }
}

