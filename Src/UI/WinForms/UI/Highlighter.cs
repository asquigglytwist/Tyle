﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.LogFile;
using Core.Rules;
using Tyle.Core;

namespace Tyle.UI
{
    public partial class Highlighter : TyleFormBase
    {
        #region Fields
        protected static readonly Highlighter visualCues;
        private ColorsComboBox cmbBackGround;
        private ColorsComboBox cmbForeGround;
        const string CustomColorTextTag = "TextColor", CustomColorBGTag = "BackGroundColor";
        readonly string SearchBoxDefaultText;
        #endregion // Fields

        static Highlighter()
        {
            visualCues = new Highlighter();
            visualCues.ttpHighlighter.BackColor = Color.Crimson;
            visualCues.ttpHighlighter.ForeColor = Color.AliceBlue;
            visualCues.ttpHighlighter.ShowAlways = true;
            visualCues.ttpHighlighter.IsBalloon = false;
            visualCues.ttpHighlighter.OwnerDraw = false;
        }

        public static void ShowAsDialog(MainForm owner)
        {
            visualCues.LoadSavedHightlightsConfig();
            visualCues.Show(owner);
        }

        protected Highlighter()
        {
            InitializeComponent();
            SearchBoxDefaultText = ttpHighlighter.GetToolTip(tbxSearchPatterns);
            btnForeGroundColor.Tag = CustomColorTextTag;
            btnForeGroundColor.Click += btnCustomColor_Click;
            btnBackGroundColor.Tag = CustomColorBGTag;
            btnBackGroundColor.Click += btnCustomColor_Click;
            InitTheColorCombos();
            //LoadSavedHightlightsConfig();
            tbxSearchPatterns.Tag = true;
            tbxSearchPatterns.Text = SearchBoxDefaultText;
            tbxSearchPatterns.GotFocus += tbxSearchPatterns_FocusChanged;
            tbxSearchPatterns.LostFocus += tbxSearchPatterns_FocusChanged;
        }

        #region Helpers
        private void LoadSavedHightlightsConfig()
        {
            lock (HighlightsHandler.AllConfigs)
            {
                var allConfigs = HighlightsHandler.AllConfigs;
                var totalConfigs = allConfigs.Count;
                ListViewItem[] items = new ListViewItem[totalConfigs];
                for (int i = 0; i < totalConfigs; i++)
                {
                    var cfg = allConfigs[i];
                    items[i] = new ListViewItem()
                    {
                        ForeColor = cfg.ForeGround,
                        BackColor = cfg.BackGround,
                        Font = cfg.DisplayFont,
                        //Text = cfg.Pattern,
                        Tag = cfg,
                        //ToolTipText = cfg.Pattern,
                        UseItemStyleForSubItems = false
                    };
                    //items[i].SubItems.Add(cfg.Pattern);//, lsvPreview.ForeColor, lsvPreview.BackColor, lsvPreview.Font);
                }
                if (items.Length > 0)
                {
                    lsvPreview.Items.Clear();
                    lsvPreview.Items.AddRange(items);
                    var lastItem = items.Last();
                    lastItem.Selected = true;
                    lsvPreview.FocusedItem = lastItem;
                    lsvPreview.Select();
                    lsvPreview.Focus();
                }
            }
        }

        protected void InitTheColorCombos()
        {
            this.cmbBackGround = new Tyle.UI.ColorsComboBox();
            this.cmbForeGround = new Tyle.UI.ColorsComboBox();

            // 
            // cmbBackGround
            // 
            this.cmbBackGround.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBackGround.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBackGround.DisplayMember = "Name";
            this.cmbBackGround.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbBackGround.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackGround.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBackGround.FormattingEnabled = true;
            this.cmbBackGround.Location = new System.Drawing.Point(361, 92);
            this.cmbBackGround.MinimumSize = new System.Drawing.Size(232, 0);
            this.cmbBackGround.Name = "cmbBackGround";
            this.cmbBackGround.Size = new System.Drawing.Size(304, 31);
            this.cmbBackGround.TabIndex = 6;
            this.ttpHighlighter.SetToolTip(this.cmbBackGround, "Background color for the highlight");
            this.cmbBackGround.ValueMember = "Name";

            // 
            // cmbForeGround
            // 
            this.cmbForeGround.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbForeGround.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbForeGround.DisplayMember = "Name";
            this.cmbForeGround.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbForeGround.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForeGround.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbForeGround.FormattingEnabled = true;

            this.cmbForeGround.Location = new System.Drawing.Point(361, 51);
            this.cmbForeGround.MinimumSize = new System.Drawing.Size(232, 0);
            this.cmbForeGround.Name = "cmbForeGround";
            this.cmbForeGround.Size = new System.Drawing.Size(304, 31);
            this.cmbForeGround.TabIndex = 5;
            this.ttpHighlighter.SetToolTip(this.cmbForeGround, "Foreground color for the highlight");
            this.cmbForeGround.ValueMember = "Name";

            cmbForeGround.PickColor(KnownColor.LightGoldenrodYellow);
            cmbBackGround.PickColor(KnownColor.Black);

            cmbFGBackUp.Hide();
            cmbBGBackUp.Hide();
            cmbForeGround.Location = cmbFGBackUp.Location;
            cmbBackGround.Location = cmbBGBackUp.Location;
            cmbForeGround.Size = cmbFGBackUp.Size;
            cmbBackGround.Size = cmbBGBackUp.Size;

            this.pnlHighlightOptions.Controls.Add(this.cmbBackGround);
            this.pnlHighlightOptions.Controls.Add(this.cmbForeGround);
        }

