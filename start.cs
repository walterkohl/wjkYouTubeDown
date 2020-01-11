using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;

namespace wjkYouTupe
{
    public partial class Start : Form
    {
        YouTubeVideo video = null;

        public Start()
        {
            InitializeComponent();
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string uri = TxtUri.Text.Trim();
                var youTube = YouTube.Default;
                video = youTube.GetVideo(uri);
                TxtName.Text = video.Title;
                button3.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n"+"Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TxtInfos.Text = "Originaltitel: " + video.Title + "\r\n";
            TxtInfos.Text += "Speichername: " + TxtName.Text + "\r\n";
            TxtInfos.Text += "Erweiterung: " + video.FileExtension + "\r\n";
            TxtInfos.Text += "Ganzer Mame: " + video.FullName + "\r\n";
            TxtInfos.Text += "Auflösung: " + video.Resolution + "\r\n";
            TxtInfos.Text += "Videoformat: " + video.Format + "\r\n" + "\r\n";
            TxtInfos.Text += "URI: " + TxtUri.Text.Trim() + "\r\n";
            TxtName.ReadOnly = true;
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.Description = "Wähle das Verzeichnis zum Speichern aus";
                folderBrowserDialog1.ShowDialog();
                TxtPath.Text = Path.Combine(folderBrowserDialog1.SelectedPath, TxtName.Text + video.FileExtension);
                TxtInfos.Text += "Speicherort: " + TxtPath.Text + "\r\n" + "\r\n";
                TxtInfos.ReadOnly = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ReadFile.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                TxtPath.ReadOnly = true;
                if (File.Exists(TxtPath.Text))
                {
                    label6.Visible = true;
                    TxtPath.ReadOnly = false;
                    button2.Enabled = true;
                }
                else
                {
                    label5.Visible = true;
                    File.WriteAllBytes(TxtPath.Text, video.GetBytes());
                    if (CheckSaveInfo.Checked)
                    {
                        int x = TxtPath.Text.IndexOf(video.FileExtension);
                        string path = TxtPath.Text.Substring(0, x) + "_info.txt";
                        TxtInfos.Text += "*** Diese Informationen werden gespeichert unter:  ***" + "\r\n";
                        TxtInfos.Text += "*** " + path + " ***" + "\r\n" + "\r\n";
                        label7.Text += path; label7.Visible = true;
                        File.WriteAllText(path, TxtInfos.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            BtnReset_Click(null, null);
        }

        private void TxtUri_TextChanged(object sender, EventArgs e)
        {
            ReadFile.Enabled = true;
            label7.Text = "Info-Datei gespeichert unter: ";
            label7.Visible = false;
        }

        private void TxtPath_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ReadFile.Enabled = true;
            label5.Visible = false;
            
            TxtName.ReadOnly = false;
            TxtInfos.ReadOnly = false;
            TxtPath.ReadOnly = false;
            TxtUri.Text = string.Empty;
            TxtName.Text = string.Empty;
            TxtInfos.Text = string.Empty;
            TxtPath.Text = string.Empty;
            CheckSaveInfo.Checked = true;
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            about form = new about();
            _ = form.ShowDialog();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
        }
    }
}
