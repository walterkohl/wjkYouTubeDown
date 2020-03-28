using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using VideoLibrary;

namespace wjkYouTupe
{
    public partial class Start : Form
    {
        DbLayer trans = new DbLayer("start", Properties.Settings.Default.Fallback);
        YouTubeVideo video = null;
        saving form1 = null;
        bool isInit = true;
        public Start()
        {
            InitializeComponent();

            isInit = true;
            DdLang.DataSource = trans.GetTransLanguages();
            DdLang.SelectedItem = Properties.Settings.Default.Language;
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.Language);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            Application.CurrentCulture = culture;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(culture);
            object[] test = trans.LanguageInfo(culture.Name, false);
            SelectedLang.Text = test[0].ToString();
            pictureBox1.Image = (Image)test[1];
            TransControls();
            isInit = false;
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            form1 = new saving();
            try
            {
                string uri = TxtUri.Text.Trim();
                if (uri == "trans")
                {
                    TxtUri.Text = string.Empty;
                    LangEditor form = new LangEditor();
                    form.ShowDialog();
                }
                else
                {
                    if (radioYouTube.Checked && !uri.StartsWith("https://www.youtube.com/watch"))
                    {
                        DialogResult result = MessageBox.Show(trans.GetSingleTranslation("NoYouTube1") + "\r\n" + trans.GetSingleTranslation("NoYouTube2"), trans.GetSingleTranslation("NoYouTube3"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            radioYouTube.Checked = false;
                            radioURL.Checked = true;
                        }
                    }
                    else if (radioURL.Checked && uri.StartsWith("https://www.youtube.com/watch"))
                    {
                        DialogResult result = MessageBox.Show(trans.GetSingleTranslation("IsYouTube1") + "\r\n" + trans.GetSingleTranslation("IsYouTube2"), trans.GetSingleTranslation("IsYouTube3"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                        if (fileResp.StatusCode != HttpStatusCode.OK) { throw new Exception(trans.GetSingleTranslation("Exception1")); }
                        int x = uri.LastIndexOf('/');
                        TxtName.Text = uri.Substring(x + 1, uri.Length - (x + 1));
                        x = TxtName.Text.LastIndexOf('.');
                        TxtName.Text = TxtName.Text.Substring(0, x);
                        fileResp.Close();
                    }
                    TxtName.Text = NormelizeFileName(TxtName.Text);
                    button3.Enabled = true;
                    BtnPreviewURL.Enabled = true;
                    radioURL.Enabled = false; radioYouTube.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", "all"), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", "all"), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
                return String.Empty;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (radioYouTube.Checked)
            {
                TxtInfos.Text = trans.GetSingleTranslation("Infotext1") + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext2") + video.Title + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext3") + TxtName.Text + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext4") + video.FileExtension + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext5") + video.FullName + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext6") + video.Resolution + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext7") + video.Format + "\r\n";
            }
            else
            {
                string uri = TxtUri.Text.Trim();
                int x = uri.LastIndexOf('/');
                string name = uri.Substring(x + 1, uri.Length - (x + 1));
                x = uri.LastIndexOf('.');
                string ext = uri.Substring(x + 1, uri.Length - (x + 1));

                TxtInfos.Text = trans.GetSingleTranslation("Infotext8") + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext9") + name + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext10") + TxtName.Text + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext11") + ext + "\r\n";
            }
            TxtInfos.Text += "URI: " + TxtUri.Text.Trim() + "\r\n";
            TxtInfos.Text += "\r\n" + "-----------------------" + "\r\n" + "\r\n";
            TxtInfos.Text += "\b" + trans.GetSingleTranslation("Infotext12") + "\b";
            TxtName.ReadOnly = true;
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.DownloadPath))
                {
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
                }
                else
                {
                    folderBrowserDialog1.SelectedPath = Properties.Settings.Default.DownloadPath;
                }
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.Description = trans.GetSingleTranslation("folderBrowserDialog1");
                folderBrowserDialog1.ShowDialog();
                string uri = TxtUri.Text.Trim();
                int x = uri.LastIndexOf('.');
                string ext = uri.Substring(x, uri.Length - x);
                TxtPath.Text = Path.Combine(folderBrowserDialog1.SelectedPath, TxtName.Text);
                TxtPath.Text += (radioYouTube.Checked) ? video.FileExtension : ext;
                TxtInfos.Text += "\r\n" + "\r\n" + "-----------------------" + "\r\n" + "\r\n" + trans.GetSingleTranslation("Infotext13") + TxtPath.Text + "\r\n" + "\r\n";
                TxtInfos.ReadOnly = true;
                button2.Enabled = true;
                if (checkRememberPath.Checked)
                {
                    Properties.Settings.Default.DownloadPath = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", "all"), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(TxtPath.Text))
            {
                var response = MessageBox.Show(trans.GetSingleTranslation("MessageBoxOverwrite1") + "\r\n" + trans.GetSingleTranslation("MessageBoxOverwrite2"), trans.GetSingleTranslation("MessageBoxOverwrite3"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    SaveDatei();
                }
            }
            else
            {
                SaveDatei();
            }
        }

        private void SaveDatei()
        {
            ReadFile.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            TxtPath.ReadOnly = true;

            try
            { 
                label5.Visible = true;
                form1.Show();

                if (radioYouTube.Checked)
                {
                    SaveYouTube();
                }
                else
                {
                    try
                    {
                        HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(TxtUri.Text);
                        HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                        if (fileReq.ContentLength > 0)
                            fileResp.ContentLength = fileReq.ContentLength;
                        TxtInfos.Text += String.Format("{0}: {1} Byte" + "\r\n", trans.GetSingleTranslation("Infotext14"), fileResp.ContentLength);
                        saveFile(fileResp);
                    }
                    finally
                    { }
                }
                if (CheckSaveInfo.Checked)
                {
                    int x = TxtPath.Text.LastIndexOf('.');
                    string path = TxtPath.Text.Substring(0, x) + "_info.txt";
                    TxtInfos.Text += "*** " + trans.GetSingleTranslation("Infotext15") + " ***" + "\r\n";
                    TxtInfos.Text += "*** " + path + " ***" + "\r\n" + "\r\n";
                    File.WriteAllText(path, TxtInfos.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", "all"), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPath.ReadOnly = false;
                button2.Enabled = true;
            }
            finally
            {
                BtnPreviewFile.Enabled = true;
                label5.Visible = false;
            }
        }

        private async void SaveYouTube()
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
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", "all"), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        { }

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

        private void DdLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInit)
            {
                CultureInfo culture = new CultureInfo(DdLang.SelectedItem.ToString());
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                Application.CurrentCulture = culture;
                Application.CurrentInputLanguage = InputLanguage.FromCulture(culture);
                Properties.Settings.Default.Language = culture.Name;
                Properties.Settings.Default.Save();
                object[] test = trans.LanguageInfo(Properties.Settings.Default.Language);
                SelectedLang.Text = test[0].ToString();
                pictureBox1.Image = (Image)test[1];
                trans.setLang(culture.Name);
                TransControls();
            }
        }

        private void TransControls()
        {
            ReadFile.Text = trans.GetSingleTranslation("ReadFile.Text");
            radioYouTube.Text = trans.GetSingleTranslation("radioYouTube.Text");
            radioURL.Text = trans.GetSingleTranslation("radioURL.Text");
            label5.Text = trans.GetSingleTranslation("label5.Text");
            label4.Text = trans.GetSingleTranslation("label4.Text");
            label3.Text = trans.GetSingleTranslation("label3.Text");
            label2.Text = trans.GetSingleTranslation("label2.Text");
            label1.Text = trans.GetSingleTranslation("label1.Text");
            groupURL.Text = trans.GetSingleTranslation("groupURL.Text");
            CheckSaveInfo.Text = trans.GetSingleTranslation("CheckSaveInfo.Text");
            button3.Text = trans.GetSingleTranslation("button3.Text");
            button2.Text = trans.GetSingleTranslation("button2.Text");
            button1.Text = trans.GetSingleTranslation("button1.Text");
            BtnReset.Text = trans.GetSingleTranslation("BtnReset.Text");
            BtnPreviewFile.Text = trans.GetSingleTranslation("BtnPreviewFile.Text");
            BtnHelp.Text = trans.GetSingleTranslation("BtnHelp.Text");
            BtnAbout.Text = trans.GetSingleTranslation("BtnAbout.Text");
        }
    }
}
