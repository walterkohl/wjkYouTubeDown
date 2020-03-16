using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class saving : Form
    {
        int sec = 0; int min = 0;
        public saving()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }


        public void Timer_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                sec = 0; min++;
            }
            lblTimer.Text = String.Format("{0}:{1} Minuten", min, sec);
            progressBar1.Value = (progressBar1.Value >= 60) ? 1 : progressBar1.Value + 1;
        }

        private void form_showen(object sender, EventArgs e)
        {
            sec = 0; min = 0;
            progressBar1.Value = 1;
        }
    }
}
