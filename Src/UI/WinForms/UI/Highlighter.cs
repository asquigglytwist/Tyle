using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Code;

namespace Tyle.UI
{
    public partial class Highlighter : TyleFormBase
    {
        protected static readonly Highlighter visualCues;
        private ColorsComboBox cmbBackGround;
        private ColorsComboBox cmbForeGround;
        const string CustomColorTextTag = "TextColor", CustomColorBGTag = "BackGroundColor";
        readonly string SearchBoxDefaultText;

        static Highlighter()
        {
            visualCues = new Highlighter();
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

        private void tbxSearchPatterns_FocusChanged(object sender, EventArgs e)
        {
            var isDefaultText = (bool)tbxSearchPatterns.Tag;
            if (tbxSearchPatterns.Focused)
            {
                if (isDefaultText)
                {
                    tbxSearchPatterns.Text = string.Empty;
                }
                else
                {
                    tbxSearchPatterns.SelectAll();
                }
            }
            else
            {
                if (isDefaultText)
                {
                }
            }
        }

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
                        Text = cfg.Pattern,
                        Tag = cfg,
                        ToolTipText = cfg.Pattern,
                        UseItemStyleForSubItems = false
                    };
                    items[i].SubItems.Add(cfg.Pattern);//, lsvPreview.ForeColor, lsvPreview.BackColor, lsvPreview.Font);
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
            var lsHighlightConfigs = new List<HighlightConfig>();
            lock (lsvPreview.Items)
            {
                foreach (ListViewItem item in lsvPreview.Items)
                {
                    lsHighlightConfigs.Add((HighlightConfig)item.Tag);
                }
            }
            HighlightsHandler.UpdateConfigs(lsHighlightConfigs);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var fs = FontStyle.Regular;
            if(chkBold.Checked)
            {
                fs |= FontStyle.Bold;
            }
            if(chkItalic.Checked)
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
                Tag = new HighlightConfig(txtPattern, chkIgnoreCase.Checked, chkBold.Checked, chkItalic.Checked, chkUnderline.Checked, chkStrikeout.Checked, cmbForeGround.SelectedColor, cmbBackGround.SelectedColor, tmpFont)
            };
            item.SubItems.Add(txtPattern);
            lsvPreview.Items.Add(item);
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
                var cfg = (HighlightConfig)lsvPreview.Items[lsvPreview.SelectedIndices[0]].Tag;
                tbxPattern.Text = cfg.Pattern;
                chkIgnoreCase.Checked = cfg.IgnoreCase;
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
        }

        private void btnCustomColor_Click(object sender, EventArgs e)
        {
            if (dlgCustomColor.ShowDialog(this) == DialogResult.OK)
            {
                var color = dlgCustomColor.Color;
                var caller = (sender as Button).Tag as string;
                if (caller.Equals(CustomColorTextTag))
                {
                    cmbForeGround.PickColor(color);
                }
                else if (caller.Equals(CustomColorBGTag))
                {
                    cmbBackGround.PickColor(color);
                }
            }
        }
    }
}
