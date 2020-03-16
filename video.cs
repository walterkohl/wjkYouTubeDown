using System;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class video : Form
    {

        public video()
        {
            InitializeComponent();

        }

        public string VideoURL { get; set; }

        private void video_load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = this.VideoURL;
            axWindowsMediaPlayer1.settings.autoStart = true;
        }

        private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            this.Close();
        }
    }
}
