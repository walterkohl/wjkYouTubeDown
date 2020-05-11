using System;
using System.Globalization;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class video : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE();
        readonly CultureInfo currentCulture = CultureInfo.CurrentCulture;
        public video()
        {
            InitializeComponent();
            string value = this.Text;
            this.Text = (trans.GetSingleTranslation(ref value, "video", "ActiveForm", currentCulture.Name)) ? value : this.Text;
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
