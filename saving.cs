using System;
using System.Globalization;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class saving : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE();
        readonly CultureInfo currentCulture = CultureInfo.CurrentCulture;
        int sec = 0; int min = 0;
        string minuten = "Sekunden";
        public saving()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
            string value = this.Text;
            this.Text = (trans.GetSingleTranslation(ref value, "saving", "ActiveForm", currentCulture.Name)) ? value : this.Text;
            value = label1.Text;
            label1.Text = (trans.GetSingleTranslation(ref value, "saving", "label1", currentCulture.Name)) ? value : label1.Text;
            value = minuten;
            minuten = (trans.GetSingleTranslation(ref value, "saving", "minuten", currentCulture.Name)) ? value : minuten;
        }


        public void Timer_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 60)
            {
                sec = 0; min++;
                minuten = "Minutes";
            }
            lblTimer.Text = String.Format("{0}:{1} {2}", min, sec, minuten);
            progressBar1.Value = (progressBar1.Value >= 60) ? 1 : progressBar1.Value + 1;
        }

        private void form_showen(object sender, EventArgs e)
        {
            sec = 0; min = 0;
            progressBar1.Value = 1;
        }

        private void saving_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }
    }
}
