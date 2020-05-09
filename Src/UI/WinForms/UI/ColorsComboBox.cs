using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyle.UI
{
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
                    var cb = new ColorBlend();
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
