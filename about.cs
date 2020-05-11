using System;
using System.Globalization;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class about : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE();
        readonly CultureInfo currentCulture = CultureInfo.CurrentCulture;
        public about()
        {
            InitializeComponent();
            CreateText();
        }

        private void CreateText()
        {
            string value = this.Text;
            this.Text = (trans.GetSingleTranslation(ref value, "about", "ActiveForm", currentCulture.Name)) ? value : this.Text;
            string nl = "\r\n";
            richTextBox1.Text = nl + nl;
            richTextBox1.Text += Application.ProductName + nl;
            richTextBox1.Text += string.Format("Version: {0}" + nl, Application.ProductVersion);
            richTextBox1.Text += string.Format("© Copyrights 2019-{0} by" + nl + "{1}" + nl, DateTime.Today.Year.ToString().Substring(2, 2), Application.CompanyName);
            richTextBox1.Text += nl + nl;
            richTextBox1.Text += "Phone: +66 88 525 9904" + nl;
            richTextBox1.Text += "Skype: Walter_Kohl" + nl;
            richTextBox1.Text += "e-Mail: kohl.walter@hotmail.com" + nl;
            value = Application.ProductName;
            label1.Text = (trans.GetSingleTranslation(ref value, "about", "ProductName", currentCulture.Name)) ? value : Application.ProductName;
        }
    }
}
