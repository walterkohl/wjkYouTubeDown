using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wjkYouTupe
{
    public partial class LangEditor : Form
    {
        DbLayer trans = new DbLayer("LangEditor", Properties.Settings.Default.Fallback);
        CultureInfo transCulture { get; set; }
        CultureInfo FallbackCulture { get; set; }
        Dictionary<string, object> controlObj = null;

        public LangEditor()
        {
            InitializeComponent();

            // Handle the Fallback language
            FallbackCulture = new CultureInfo(trans.Fallback);
            listEditLanguage.Items.Add("-----");
            listEditLanguage.DataSource = trans.GetTransLanguages();
            //listEditLanguage.Items.Remove(culture.Name);   // Geht nicht zusammen mit DataSource
            object[] temp = trans.LanguageInfo(FallbackCulture.Name, false);
            FlagName.Text = temp[0].ToString();
            ImgFallback.Image = (Image)temp[1];
            IntName.Text = FallbackCulture.EnglishName;
            NativName.Text = FallbackCulture.NativeName;

            // Handle the current culture
            object[] temp1 = trans.LanguageInfo(CultureInfo.CurrentCulture.Name, false);
            lblCurrentLang.Text = temp1[0].ToString();
            ImgCurrentLang.Image = (Image)temp1[1];
            langCurrInternName.Text = CultureInfo.CurrentCulture.EnglishName;
            langCurrNativeName.Text = CultureInfo.CurrentCulture.NativeName;

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
            string formName = listForms.SelectedItem.ToString();
            ListAllControls(formName);
        }
        
        private void ListAllControls(string formName)
        {
            listControls.Items.Clear();
            Form form = null;
            switch (formName)
            {
                case "about":
                    form = new about();
                    break;
                case "saving":
                    form = new saving();
                    break;
                case "LangEditor":
                    form = new LangEditor();
                    break;
                case "help":
                    form = new help();
                    break;
                case "video":
                    form = new video();
                    break;
                default:
                    form = new Start();
                    break;
            }
            int x = 0;
            controlObj = new Dictionary<string, object>();
            foreach (Control c in form.Controls)
            {
                controlObj.Add(c.Name, c);
                listControls.Items.Add(controlObj.ElementAt(x).Key);
                x++;
            }
        }

        private void listControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTemp = listControls.SelectedIndex;
            Control contTemp = controlObj.ElementAt(intTemp).Value as Control;
            textControl.Text = contTemp.Text;
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
        }

        private void BtnEditRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string selLanguage = listEditLanguage.SelectedItem.ToString();
                var result = MessageBox.Show("Wollen Sie diese Sprache " + selLanguage + " wirklich loeschen?", "Sprache entfernen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this.FallbackCulture.Name == selLanguage || CultureInfo.CurrentCulture.Name == selLanguage)
                    {
                        MessageBox.Show("Die Fallback und die derzeit ausgewaehlte Sprachen koennen nicht geloescht werden.", "Loeschen nicht moeglich!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lblSelectFormular_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string formName = listForms.SelectedItem.ToString();
            string langName = listEditLanguage.SelectedItem.ToString();
            Dictionary<string, string> AllFormControls = trans.GetAllFormControls(langName, formName);
            foreach(string key in AllFormControls.Keys)
            {
                listDBKeys.Items.Add(key);
            }
        }

        private void listDBKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Value = string.Empty;
            if (trans.TryGetSingleTranslation(out _Value, listDBKeys.SelectedItem.ToString(), listForms.SelectedItem.ToString(), this.FallbackCulture.Name))
            {
                TxtFallback.Text = _Value;
            }
            else
            {
                TxtFallback.Text = "*** Nichts gefunden! ***";
            }
            _Value = string.Empty;
            if (trans.TryGetSingleTranslation(out _Value, listDBKeys.SelectedItem.ToString(), listForms.SelectedItem.ToString(), this.transCulture.Name))
            {
                TxtTrans.Text = _Value;
            }
            else
            {
                TxtTrans.Text = "*** Nichts gefunden! ***";
            }
        }
    }
}
