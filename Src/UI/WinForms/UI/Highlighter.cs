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
using Tyle.Core;

namespace Tyle.UI
{
    public partial class Highlighter : TyleFormBase
    {
        public static Highlighter visualCues;
        private ColorsComboBox cmbBackGround;
        private ColorsComboBox cmbForeGround;
        const string CustomColorTextTag = "TextColor", CustomColorBGTag = "BackGroundColor";
        bool unsavedChanges;

        static Highlighter()
        {
            visualCues = new Highlighter();
        }

        protected Highlighter()
        {
            InitializeComponent();
            btnCustomColorText.Tag = CustomColorTextTag;
            btnCustomColorBG.Tag = CustomColorBGTag;
            InitTheColorCombos();
            LoadSavedHightlightsConfig();
            unsavedChanges = false;
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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                var dialogResult = MessageBox.Show("There are unsaved changes.  Would you like to save now?", AppMetaData.ApplicationName, MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    // [BIB]:  https://stackoverflow.com/questions/11518529/how-to-call-a-button-click-event-from-another-method
                    btnAdd.PerformClick();
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            UpdateHighlightsConfig();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FontStyle fs = FontStyle.Regular;
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
            var item = new ListViewItem(tbxPattern.Text)
            {
                ForeColor = cmbForeGround.SelectedColor,
                BackColor = cmbBackGround.SelectedColor,
                Font = new Font(Font, fs),
                UseItemStyleForSubItems = false,
                Tag = new HighlightConfig(Text, chkIgnoreCase.Checked, chkBold.Checked, chkItalic.Checked, chkUnderline.Checked, chkStrikeout.Checked, cmbForeGround.SelectedColor, cmbBackGround.SelectedColor, Font)
            };
            item.SubItems.Add(tbxPattern.Text);
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

    #region ColorsComboBox
    public class ColorsComboBox : ComboBox
    {
        public static readonly List<Color> NamedColors;
        const int ColoredRectangleWidth = 14, ColoredRectanglePadding = 15;
        const string LongestKnownColor = "--GradientInactiveCaption--";
        const string CustomColor = "Custom";
        bool controlInitialized;

        static ColorsComboBox()
        {
            // [BIB]:  https://stackoverflow.com/questions/3821174/c-sharp-getting-all-colors-from-color
            // [BIB]:  https://stackoverflow.com/questions/1603170/conversion-of-system-array-to-list
            var allcols = Enum.GetValues(typeof(KnownColor)).OfType<KnownColor>();
            // [BIB]:  https://stackoverflow.com/questions/13138845/loop-through-array-in-linq-query
            var temp = from c in allcols
                   where ((c > KnownColor.Transparent) && (c < KnownColor.ButtonFace))
                   select Color.FromKnownColor(c);
            NamedColors = temp.ToList();
        }

        public ColorsComboBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            //ValueMember = DisplayMember = "Name";
            // [BIB]:  https://stackoverflow.com/questions/600869/how-to-bind-a-list-to-a-combobox-winforms
            if (!controlInitialized)
            {
                System.Threading.Monitor.Enter(Items);
                Items.Clear();
                NamedColors.ForEach(c => Items.Add(c.Name));
                Items.Add(CustomColor);
                using (Graphics g = CreateGraphics())
                {
                    // [BIB]:  https://stackoverflow.com/questions/4842160/auto-width-of-comboboxs-content
                    var minWidth = (int)((ColoredRectangleWidth + ColoredRectanglePadding
                        + g.MeasureString(LongestKnownColor, Font).Width + SystemInformation.VerticalScrollBarWidth + 15) + 0.99f);
                    // [BIB]:  https://stackoverflow.com/questions/2582718/create-a-custom-control-which-has-a-fixed-height-in-designer?rq=1
                    MinimumSize = new Size(minWidth, 0);
                    if (DropDownWidth < minWidth)
                    {
                        DropDownWidth = minWidth;
                    }
                }
                LastKnownCustomColor = Color.AliceBlue;
                controlInitialized = true;
                System.Threading.Monitor.Exit(Items);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // [BIB]:  https://stackoverflow.com/questions/4667532/colour-individual-items-in-a-winforms-combobox
            base.OnDrawItem(e);
            e.DrawBackground();
            if (e.Index > -1)
            {
                int x = e.Bounds.X + 1, y = e.Bounds.Y + 1, width = ColoredRectangleWidth + 2, height = e.Bounds.Height - 2;
                var itemText = Items[e.Index].ToString();
                Brush br;
                if (e.Index < NamedColors.Count)
                {
                    br = new SolidBrush(NamedColors[e.Index]);
                }
                else
                {
                    // [BIB]:  https://stackoverflow.com/questions/8402798/multi-color-diagonal-gradient-in-winforms
                    Rectangle r = e.Bounds;
                    r.Width = width;
                    r.Height = height;
                    br = new LinearGradientBrush(r, Color.Black, Color.Black, 0, false);
                    ColorBlend cb = new ColorBlend();
                    cb.Positions = new[] { 0, 1 / 2f, 1 };
                    cb.Colors = new[] { Color.Red, Color.Green, Color.Blue };
                    (br as LinearGradientBrush).InterpolationColors = cb;
                }
                using (var g = e.Graphics)
                {
                    g.DrawRectangle(Pens.Black, x, y, width, height);
                    g.FillRectangle(br, x, y, width, height);
                    g.DrawString(itemText, Font, Brushes.Black, x + ColoredRectangleWidth + ColoredRectanglePadding, y);
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            PickColor(SelectedIndex);
        }

        protected void PickColor(int index)
        {
            Color color = LastKnownCustomColor;
            if (index > -1 && index < NamedColors.Count)
            {
                SelectedIndex = index;
                color = NamedColors[index];
            }
            else
            {
                //Text = color.ToString();
                Text = CustomColor;
            }
            SelectedColor = color;
        }

        public void PickColor(Color color)
        {
            PickColor(NamedColors.IndexOf(color));
            LastKnownCustomColor = color;
        }

        public void PickColor(KnownColor color)
        {
            PickColor(Color.FromKnownColor(color));
        }

        public Color SelectedColor { get; protected set; }
        protected Color LastKnownCustomColor { get; set; }
    }
    #endregion
}
