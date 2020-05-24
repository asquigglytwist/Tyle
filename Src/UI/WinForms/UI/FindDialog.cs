using System.Windows.Forms;

namespace Tyle.UI
{
    public partial class FindDialog : TyleFormBase
    {
        public static readonly FindDialog findDialog = new FindDialog();

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
            btnFind.Enabled = !string.IsNullOrWhiteSpace(tbxSearchText.Text);
        }
        #endregion
    }
}
