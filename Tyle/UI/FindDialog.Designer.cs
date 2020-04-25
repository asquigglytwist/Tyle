namespace Tyle.UI
{
    partial class FindDialog
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
            this.lblFindText = new System.Windows.Forms.Label();
            this.tbxSearchText = new System.Windows.Forms.TextBox();
            this.chkWrapSearch = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFindText
            // 
            this.lblFindText.AutoSize = true;
            this.lblFindText.Location = new System.Drawing.Point(9, 13);
            this.lblFindText.Name = "lblFindText";
            this.lblFindText.Size = new System.Drawing.Size(76, 17);
            this.lblFindText.TabIndex = 0;
            this.lblFindText.Text = "Fi&nd what :";
            // 
            // tbxSearchText
            // 
            this.tbxSearchText.Location = new System.Drawing.Point(100, 10);
            this.tbxSearchText.Name = "tbxSearchText";
            this.tbxSearchText.Size = new System.Drawing.Size(336, 22);
            this.tbxSearchText.TabIndex = 1;
            this.tbxSearchText.TextChanged += new System.EventHandler(this.tbxSearchText_TextChanged);
            // 
            // chkWrapSearch
            // 
            this.chkWrapSearch.AutoSize = true;
            this.chkWrapSearch.Location = new System.Drawing.Point(12, 57);
            this.chkWrapSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkWrapSearch.Name = "chkWrapSearch";
            this.chkWrapSearch.Size = new System.Drawing.Size(150, 21);
            this.chkWrapSearch.TabIndex = 2;
            this.chkWrapSearch.Text = "&Wrap automatically";
            this.chkWrapSearch.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(360, 57);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(74, 26);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 87);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgFind
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 130);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chkWrapSearch);
            this.Controls.Add(this.tbxSearchText);
            this.Controls.Add(this.lblFindText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgFind";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFindText;
        private System.Windows.Forms.TextBox tbxSearchText;
        private System.Windows.Forms.CheckBox chkWrapSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCancel;
    }
}