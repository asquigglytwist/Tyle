using System.Windows.Forms;

namespace Tyle.UI
{
    public partial class FindDialog : Form
    {
        public static FindDialog findDialog;

        static FindDialog()
        {
            findDialog = new FindDialog();
        }

        protected FindDialog()
        {
            InitializeComponent();
        }

        #region Properties
        public string SearchText
        {
            get
            {
                return tbxSearchText.Text;
            }
        }

        public bool WrapSearch
        {
            get
            {
                return chkWrapSearch.Checked;
            }
        }
        #endregion

        #region EventHandlers
        private void tbxSearchText_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSearchText.Text))
            {
                btnFind.Enabled = false;
            }
            else
            {
                btnFind.Enabled = true;
            }
        }
        #endregion
    }
}