        private void UpdateHighlightsConfig()
        {
            var lsHighlightConfigs = new List<VisualCue>();
            lock (lsvPreview.Items)
            {
                foreach (ListViewItem item in lsvPreview.Items)
                {
                    lsHighlightConfigs.Add((VisualCue)item.Tag);
                }
            }
            HighlightsHandler.UpdateConfigs(lsHighlightConfigs);
        }
        #endregion // Helpers

        #region EventHandlers
        private void tbxSearchPatterns_FocusChanged(object sender, EventArgs e)
        {
            var isDefaultText = (bool)tbxSearchPatterns.Tag;
            if (tbxSearchPatterns.Focused)
            {
                if (isDefaultText)
                {
                    tbxSearchPatterns.Text = string.Empty;
                    tbxSearchPatterns.Tag = false;
                }
                else
                {
                    tbxSearchPatterns.SelectAll();
                }
            }
            else if (string.IsNullOrWhiteSpace(tbxSearchPatterns.Text))
            {
                tbxSearchPatterns.Text = SearchBoxDefaultText;
                tbxSearchPatterns.Tag = true;
            }
        }

        private void tbxPattern_TextChanged(object sender, EventArgs e)
    => btnAdd.Enabled = !string.IsNullOrWhiteSpace(tbxPattern.Text);

        private void lsvPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bIsAnItemSelected = lsvPreview.SelectedIndices.Count > 0;
            btnMoveUp.Enabled = btnMoveDown.Enabled = btnRemove.Enabled
                = bIsAnItemSelected;
            if (bIsAnItemSelected)
            {
                var cfg = (VisualCue)lsvPreview.Items[lsvPreview.SelectedIndices[0]].Tag;
                //tbxPattern.Text = cfg.Pattern;
                //chkIgnoreCase.Checked = cfg.IgnoreCase;
                chkBold.Checked = cfg.Bold;
                chkItalic.Checked = cfg.Italic;
                chkUnderline.Checked = cfg.Underline;
                chkStrikeout.Checked = cfg.Strikeout;
                btnForeGroundColor.ForeColor = cfg.ForeGround;
                ttpHighlighter.SetToolTip(btnForeGroundColor, cfg.ForeGround.ToString());
                btnBackGroundColor.BackColor = cfg.BackGround;
                ttpHighlighter.SetToolTip(btnBackGroundColor, cfg.BackGround.ToString());
                pnlHighlightOptions.Enabled = true;
            }
            else
            {
                pnlHighlightOptions.Enabled = false;
                tbxPattern.Text = "";
                tbxPattern.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var fs = FontStyle.Regular;
            if (chkBold.Checked)
            {
                fs |= FontStyle.Bold;
            }
            if (chkItalic.Checked)
            {
                fs |= FontStyle.Italic;
            }
            if (chkUnderline.Checked)
            {
                fs |= FontStyle.Underline;
            }
            if (chkStrikeout.Checked)
            {
                fs |= FontStyle.Strikeout;
            }
            var txtPattern = tbxPattern.Text;
            var tmpFont = new Font(Font, fs);
            var item = new ListViewItem(txtPattern)
            {
                ForeColor = cmbForeGround.SelectedColor,
                BackColor = cmbBackGround.SelectedColor,
                Font = tmpFont,
                UseItemStyleForSubItems = false,
                // Tag = new HighlightConfig(txtPattern, chkIgnoreCase.Checked, false, chkBold.Checked, chkItalic.Checked, chkUnderline.Checked, chkStrikeout.Checked, cmbForeGround.SelectedColor, cmbBackGround.SelectedColor, tmpFont)
            };
            item.SubItems.Add(txtPattern);
            lsvPreview.Items.Add(item);
        }

        private void btnCustomColor_Click(object sender, EventArgs e)
        {
            // [BIB]:  https://stackoverflow.com/questions/4261162/modal-common-dialog-not-showing-until-pressing-the-alt-key/5080752
            _ = Task.Delay(500)
                .ContinueWith(task => SendKeys.SendWait("%"))
                .ContinueWith(task => SendKeys.SendWait("%"));
            if (dlgCustomColor.ShowDialog(visualCues) == DialogResult.OK)
            {
                var color = dlgCustomColor.Color;
                var caller = (sender as Button).Tag as string;
                if (caller.Equals(CustomColorTextTag, StringComparison.OrdinalIgnoreCase))
                {
                    cmbForeGround.PickColor(color);
                }
                else if (caller.Equals(CustomColorBGTag, StringComparison.OrdinalIgnoreCase))
                {
                    cmbBackGround.PickColor(color);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
            UpdateHighlightsConfig();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            visualCues.Hide();
        }

        //private void ttpHighlighter_Popup(object sender, PopupEventArgs e)
        //{
        //    e.ToolTipSize = TextRenderer.MeasureText(ttpHighlighter.GetToolTip(e.AssociatedControl), visualCues.Font);
        //}

        //private void ttpHighlighter_Draw(object sender, DrawToolTipEventArgs e)
        //{
        //    e.Graphics.FillRectangle(SystemBrushes.Info, e.Bounds);
        //    e.DrawBackground();
        //    e.DrawBorder();
        //    e.DrawText(TextFormatFlags.VerticalCenter);
        //}
        #endregion // EventHandlers
    }
}
