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
    public partial class start : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE("start", Properties.Settings.Default.Language, Properties.Settings.Default.Fallback);
        YouTubeVideo video = null;
        saving form1 = null;
        bool isInit = true;
        public start()
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
            TransControls(isInit);
            isInit = false;
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string uri = TxtUri.Text.Trim();
                if (uri == "trans")
                {
                    TxtUri.Text = string.Empty;
                    langeditor form = new langeditor();
                    form.ShowDialog();
                }
                else
                {
                    if (radioYouTube.Checked && !uri.StartsWith("https://www.youtube.com/watch"))
                    {
                        /// We not use the translation function like in this example bellow. It will work but only if there is a 
                        /// expression in the database otherwise a string.Empty comes back. Therfor use the override what we use.
                        /// With this override NO record is inserted, when it not exists. You need a other override to get this function.
                        /// DialogResult result = MessageBox.Show(trans.GetSingleTranslation("NoYouTube1") + "\r\n" + trans.GetSingleTranslation("NoYouTube2"), trans.GetSingleTranslation("NoYouTube3"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        DialogResult result = MessageBox.Show(trans.GetSingleTranslation("NoYouTube1", trans.getLang(), trans.getForm(), trans.getFallback()) + 
                            "\r\n" + trans.GetSingleTranslation("NoYouTube2", trans.getLang(), trans.getForm(), trans.getFallback()), 
                            trans.GetSingleTranslation("NoYouTube3", trans.getLang(), trans.getForm(), trans.getFallback()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            radioYouTube.Checked = false;
                            radioURL.Checked = true;
                        }
                    }
                    else if (radioURL.Checked && uri.StartsWith("https://www.youtube.com/watch"))
                    {
                        DialogResult result = MessageBox.Show(trans.GetSingleTranslation("IsYouTube1", trans.getLang(), trans.getForm(), trans.getFallback()) + "\r\n" + 
                            trans.GetSingleTranslation("IsYouTube2", trans.getLang(), trans.getForm(), trans.getFallback()), 
                            trans.GetSingleTranslation("IsYouTube3", trans.getLang(), trans.getForm(), trans.getFallback()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                        
                        int x = -1;
                        HttpWebRequest test = null;
                        WebRequest fileReq = (WebRequest)WebRequest.Create(uri);
                        if (WebRequest.Equals(fileReq, test))
                        {
                            HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                            //if (fileResp.StatusCode != HttpStatusCode.OK) { throw new Exception(trans.GetSingleTranslation("Exception1")); }
                            x = uri.LastIndexOf('/');
                            TxtName.Text = uri.Substring(x + 1, uri.Length - (x + 1));
                            x = TxtName.Text.LastIndexOf('.');
                            TxtName.Text = TxtName.Text.Substring(0, x);
                            fileResp.Close();
                        }
                        else
                        {
                            /// All this of the FileWebRequest is just for fun. Nobody want to copy a file by this way. But to test the
                            /// application without the internet it works fine. It is nowhere documented.

                            FileWebResponse fileResp = (FileWebResponse)fileReq.GetResponse();
                            x = uri.LastIndexOf('\\');
                            TxtName.Text = uri.Substring(x + 1, uri.Length - (x + 1));
                            x = TxtName.Text.LastIndexOf('.');
                            TxtName.Text = TxtName.Text.Substring(0, x);
                            fileResp.Close();
                        }

                    }
                    TxtName.Text = NormelizeFileName(TxtName.Text);
                    button3.Enabled = true;
                    BtnPreviewURL.Enabled = true;
                    radioURL.Enabled = false; radioYouTube.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                /// Here we using to overrides for the function GetSingleTranslation first a long form (four values) and second the short
                /// form (two values). We would say: use the long form because if no expression for the language is found, the short form
                /// returns a string.Empty. The long form returns the the the string of the Fallback language.
                
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()), trans.GetSingleTranslation("Exception22", "all"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        public string NormelizeFileName(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()), 
                    trans.GetSingleTranslation("Exception22", trans.getLang(), "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
                return String.Empty;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (radioYouTube.Checked)
            {
                TxtInfos.Text = trans.GetSingleTranslation("Infotext1", trans.getLang(), trans.getForm(), trans.getFallback()) + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext2", trans.getLang(), trans.getForm(), trans.getFallback()) + video.Title + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext3", trans.getLang(), trans.getForm(), trans.getFallback()) + TxtName.Text + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext4", trans.getLang(), trans.getForm(), trans.getFallback()) + video.FileExtension + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext5", trans.getLang(), trans.getForm(), trans.getFallback()) + video.FullName + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext6", trans.getLang(), trans.getForm(), trans.getFallback()) + video.Resolution + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext7", trans.getLang(), trans.getForm(), trans.getFallback()) + video.Format + "\r\n";
            }
            else
            {
                string uri = TxtUri.Text.Trim();
                int x = uri.LastIndexOf('/');
                string name = uri.Substring(x + 1, uri.Length - (x + 1));
                x = uri.LastIndexOf('.');
                string ext = uri.Substring(x + 1, uri.Length - (x + 1));

                TxtInfos.Text = trans.GetSingleTranslation("Infotext8", trans.getLang(), trans.getForm(), trans.getFallback()) + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext9", trans.getLang(), trans.getForm(), trans.getFallback()) + name + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext10", trans.getLang(), trans.getForm(), trans.getFallback()) + TxtName.Text + "\r\n";
                TxtInfos.Text += trans.GetSingleTranslation("Infotext11", trans.getLang(), trans.getForm(), trans.getFallback()) + ext + "\r\n";
            }
            TxtInfos.Text += "URI: " + TxtUri.Text.Trim() + "\r\n";
            TxtInfos.Text += "\r\n" + "-----------------------" + "\r\n" + "\r\n";
            TxtInfos.Text += "\b" + trans.GetSingleTranslation("Infotext12", trans.getLang(), trans.getForm(), trans.getFallback()) + "\b";
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
                TxtInfos.Text += "\r\n" + "\r\n" + "-----------------------" + "\r\n" + "\r\n" + 
                    trans.GetSingleTranslation("Infotext13", trans.getLang(), trans.getForm(), trans.getFallback()) + TxtPath.Text + "\r\n" + "\r\n";
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
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()), 
                    trans.GetSingleTranslation("Exception22", trans.getLang(), "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnReset_Click(null, null);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(TxtPath.Text))
            {
                var response = MessageBox.Show(trans.GetSingleTranslation("MessageBoxOverwrite1", trans.getLang(), trans.getForm(), trans.getFallback()) + "\r\n" + 
                    trans.GetSingleTranslation("MessageBoxOverwrite2", trans.getLang(), trans.getForm(), trans.getFallback()), 
                    trans.GetSingleTranslation("MessageBoxOverwrite3", trans.getLang(), trans.getForm(), trans.getFallback()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                form1 = new saving();
                form1.Show();

                if (radioYouTube.Checked)
                {
                    SaveYouTube();
                }
                else
                {
                    HttpWebRequest test = null;
                    WebRequest fileReq = (WebRequest)WebRequest.Create(TxtUri.Text);
                    if (WebRequest.Equals(fileReq, test))
                    {
                        HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                        if (fileReq.ContentLength > 0)
                            fileResp.ContentLength = fileReq.ContentLength;
                        TxtInfos.Text += String.Format("{0}: {1} Byte" + "\r\n", trans.GetSingleTranslation("Infotext14"), fileResp.ContentLength);
                        saveFile(fileResp);
                    }
                    else
                    {
                        /// All this of the FileWebRequest is just for fun. Nobody want to copy a file by this way. But to test the
                        /// application without the internet it works fine. It is nowhere documented.

                        FileWebResponse fileResp = (FileWebResponse)fileReq.GetResponse();

                        if (fileReq.ContentLength > 0)
                            fileResp.ContentLength = fileReq.ContentLength;
                        TxtInfos.Text += String.Format("{0}: {1} Byte" + "\r\n", 
                            trans.GetSingleTranslation("Infotext14", trans.getLang(), trans.getForm(), trans.getFallback()), fileResp.ContentLength);
                        saveFile(fileResp);
                    }

                }
                if (CheckSaveInfo.Checked)
                {
                    int x = TxtPath.Text.LastIndexOf('.');
                    string path = TxtPath.Text.Substring(0, x) + "_info.txt";
                    TxtInfos.Text += "*** " + trans.GetSingleTranslation("Infotext15", trans.getLang(), trans.getForm(), trans.getFallback()) + " ***" + "\r\n";
                    TxtInfos.Text += "*** " + path + " ***" + "\r\n" + "\r\n";
                    File.WriteAllText(path, TxtInfos.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()), 
                    trans.GetSingleTranslation("Exception22", trans.getLang(), "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()), 
                    trans.GetSingleTranslation("Exception22", trans.getLang(), "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fileStream.Close();
                iostream.Close();
                form1.Close();
            }
        }
        /// <summary>
        /// All this of the FileWebRequest is just for fun. Nobody want to copy a file by this way. But to test the
        /// application without the internet it works fine. It is nowhere documented.
        /// </summary>
        /// <param name="fileResp"></param>
        private async void saveFile(FileWebResponse fileResp)
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
            about form2 = new about();
            _ = form2.ShowDialog();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            help form3 = new help();
            form3.Show();
        }

        private void BtnPreviewURL_Click(object sender, EventArgs e)
        {
            video form4 = new video();
            if (radioYouTube.Checked)
            {
                form4.VideoURL = video.Uri;
            }
            else
            {
                form4.VideoURL = TxtUri.Text.Trim();
            }
            form4.Show();
        }

        private void BtnPreviewFile_Click(object sender, EventArgs e)
        {
            video form4 = new video();
            form4.VideoURL = TxtPath.Text.Trim();
            form4.Show();
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
                TransControls(false);
            }
        }

        private void TransControls(bool IsEditable)
        {
            string value = this.Text;
            this.Text = (trans.GetSingleTranslation(ref value, "ActiveForm", IsEditable)) ? value : this.Text;
            value = ReadFile.Text;
            ReadFile.Text = (trans.GetSingleTranslation(ref value, "ReadFile.Text", IsEditable)) ? value : ReadFile.Text;
            value = radioYouTube.Text;
            radioYouTube.Text = (trans.GetSingleTranslation(ref value, "radioYouTube.Text", IsEditable)) ? value: radioYouTube.Text;
            value = radioURL.Text;
            radioURL.Text = (trans.GetSingleTranslation(ref value, "radioURL.Text", IsEditable)) ? value: radioURL.Text;
            value = label5.Text;
            label5.Text = (trans.GetSingleTranslation(ref value, "label5.Text", IsEditable)) ? value: label5.Text;
            value = label4.Text;
            label4.Text = (trans.GetSingleTranslation(ref value, "label4.Text", IsEditable)) ? value: label4.Text;
            value = label2.Text;
            label2.Text = (trans.GetSingleTranslation(ref value, "label2.Text", IsEditable)) ? value: label2.Text;
            value = label1.Text;
            label1.Text = (trans.GetSingleTranslation(ref value, "label1.Text", IsEditable)) ? value: label1.Text;
            value = groupURL.Text;
            groupURL.Text = (trans.GetSingleTranslation(ref value, "groupURL.Text", IsEditable)) ? value: groupURL.Text;
            value = CheckSaveInfo.Text;
            CheckSaveInfo.Text = (trans.GetSingleTranslation(ref value, "CheckSaveInfo.Text", IsEditable)) ? value: CheckSaveInfo.Text;
            value = button3.Text;
            button3.Text = (trans.GetSingleTranslation(ref value, "button3.Text", IsEditable)) ? value: button3.Text;
            value = button2.Text;
            button2.Text = (trans.GetSingleTranslation(ref value, "button2.Text", IsEditable)) ? value: button2.Text;
            value = button1.Text;
            button1.Text = (trans.GetSingleTranslation(ref value, "button1.Text", IsEditable)) ? value: button1.Text;
            value = BtnReset.Text;
            BtnReset.Text = (trans.GetSingleTranslation(ref value, "BtnReset.Text", IsEditable)) ? value: BtnReset.Text;
            value = BtnPreviewFile.Text;
            BtnPreviewFile.Text = (trans.GetSingleTranslation(ref value, "BtnPreviewFile.Text")) ? value: BtnPreviewFile.Text;
            value = BtnHelp.Text;
            BtnHelp.Text = (trans.GetSingleTranslation(ref value, "BtnHelp.Text", IsEditable)) ? value: BtnHelp.Text;
            value = BtnAbout.Text;
            BtnAbout.Text = (trans.GetSingleTranslation(ref value, "BtnAbout.Text", IsEditable)) ? value: BtnAbout.Text;
        }
    }
}
