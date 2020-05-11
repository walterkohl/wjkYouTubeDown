using System;
using System.Globalization;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class help : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE();
        readonly CultureInfo currentCulture = CultureInfo.CurrentCulture;
        public help()
        {
            InitializeComponent();
            string value = this.Text;
            this.Text = (trans.GetSingleTranslation(ref value, "help", "ActiveForm", currentCulture.Name)) ? value : this.Text;
        }
    }
}
