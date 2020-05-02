namespace Tyle.UI
{
    partial class AboutBox
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
            this.lsvAboutDetails = new System.Windows.Forms.ListView();
            this.lsvColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvColField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvAboutDetails
            // 
            this.lsvAboutDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lsvColValue,
            this.lsvColField});
            this.lsvAboutDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lsvAboutDetails.GridLines = true;
            this.lsvAboutDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvAboutDetails.HideSelection = false;
            this.lsvAboutDetails.Location = new System.Drawing.Point(0, 226);
            this.lsvAboutDetails.MultiSelect = false;
            this.lsvAboutDetails.Name = "lsvAboutDetails";
            this.lsvAboutDetails.ShowItemToolTips = true;
            this.lsvAboutDetails.Size = new System.Drawing.Size(720, 348);
            this.lsvAboutDetails.TabIndex = 0;
            this.lsvAboutDetails.UseCompatibleStateImageBehavior = false;
            // 
            // lsvColValue
            // 
            this.lsvColValue.DisplayIndex = 1;
            this.lsvColValue.Text = "";
            // 
            // lsvColField
            // 
            this.lsvColField.DisplayIndex = 0;
            this.lsvColField.Text = "";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 574);
            this.Controls.Add(this.lsvAboutDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AboutBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvAboutDetails;
        private System.Windows.Forms.ColumnHeader lsvColValue;
        private System.Windows.Forms.ColumnHeader lsvColField;
    }
}