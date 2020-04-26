namespace Tyle.UI
{
    partial class Highlighter
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
            this.dlgCustomColor = new System.Windows.Forms.ColorDialog();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lsvPreview = new System.Windows.Forms.ListView();
            this.colPreview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPattern = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPreviewOptions = new System.Windows.Forms.Panel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlHighlightOptions = new System.Windows.Forms.Panel();
            this.cmbBGBackUp = new System.Windows.Forms.ComboBox();
            this.cmbFGBackUp = new System.Windows.Forms.ComboBox();
            this.btnCustomColorBG = new System.Windows.Forms.Button();
            this.btnCustomColorText = new System.Windows.Forms.Button();
            this.chkStrikeout = new System.Windows.Forms.CheckBox();
            this.chkUnderline = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.tbxPattern = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttpHighlighter = new System.Windows.Forms.ToolTip(this.components);
            this.pnlPreview.SuspendLayout();
            this.pnlPreviewOptions.SuspendLayout();
            this.pnlHighlightOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.lsvPreview);
            this.pnlPreview.Location = new System.Drawing.Point(14, 14);
            this.pnlPreview.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(608, 375);
            this.pnlPreview.TabIndex = 2;
            // 
            // lsvPreview
            // 
            this.lsvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPreview,
            this.colPattern});
            this.lsvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvPreview.FullRowSelect = true;
            this.lsvPreview.GridLines = true;
            this.lsvPreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPreview.Location = new System.Drawing.Point(0, 0);
            this.lsvPreview.MultiSelect = false;
            this.lsvPreview.Name = "lsvPreview";
            this.lsvPreview.ShowGroups = false;
            this.lsvPreview.Size = new System.Drawing.Size(608, 375);
            this.lsvPreview.TabIndex = 0;
            this.lsvPreview.UseCompatibleStateImageBehavior = false;
            this.lsvPreview.View = System.Windows.Forms.View.Details;
            // 
            // colPreview
            // 
            this.colPreview.Text = "Preview";
            this.colPreview.Width = 120;
            // 
            // colPattern
            // 
            this.colPattern.Text = "Pattern";
            this.colPattern.Width = 544;
            // 
            // pnlPreviewOptions
            // 
            this.pnlPreviewOptions.Controls.Add(this.btnMoveDown);
            this.pnlPreviewOptions.Controls.Add(this.btnMoveUp);
            this.pnlPreviewOptions.Controls.Add(this.btnRemove);
            this.pnlPreviewOptions.Controls.Add(this.btnAdd);
            this.pnlPreviewOptions.Location = new System.Drawing.Point(637, 14);
            this.pnlPreviewOptions.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPreviewOptions.Name = "pnlPreviewOptions";
            this.pnlPreviewOptions.Size = new System.Drawing.Size(88, 375);
            this.pnlPreviewOptions.TabIndex = 6;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(13, 232);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(8);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Padding = new System.Windows.Forms.Padding(2);
            this.btnMoveDown.Size = new System.Drawing.Size(56, 56);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "&v";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(13, 160);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(8);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Padding = new System.Windows.Forms.Padding(2);
            this.btnMoveUp.Size = new System.Drawing.Size(56, 56);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "&^";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(13, 88);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(2);
            this.btnRemove.Size = new System.Drawing.Size(56, 56);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "&-";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(2);
            this.btnAdd.Size = new System.Drawing.Size(56, 56);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlHighlightOptions
            // 
            this.pnlHighlightOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHighlightOptions.Controls.Add(this.cmbBGBackUp);
            this.pnlHighlightOptions.Controls.Add(this.cmbFGBackUp);
            this.pnlHighlightOptions.Controls.Add(this.btnCustomColorBG);
            this.pnlHighlightOptions.Controls.Add(this.btnCustomColorText);
            this.pnlHighlightOptions.Controls.Add(this.chkStrikeout);
            this.pnlHighlightOptions.Controls.Add(this.chkUnderline);
            this.pnlHighlightOptions.Controls.Add(this.chkItalic);
            this.pnlHighlightOptions.Controls.Add(this.chkBold);
            this.pnlHighlightOptions.Controls.Add(this.chkIgnoreCase);
            this.pnlHighlightOptions.Controls.Add(this.tbxPattern);
            this.pnlHighlightOptions.Location = new System.Drawing.Point(14, 397);
            this.pnlHighlightOptions.Name = "pnlHighlightOptions";
            this.pnlHighlightOptions.Size = new System.Drawing.Size(711, 142);
            this.pnlHighlightOptions.TabIndex = 7;
            // 
            // cmbBGBackUp
            // 
            this.cmbBGBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBGBackUp.FormattingEnabled = true;
            this.cmbBGBackUp.Location = new System.Drawing.Point(329, 92);
            this.cmbBGBackUp.Name = "cmbBGBackUp";
            this.cmbBGBackUp.Size = new System.Drawing.Size(336, 33);
            this.cmbBGBackUp.TabIndex = 14;
            // 
            // cmbFGBackUp
            // 
            this.cmbFGBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFGBackUp.FormattingEnabled = true;
            this.cmbFGBackUp.Location = new System.Drawing.Point(329, 51);
            this.cmbFGBackUp.Name = "cmbFGBackUp";
            this.cmbFGBackUp.Size = new System.Drawing.Size(336, 33);
            this.cmbFGBackUp.TabIndex = 13;
            // 
            // btnCustomColorBG
            // 
            this.btnCustomColorBG.Location = new System.Drawing.Point(671, 92);
            this.btnCustomColorBG.Name = "btnCustomColorBG";
            this.btnCustomColorBG.Size = new System.Drawing.Size(24, 32);
            this.btnCustomColorBG.TabIndex = 10;
            this.ttpHighlighter.SetToolTip(this.btnCustomColorBG, "Pick a custom color");
            this.btnCustomColorBG.UseVisualStyleBackColor = true;
            this.btnCustomColorBG.Click += new System.EventHandler(this.btnCustomColor_Click);
            // 
            // btnCustomColorText
            // 
            this.btnCustomColorText.Location = new System.Drawing.Point(671, 51);
            this.btnCustomColorText.Name = "btnCustomColorText";
            this.btnCustomColorText.Size = new System.Drawing.Size(24, 32);
            this.btnCustomColorText.TabIndex = 9;
            this.ttpHighlighter.SetToolTip(this.btnCustomColorText, "Pick a custom color");
            this.btnCustomColorText.UseVisualStyleBackColor = true;
            this.btnCustomColorText.Click += new System.EventHandler(this.btnCustomColor_Click);
            // 
            // chkStrikeout
            // 
            this.chkStrikeout.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStrikeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStrikeout.Location = new System.Drawing.Point(251, 59);
            this.chkStrikeout.Name = "chkStrikeout";
            this.chkStrikeout.Size = new System.Drawing.Size(56, 56);
            this.chkStrikeout.TabIndex = 12;
            this.chkStrikeout.Text = "&S";
            this.chkStrikeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttpHighlighter.SetToolTip(this.chkStrikeout, "Strikeout");
            this.chkStrikeout.UseVisualStyleBackColor = true;
            // 
            // chkUnderline
            // 
            this.chkUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnderline.Location = new System.Drawing.Point(127, 57);
            this.chkUnderline.Name = "chkUnderline";
            this.chkUnderline.Size = new System.Drawing.Size(56, 56);
            this.chkUnderline.TabIndex = 11;
            this.chkUnderline.Text = "&U";
            this.chkUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttpHighlighter.SetToolTip(this.chkUnderline, "Underline");
            this.chkUnderline.UseVisualStyleBackColor = true;
            // 
            // chkItalic
            // 
            this.chkItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItalic.Location = new System.Drawing.Point(189, 59);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(56, 56);
            this.chkItalic.TabIndex = 10;
            this.chkItalic.Text = "&I";
            this.chkItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttpHighlighter.SetToolTip(this.chkItalic, "Italics");
            this.chkItalic.UseVisualStyleBackColor = true;
            // 
            // chkBold
            // 
            this.chkBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBold.Location = new System.Drawing.Point(65, 57);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(56, 56);
            this.chkBold.TabIndex = 9;
            this.chkBold.Text = "&B";
            this.chkBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttpHighlighter.SetToolTip(this.chkBold, "Bold");
            this.chkBold.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIgnoreCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreCase.Location = new System.Drawing.Point(3, 57);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(56, 56);
            this.chkIgnoreCase.TabIndex = 8;
            this.chkIgnoreCase.Text = "&C";
            this.chkIgnoreCase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttpHighlighter.SetToolTip(this.chkIgnoreCase, "Case sensitive?");
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // tbxPattern
            // 
            this.tbxPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPattern.Location = new System.Drawing.Point(3, 10);
            this.tbxPattern.Name = "tbxPattern";
            this.tbxPattern.Size = new System.Drawing.Size(692, 30);
            this.tbxPattern.TabIndex = 7;
            this.ttpHighlighter.SetToolTip(this.tbxPattern, "The pattern to be highlighted");
            this.tbxPattern.TextChanged += new System.EventHandler(this.tbxPattern_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(547, 563);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 46);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.ttpHighlighter.SetToolTip(this.btnOK, "Click to save all changes");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(650, 563);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 46);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.ttpHighlighter.SetToolTip(this.btnCancel, "Click to discard all changes");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ttpHighlighter
            // 
            this.ttpHighlighter.IsBalloon = true;
            this.ttpHighlighter.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpHighlighter.ToolTipTitle = "Tyle";
            // 
            // Highlighter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(747, 629);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnlHighlightOptions);
            this.Controls.Add(this.pnlPreviewOptions);
            this.Controls.Add(this.pnlPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Highlighter";
            this.Text = "Highlighter";
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreviewOptions.ResumeLayout(false);
            this.pnlHighlightOptions.ResumeLayout(false);
            this.pnlHighlightOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog dlgCustomColor;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.ListView lsvPreview;
        private System.Windows.Forms.Panel pnlPreviewOptions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel pnlHighlightOptions;
        private System.Windows.Forms.Button btnCustomColorBG;
        private System.Windows.Forms.Button btnCustomColorText;
        private System.Windows.Forms.TextBox tbxPattern;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.CheckBox chkStrikeout;
        private System.Windows.Forms.CheckBox chkUnderline;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colPreview;
        private System.Windows.Forms.ColumnHeader colPattern;
        private System.Windows.Forms.ToolTip ttpHighlighter;
        private System.Windows.Forms.ComboBox cmbBGBackUp;
        private System.Windows.Forms.ComboBox cmbFGBackUp;
    }
}
