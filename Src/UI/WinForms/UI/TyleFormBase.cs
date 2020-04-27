using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyle.UI
{
    public class TyleFormBase : Form
    {
        public TyleFormBase()
        {
            // [BIB]:  https://stackoverflow.com/a/10133046
            //note! USING JUST AUTOSCALEMODE WILL NOT SOLVE ISSUE. MUST USE BOTH!
            AutoScaleDimensions = new SizeF(96F, 96F); //IMPORTANT
            AutoScaleMode = AutoScaleMode.Dpi;   //IMPORTANT
        }
    }
}
