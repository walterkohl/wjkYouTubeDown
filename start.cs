using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;
using System.Net;
using System.Web;

namespace wjkYouTupe
{
    public partial class Start : Form
    {
        YouTubeVideo video = null;
        saving form1 = null;
        public Start()
        {
            InitializeComponent();
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            form1 = new saving();
            try
            {
                label7.Text = "Info-Datei gespeichert unter: ";
                label7.Visible = false;
                string uri = TxtUri.Text.Trim();
                if (radioYouTube.Checked && !uri.StartsWith("https://www.youtube.com/watch"))
                {
                    DialogResult result = MessageBox.Show("Dies scheint kein YouTube-Link zu sein." + "\r\n" + "Soll ich zum Direktlink für Videos wechseln?", "Wechsel zu Video-URL",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        radioYouTube.Checked = false;
                        radioURL.Checked = true;
                    }
                }
                else if (radioURL.Checked && uri.StartsWith("https://www.youtube.com/watch"))
                {
                    DialogResult result = MessageBox.Show("Dies scheint ein YouTube-Link zu sein." + "\r\n" + "Soll ich zum Download für YouTube-Videos wechseln?", "Wechsel zu YouTube", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        radioYouTube.Checked = true;
                        radioURL.Checked = false;
                    }
                }

                if (radioYouTube.Checked)
                {
                    var youTube = YouTube.Default;
                    video = youTube.GetVideo(uri);
                    TxtName.Text = video.Title.Replace(" ", "_");
                }
                else
                {
                    // https://stackoverflow.com/questions/5596747/download-stream-file-from-url-asp-net

                    HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(uri);
                    HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();
                    if (fileResp.StatusCode != HttpStatusCode.OK) { throw new Exception("Ich konnte die Datei nicht laden..."); }
                    int x = uri.LastIndexOf('/');
                    TxtName.Text = uri.Substring(x+1, uri.Length - (x+1));
                    x = TxtName.Text.LastIndexOf('.');
                    TxtName.Text = TxtName.Text.Substring(0, x);
                    fileResp.Close();
                }
                TxtName.Text = NormelizeFileName(TxtName.Text);
                button3.Enabled = true;
                BtnPreviewURL.Enabled = true;
                radioURL.Enabled = false; radioYouTube.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n"+"Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        public string NormelizeFileName(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\-]", "",
                                        RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
                return String.Empty;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (radioYouTube.Checked)
            {
                TxtInfos.Text = "YouTube-Infos: " + "\r\n";
                TxtInfos.Text += "Originaltitel: " + video.Title + "\r\n";
                TxtInfos.Text += "Speichername: " + TxtName.Text + "\r\n";
                TxtInfos.Text += "Erweiterung: " + video.FileExtension + "\r\n";
                TxtInfos.Text += "Ganzer Name: " + video.FullName + "\r\n";
                TxtInfos.Text += "Auflösung: " + video.Resolution + "\r\n";
                TxtInfos.Text += "Videoformat: " + video.Format + "\r\n";
            }
            else
            {
                string uri = TxtUri.Text.Trim();
                int x = uri.LastIndexOf('/');
                string name = uri.Substring(x + 1, uri.Length - (x + 1));
                x = uri.LastIndexOf('.');
                string ext = uri.Substring(x + 1, uri.Length - (x + 1));

                TxtInfos.Text = "Selfmade-Infos: " + "\r\n";
                TxtInfos.Text += "Originaltitel: " + name + "\r\n";
                TxtInfos.Text += "Speichername: " + TxtName.Text + "\r\n";
                TxtInfos.Text += "Erweiterung: " + ext + "\r\n";
            }
            TxtInfos.Text += "URI: " + TxtUri.Text.Trim() + "\r\n" + "\r\n" + "-----------------------" + "\r\n" + "\r\n";
            TxtInfos.Text += "\b Platz für eigene Einträge... \b";
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
                string uri = TxtUri.Text.Trim();
                int x = uri.LastIndexOf('.');
                string ext = uri.Substring(x, uri.Length - x);
                TxtPath.Text = Path.Combine(folderBrowserDialog1.SelectedPath, TxtName.Text);
                TxtPath.Text += (radioYouTube.Checked) ? video.FileExtension : ext;
                TxtInfos.Text += "\r\n" + "\r\n" + "-----------------------" + "\r\n" + "\r\n" + "Speicherort: " + TxtPath.Text + "\r\n" + "\r\n";
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
                    form1.Show();

                    if (radioYouTube.Checked)
                    {
                        saveYouTube();
                    }
                    else
                    {
                        try
                        {
                            HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(TxtUri.Text);
                            HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                            if (fileReq.ContentLength > 0)
                                fileResp.ContentLength = fileReq.ContentLength;
                            TxtInfos.Text += String.Format("Dateigröße: {0} Byte" + "\r\n", fileResp.ContentLength);
                            saveFile(fileResp);
                        }
                        finally
                        {  }
                    }
                    if (CheckSaveInfo.Checked)
                    {
                        int x = TxtPath.Text.LastIndexOf('.');
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
                TxtPath.ReadOnly = false;
                button2.Enabled = true;
            }
            finally
            {
                BtnPreviewFile.Enabled = true;
                label5.Visible = false;
            }
        }

        private async void saveYouTube()
        {
            File.WriteAllBytes(TxtPath.Text, await video.GetBytesAsync());
            form1.Close();
        }
        private async void saveFile(HttpWebResponse fileResp)
        {
            FileStream fileStream = null;
            Stream iostream = null;

            try
            {
                iostream = fileResp.GetResponseStream();
                fileStream = new FileStream(TxtPath.Text, FileMode.Create, FileAccess.Write, FileShare.None);
                await iostream.CopyToAsync(fileStream);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "Bitte neu versuchen!", "Fehler beim Verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fileStream.Close();
                iostream.Close();
                form1.Close();
            }
        }

        private void TxtUri_TextChanged(object sender, EventArgs e)
        {
            ReadFile.Enabled = true;
        }

        private void TxtPath_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ReadFile.Enabled = true;
            label5.Visible = false;

            BtnPreviewURL.Enabled = false;
            button3.Enabled = false;
            radioURL.Enabled = true; 
            radioYouTube.Enabled = true;
            TxtName.ReadOnly = false;
            button1.Enabled = false;

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
            help form = new help();
            form.Show();
        }

        private void BtnPreviewURL_Click(object sender, EventArgs e)
        {
            video form = new video();
            if (radioYouTube.Checked)
            {
                form.VideoURL = video.Uri;
            }
            else
            {
                form.VideoURL = TxtUri.Text.Trim();
            }
            form.Show();
        }

        private void BtnPreviewFile_Click(object sender, EventArgs e)
        {
            video form = new video();
            form.VideoURL = TxtPath.Text.Trim();
            form.Show();
        }

    }
}
