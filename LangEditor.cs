using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class langeditor : Form
    {
        DbLayerSQLCE trans = new DbLayerSQLCE("LangEditor", CultureInfo.CurrentCulture.Name, Properties.Settings.Default.Fallback);
        CultureInfo transCulture { get; set; }
        CultureInfo FallbackCulture { get; set; }
        CultureInfo currentCulture { get; set; }
        Dictionary<string, object> controlObj = null;

        public langeditor()
        {
            InitializeComponent();

            // Handle the Fallback language
            FallbackCulture = new CultureInfo(trans.getFallback());
            listEditLanguage.Items.Add("-----");
            listEditLanguage.DataSource = trans.GetTransLanguages();
            //listEditLanguage.Items.Remove(culture.Name);   // Geht nicht zusammen mit DataSource
            object[] temp = trans.LanguageInfo(FallbackCulture.Name, false);
            FlagName.Text = temp[0].ToString();
            ImgFallback.Image = (Image)temp[1];
            IntName.Text = FallbackCulture.EnglishName;
            NativName.Text = FallbackCulture.NativeName;

            // Handle the current culture
            currentCulture = CultureInfo.CurrentCulture;
            object[] temp1 = trans.LanguageInfo(currentCulture.Name, false);
            lblCurrentLang.Text = temp1[0].ToString();
            ImgCurrentLang.Image = (Image)temp1[1];
            langCurrInternName.Text = currentCulture.EnglishName;
            langCurrNativeName.Text = currentCulture.NativeName;

            SetAllLangNames();
            ListAllForms();
        }

        private void SetAllLangNames()
        {
            listNewLanguage.Items.Clear();
            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            foreach (CultureInfo cul in cinfo)
            {
                if (cul.Name.Length == 5)
                {
                    listNewLanguage.Items.Add(cul.Name);
                }
            }
            for (int x = 0; x < listEditLanguage.Items.Count; x++)
            {
                listNewLanguage.Items.Remove(listEditLanguage.Items[x].ToString());
            }
        }

        private void listNewLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            object[] temp = trans.LanguageInfo(listNewLanguage.SelectedItem.ToString(), true);
            lblAddLang.Text = temp[0].ToString();
            ImgAddLang.Image = (Image)temp[1];
            BtnAddLang.Enabled = true;
        }

        private void BtnAddLang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblAddLang.Text = string.Empty;
            ImgAddLang.Image = null;
            BtnAddLang.Enabled = false;
            trans.InsertInDB("all", listNewLanguage.SelectedItem.ToString(), "Lang", "no value");
            listEditLanguage.DataSource = trans.GetTransLanguages();
            SetAllLangNames();
        }

        private void BtnEditRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string selLanguage = listEditLanguage.SelectedItem.ToString();
                string MBText1 = "Wollen Sie diese Sprache wirklich loeschen?"; string value = MBText1;
                MBText1 = (trans.GetSingleTranslation(ref value, "MBText1", true)) ? value : MBText1;
                string MBText2 = "Sprache entfernen"; value = MBText2;
                MBText2 = (trans.GetSingleTranslation(ref value, "MBText2", true)) ? value : MBText2;
                var result = MessageBox.Show(MBText1 + ": " + selLanguage, MBText2, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this.FallbackCulture.Name == selLanguage || CultureInfo.CurrentCulture.Name == selLanguage)
                    {
                        string MBText3 = "Die Fallback und die derzeit ausgewaehlte Sprachen koennen nicht geloescht werden."; value = MBText3;
                        MBText3 = (trans.GetSingleTranslation(ref value, "MBText3", true)) ? value : MBText3;
                        string MBText4 = "Loeschen nicht moeglich!"; value = MBText4;
                        MBText4 = (trans.GetSingleTranslation(ref value, "MBText4", true)) ? value : MBText4;
                        MessageBox.Show(MBText3, MBText4, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        trans.DeleteLanguage(listEditLanguage.SelectedItem.ToString());
                        listEditLanguage.DataSource = trans.GetTransLanguages();
                        SetAllLangNames();
                    }
                }
            }
            catch
            { }
        }

        private void BtnEditLang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tempName = listEditLanguage.SelectedItem.ToString();
            this.transCulture = new CultureInfo(tempName);
            lblTransCulture.Text = this.transCulture.Name;
            object[] temp = trans.LanguageInfo(this.transCulture.Name, false);
            EditFlagName.Text = temp[0].ToString();
            ImgEditFlag.Image = (Image)temp[1];
            EditNativName.Text = this.transCulture.NativeName;
            BtnDelete.Visible = transCulture.Name == FallbackCulture.Name;
        }

        private void ListAllForms()
        {
            Type formType = typeof(Form);
            foreach (Type type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (formType.IsAssignableFrom(type))
                {
                    listForms.Items.Add(type.Name);
                }
            }
        }

        private void listForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectFormular.Enabled = true;
        }

        private void lblSelectFormular_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listDBKeys.Items.Clear();
            string formName = listForms.SelectedItem.ToString();
            string langName = listEditLanguage.SelectedItem.ToString();
            Dictionary<string, string> AllFormControls = trans.GetAllFormControls(formName);
            foreach(string key in AllFormControls.Keys)
            {
                listDBKeys.Items.Add(key);
            }
        }

        private void listDBKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAnser.Visible = false;
            BtnInsert.Enabled = true;
            BtnDelete.Enabled = true;
            BtnSave.Enabled = true;

            string _Value = string.Empty;
            if (trans.GetSingleTranslation(ref _Value, listForms.SelectedItem.ToString(), listDBKeys.SelectedItem.ToString(), this.FallbackCulture.Name))
            {
                TxtFallback.Text = _Value;
            }
            else
            {
                _Value = "*** Nichts gefunden! ***";
                TxtFallback.Text = (trans.GetSingleTranslation(ref _Value, "all", "NothingFound", FallbackCulture.Name)) ? _Value : "*** Nichts gefunden! ***";
            }
            _Value = string.Empty;
            if (trans.GetSingleTranslation(ref _Value, listForms.SelectedItem.ToString(), listDBKeys.SelectedItem.ToString(), this.transCulture.Name))
            {
                TxtTrans.Text = _Value;
                BtnSave.Visible = true; BtnInsert.Visible = false;
            }
            else
            {
                _Value = "*** Nichts gefunden! ***";
                TxtTrans.Text = (trans.GetSingleTranslation(ref _Value, "all", "NothingFound", CultureInfo.CurrentCulture.Name)) ? _Value : "*** Nichts gefunden! ***";
                BtnSave.Visible = false; BtnInsert.Visible = true;
            }
        }

        private void BtnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BtnSave.Enabled = false;
           if (trans.UpdateDB(listForms.SelectedItem.ToString(), this.transCulture.Name, listDBKeys.SelectedItem.ToString(), TxtTrans.Text))
            {
                lblAnser.Text = "Gespeichert!"; lblAnser.ForeColor = System.Drawing.Color.Green;
                string Value = lblAnser.Text;
                lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Saved", true)) ? Value : lblAnser.Text;
            }
            else
            {
                lblAnser.Text = "FEHLER!"; lblAnser.ForeColor = System.Drawing.Color.Red;
                string Value = lblAnser.Text;
                lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Fehler", true)) ? Value : lblAnser.Text;
            }
            lblAnser.Visible = true;
        }

        private void BtnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string MBText5 = "Es werden alle Datensaetze geloescht, die diesen Key besitzen! Fortfahren?"; string value = MBText5;
            MBText5 = (trans.GetSingleTranslation(ref value, "MBText5", true)) ? value : MBText5;
            string MBText6 = "Datensaetze loeschen"; value = MBText6;
            MBText6 = (trans.GetSingleTranslation(ref value, "MBText6", true)) ? value : MBText6;
            var answer = MessageBox.Show(MBText5, MBText6, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                BtnDelete.Enabled = false;
                if (trans.DeleteRecord(listForms.SelectedItem.ToString(), listDBKeys.SelectedItem.ToString()))
                {
                    lblAnser.Text = "Geloescht!"; lblAnser.ForeColor = System.Drawing.Color.Green;
                    string Value = lblAnser.Text;
                    lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Deleted", true)) ? Value : lblAnser.Text;
                }
                else
                {
                    lblAnser.Text = "FEHLER!"; lblAnser.ForeColor = System.Drawing.Color.Red;
                    string Value = lblAnser.Text;
                    lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Fehler", true)) ? Value : lblAnser.Text;
                }
                lblAnser.Visible = true;
            }
        }

        private void BtnInsert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BtnInsert.Enabled = false;
            if (trans.InsertInDB(listForms.SelectedItem.ToString(), this.transCulture.Name, listDBKeys.SelectedItem.ToString(), TxtTrans.Text))
            {
                lblAnser.Text = "Gespeichert!"; lblAnser.ForeColor = System.Drawing.Color.Green;
                string Value = lblAnser.Text;
                lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Saved", true)) ? Value : lblAnser.Text;
            }
            else
            {
                lblAnser.Text = "FEHLER!"; lblAnser.ForeColor = System.Drawing.Color.Red;
                string Value = lblAnser.Text;
                lblAnser.Text = (trans.GetSingleTranslation(ref Value, "lblAnser.Fehler", true)) ? Value : lblAnser.Text;
            }
            lblAnser.Visible = true;
        }

        private void linkFullBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = Application.ProductName + " - Full Backup",
                    ValidateNames = true,
                    //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    AddExtension = true,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    DefaultExt = "xml",
                    FileName = "wjk-VideoDown_FullBackup_" + DateTime.UtcNow.ToShortDateString().Replace('.', '_') + ".xml",
                    Filter = "Backup (*.xml)|*.xml|All Files (*.*)|*.*",
                    RestoreDirectory = true
                };
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.Abort || result == DialogResult.Cancel) { throw new Exception("File save dialog aborted or canceld"); }
                string path = saveFileDialog.FileName;
                DataSet dsData = trans.GetAllTranslations();
                int rowCount = dsData.Tables[0].Rows.Count;
                Form form = new saving();
                form.Show();
                dsData.Tables[0].WriteXml(path);
                form.Close();
                string MBText7 = "Datensaetze wurden beim Gesamtbackup gespeichert"; string value = MBText7;
                MBText7 = (trans.GetSingleTranslation(ref value, "MBText7", true)) ? value : MBText7;
                string MBText8 = "Der Dateipfad ist"; value = MBText8;
                MBText8 = (trans.GetSingleTranslation(ref value, "MBText8", true)) ? value : MBText8;
                string MBText9 = string.Format("{0} - Result", Application.ProductName);
                MessageBox.Show(rowCount + " " + MBText7 + ",\r\n" + MBText8 + ":\r\n" + path, MBText9, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", currentCulture.Name, "all", trans.getFallback()),
                    trans.GetSingleTranslation("Exception22", currentCulture.Name, "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLangBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string ErrorText = "Du musst zunaechst eine Sprache zum editiern auswaehlen. Sie wird auch Deine Backup-Sprache sein."; string value = ErrorText;
            ErrorText = (trans.GetSingleTranslation(ref value, "ErrorText", true)) ? value : ErrorText;
            try
            {
                if (transCulture == null || string.IsNullOrEmpty(transCulture.Name)) { throw new Exception(ErrorText); }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = Application.ProductName + " - Language Backup",
                    ValidateNames = true,
                    //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    AddExtension = true,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    DefaultExt = "xml",
                    FileName = "wjk-VideoDown_LangBackup_" + transCulture.Name + "_" + DateTime.UtcNow.ToShortDateString().Replace('.', '_') + ".xml",
                    Filter = "Backup (*.xml)|*.xml|All Files (*.*)|*.*",
                    RestoreDirectory = true
                };
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.Abort || result == DialogResult.Cancel) { throw new Exception("File save dialog aborted or canceld"); }
                string path = saveFileDialog.FileName;
                DataSet dsData = trans.GetTranslationByLang(transCulture.Name);
                int rowCount = dsData.Tables[0].Rows.Count;
                Form form = new saving();
                form.Show();
                dsData.Tables[0].WriteXml(path);
                form.Close();
                string MBText10 = "Datensaetze wurden beim Sprachenbackup gespeichert"; value = MBText10;
                MBText10 = (trans.GetSingleTranslation(ref value, "MBText10", true)) ? value : MBText10;
                string MBText11 = "Der Dateipfad ist"; value = MBText11;
                MBText11 = (trans.GetSingleTranslation(ref value, "MBText11", true)) ? value : MBText11;
                string MBText12 = string.Format("{0} - Result", Application.ProductName);
                MessageBox.Show(rowCount + " " + MBText10 + ".\r\n" + MBText11 + ":\r\n" + path, MBText12, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + trans.GetSingleTranslation("Exception21", trans.getLang(), "all", trans.getFallback()),
                    trans.GetSingleTranslation("Exception22", trans.getLang(), "all", trans.getFallback()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LangEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            trans.setForm("start");
        }
    }
}
