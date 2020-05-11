namespace wjkYouTupe
{
    partial class langeditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(langeditor));
            this.label1 = new System.Windows.Forms.Label();
            this.listEditLanguage = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NativName = new System.Windows.Forms.Label();
            this.IntName = new System.Windows.Forms.Label();
            this.FlagName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentLang = new System.Windows.Forms.Label();
            this.listNewLanguage = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listForms = new System.Windows.Forms.ListBox();
            this.EditFlagName = new System.Windows.Forms.Label();
            this.EditNativName = new System.Windows.Forms.Label();
            this.ImgFallback = new System.Windows.Forms.PictureBox();
            this.BtnEditLang = new System.Windows.Forms.LinkLabel();
            this.ImgCurrentLang = new System.Windows.Forms.PictureBox();
            this.BtnAddLang = new System.Windows.Forms.LinkLabel();
            this.ImgAddLang = new System.Windows.Forms.PictureBox();
            this.lblAddLang = new System.Windows.Forms.Label();
            this.BtnEditRemove = new System.Windows.Forms.LinkLabel();
            this.langCurrInternName = new System.Windows.Forms.Label();
            this.langCurrNativeName = new System.Windows.Forms.Label();
            this.lblDBFunctions = new System.Windows.Forms.Label();
            this.listDBKeys = new System.Windows.Forms.ListBox();
            this.TxtFallback = new System.Windows.Forms.TextBox();
            this.TxtTrans = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTransCulture = new System.Windows.Forms.Label();
            this.ImgEditFlag = new System.Windows.Forms.PictureBox();
            this.lblSelectFormular = new System.Windows.Forms.LinkLabel();
            this.BtnSave = new System.Windows.Forms.LinkLabel();
            this.BtnDelete = new System.Windows.Forms.LinkLabel();
            this.BtnInsert = new System.Windows.Forms.LinkLabel();
            this.lblAnser = new System.Windows.Forms.Label();
            this.linkFullBackup = new System.Windows.Forms.LinkLabel();
            this.linkLangBackup = new System.Windows.Forms.LinkLabel();
            this.linkReadBackup = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ImgFallback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCurrentLang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAddLang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgEditFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprache zum Edoioeren";
            // 
            // listEditLanguage
            // 
            this.listEditLanguage.FormattingEnabled = true;
            this.listEditLanguage.ItemHeight = 20;
            this.listEditLanguage.Location = new System.Drawing.Point(282, 54);
            this.listEditLanguage.Name = "listEditLanguage";
            this.listEditLanguage.Size = new System.Drawing.Size(176, 104);
            this.listEditLanguage.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ausgangssprache: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(13, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fallback Language";
            // 
            // NativName
            // 
            this.NativName.AutoSize = true;
            this.NativName.Location = new System.Drawing.Point(13, 149);
            this.NativName.Name = "NativName";
            this.NativName.Size = new System.Drawing.Size(104, 20);
            this.NativName.TabIndex = 4;
            this.NativName.Text = "Nativer Name";
            // 
            // IntName
            // 
            this.IntName.AutoSize = true;
            this.IntName.Location = new System.Drawing.Point(13, 118);
            this.IntName.Name = "IntName";
            this.IntName.Size = new System.Drawing.Size(101, 20);
            this.IntName.TabIndex = 5;
            this.IntName.Text = "Intern. Name";
            // 
            // FlagName
            // 
            this.FlagName.AutoSize = true;
            this.FlagName.Location = new System.Drawing.Point(44, 88);
            this.FlagName.Name = "FlagName";
            this.FlagName.Size = new System.Drawing.Size(117, 20);
            this.FlagName.TabIndex = 6;
            this.FlagName.Text = "Flag and Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Derzeitige Sprache";
            // 
            // lblCurrentLang
            // 
            this.lblCurrentLang.AutoSize = true;
            this.lblCurrentLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentLang.Location = new System.Drawing.Point(44, 284);
            this.lblCurrentLang.Name = "lblCurrentLang";
            this.lblCurrentLang.Size = new System.Drawing.Size(117, 20);
            this.lblCurrentLang.TabIndex = 8;
            this.lblCurrentLang.Text = "Flag and Name";
            // 
            // listNewLanguage
            // 
            this.listNewLanguage.FormattingEnabled = true;
            this.listNewLanguage.ItemHeight = 20;
            this.listNewLanguage.Location = new System.Drawing.Point(282, 303);
            this.listNewLanguage.Name = "listNewLanguage";
            this.listNewLanguage.Size = new System.Drawing.Size(176, 124);
            this.listNewLanguage.TabIndex = 10;
            this.listNewLanguage.SelectedIndexChanged += new System.EventHandler(this.listNewLanguage_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Spracheditor";
            // 
            // listForms
            // 
            this.listForms.FormattingEnabled = true;
            this.listForms.ItemHeight = 20;
            this.listForms.Location = new System.Drawing.Point(568, 161);
            this.listForms.Name = "listForms";
            this.listForms.Size = new System.Drawing.Size(148, 84);
            this.listForms.TabIndex = 13;
            this.listForms.SelectedIndexChanged += new System.EventHandler(this.listForms_SelectedIndexChanged);
            // 
            // EditFlagName
            // 
            this.EditFlagName.AutoSize = true;
            this.EditFlagName.Location = new System.Drawing.Point(598, 57);
            this.EditFlagName.Name = "EditFlagName";
            this.EditFlagName.Size = new System.Drawing.Size(135, 20);
            this.EditFlagName.TabIndex = 16;
            this.EditFlagName.Text = "Flagge und Name";
            // 
            // EditNativName
            // 
            this.EditNativName.AutoSize = true;
            this.EditNativName.Location = new System.Drawing.Point(568, 92);
            this.EditNativName.Name = "EditNativName";
            this.EditNativName.Size = new System.Drawing.Size(104, 20);
            this.EditNativName.TabIndex = 17;
            this.EditNativName.Text = "Nativer Name";
            // 
            // ImgFallback
            // 
            this.ImgFallback.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImgFallback.Location = new System.Drawing.Point(17, 92);
            this.ImgFallback.Name = "ImgFallback";
            this.ImgFallback.Size = new System.Drawing.Size(16, 16);
            this.ImgFallback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgFallback.TabIndex = 18;
            this.ImgFallback.TabStop = false;
            // 
            // BtnEditLang
            // 
            this.BtnEditLang.AutoSize = true;
            this.BtnEditLang.Location = new System.Drawing.Point(278, 172);
            this.BtnEditLang.Name = "BtnEditLang";
            this.BtnEditLang.Size = new System.Drawing.Size(149, 20);
            this.BtnEditLang.TabIndex = 19;
            this.BtnEditLang.TabStop = true;
            this.BtnEditLang.Text = "Sprache auswählen";
            this.BtnEditLang.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnEditLang_LinkClicked);
            // 
            // ImgCurrentLang
            // 
            this.ImgCurrentLang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImgCurrentLang.Location = new System.Drawing.Point(17, 288);
            this.ImgCurrentLang.Name = "ImgCurrentLang";
            this.ImgCurrentLang.Size = new System.Drawing.Size(16, 16);
            this.ImgCurrentLang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgCurrentLang.TabIndex = 20;
            this.ImgCurrentLang.TabStop = false;
            // 
            // BtnAddLang
            // 
            this.BtnAddLang.AutoSize = true;
            this.BtnAddLang.Enabled = false;
            this.BtnAddLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddLang.Location = new System.Drawing.Point(278, 244);
            this.BtnAddLang.Name = "BtnAddLang";
            this.BtnAddLang.Size = new System.Drawing.Size(170, 20);
            this.BtnAddLang.TabIndex = 21;
            this.BtnAddLang.TabStop = true;
            this.BtnAddLang.Text = "Sprache hinzufügen";
            this.BtnAddLang.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnAddLang_LinkClicked);
            // 
            // ImgAddLang
            // 
            this.ImgAddLang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImgAddLang.Location = new System.Drawing.Point(282, 278);
            this.ImgAddLang.Name = "ImgAddLang";
            this.ImgAddLang.Size = new System.Drawing.Size(16, 16);
            this.ImgAddLang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgAddLang.TabIndex = 23;
            this.ImgAddLang.TabStop = false;
            // 
            // lblAddLang
            // 
            this.lblAddLang.AutoSize = true;
            this.lblAddLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddLang.Location = new System.Drawing.Point(313, 275);
            this.lblAddLang.Name = "lblAddLang";
            this.lblAddLang.Size = new System.Drawing.Size(117, 20);
            this.lblAddLang.TabIndex = 22;
            this.lblAddLang.Text = "Flag and Name";
            // 
            // BtnEditRemove
            // 
            this.BtnEditRemove.AutoSize = true;
            this.BtnEditRemove.Location = new System.Drawing.Point(278, 202);
            this.BtnEditRemove.Name = "BtnEditRemove";
            this.BtnEditRemove.Size = new System.Drawing.Size(137, 20);
            this.BtnEditRemove.TabIndex = 24;
            this.BtnEditRemove.TabStop = true;
            this.BtnEditRemove.Text = "Aus liste loeschen";
            this.BtnEditRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnEditRemove_LinkClicked);
            // 
            // langCurrInternName
            // 
            this.langCurrInternName.AutoSize = true;
            this.langCurrInternName.Location = new System.Drawing.Point(16, 327);
            this.langCurrInternName.Name = "langCurrInternName";
            this.langCurrInternName.Size = new System.Drawing.Size(101, 20);
            this.langCurrInternName.TabIndex = 26;
            this.langCurrInternName.Text = "Intern. Name";
            // 
            // langCurrNativeName
            // 
            this.langCurrNativeName.AutoSize = true;
            this.langCurrNativeName.Location = new System.Drawing.Point(16, 366);
            this.langCurrNativeName.Name = "langCurrNativeName";
            this.langCurrNativeName.Size = new System.Drawing.Size(104, 20);
            this.langCurrNativeName.TabIndex = 27;
            this.langCurrNativeName.Text = "Nativer Name";
            // 
            // lblDBFunctions
            // 
            this.lblDBFunctions.AutoSize = true;
            this.lblDBFunctions.Location = new System.Drawing.Point(765, 25);
            this.lblDBFunctions.Name = "lblDBFunctions";
            this.lblDBFunctions.Size = new System.Drawing.Size(163, 20);
            this.lblDBFunctions.TabIndex = 28;
            this.lblDBFunctions.Text = "Datenbankfunktionen";
            // 
            // listDBKeys
            // 
            this.listDBKeys.FormattingEnabled = true;
            this.listDBKeys.ItemHeight = 20;
            this.listDBKeys.Location = new System.Drawing.Point(568, 303);
            this.listDBKeys.Name = "listDBKeys";
            this.listDBKeys.Size = new System.Drawing.Size(148, 124);
            this.listDBKeys.TabIndex = 33;
            this.listDBKeys.SelectedIndexChanged += new System.EventHandler(this.listDBKeys_SelectedIndexChanged);
            // 
            // TxtFallback
            // 
            this.TxtFallback.Location = new System.Drawing.Point(769, 161);
            this.TxtFallback.Multiline = true;
            this.TxtFallback.Name = "TxtFallback";
            this.TxtFallback.ReadOnly = true;
            this.TxtFallback.Size = new System.Drawing.Size(380, 84);
            this.TxtFallback.TabIndex = 35;
            // 
            // TxtTrans
            // 
            this.TxtTrans.Location = new System.Drawing.Point(769, 303);
            this.TxtTrans.Multiline = true;
            this.TxtTrans.Name = "TxtTrans";
            this.TxtTrans.Size = new System.Drawing.Size(380, 111);
            this.TxtTrans.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(769, 268);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 20);
            this.label14.TabIndex = 37;
            this.label14.Text = "Der übersetzte Inhalt";
            // 
            // lblTransCulture
            // 
            this.lblTransCulture.AutoSize = true;
            this.lblTransCulture.Location = new System.Drawing.Point(1058, 267);
            this.lblTransCulture.Name = "lblTransCulture";
            this.lblTransCulture.Size = new System.Drawing.Size(115, 20);
            this.lblTransCulture.TabIndex = 38;
            this.lblTransCulture.Text = "lblTransCulture";
            // 
            // ImgEditFlag
            // 
            this.ImgEditFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ImgEditFlag.Location = new System.Drawing.Point(572, 58);
            this.ImgEditFlag.Name = "ImgEditFlag";
            this.ImgEditFlag.Size = new System.Drawing.Size(16, 16);
            this.ImgEditFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgEditFlag.TabIndex = 39;
            this.ImgEditFlag.TabStop = false;
            // 
            // lblSelectFormular
            // 
            this.lblSelectFormular.AutoSize = true;
            this.lblSelectFormular.Enabled = false;
            this.lblSelectFormular.Location = new System.Drawing.Point(568, 128);
            this.lblSelectFormular.Name = "lblSelectFormular";
            this.lblSelectFormular.Size = new System.Drawing.Size(152, 20);
            this.lblSelectFormular.TabIndex = 40;
            this.lblSelectFormular.TabStop = true;
            this.lblSelectFormular.Text = "Formular auswählen";
            this.lblSelectFormular.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectFormular_LinkClicked);
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = true;
            this.BtnSave.Location = new System.Drawing.Point(867, 418);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(81, 20);
            this.BtnSave.TabIndex = 41;
            this.BtnSave.TabStop = true;
            this.BtnSave.Text = "Speichern";
            this.BtnSave.Visible = false;
            this.BtnSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSave_LinkClicked);
            // 
            // BtnDelete
            // 
            this.BtnDelete.AutoSize = true;
            this.BtnDelete.Location = new System.Drawing.Point(973, 418);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(79, 20);
            this.BtnDelete.TabIndex = 42;
            this.BtnDelete.TabStop = true;
            this.BtnDelete.Text = "Loeschen";
            this.BtnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnDelete_LinkClicked);
            // 
            // BtnInsert
            // 
            this.BtnInsert.AutoSize = true;
            this.BtnInsert.Location = new System.Drawing.Point(769, 417);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(82, 20);
            this.BtnInsert.TabIndex = 43;
            this.BtnInsert.TabStop = true;
            this.BtnInsert.Text = "Einfuegen";
            this.BtnInsert.Visible = false;
            this.BtnInsert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnInsert_LinkClicked);
            // 
            // lblAnser
            // 
            this.lblAnser.AutoSize = true;
            this.lblAnser.ForeColor = System.Drawing.Color.Green;
            this.lblAnser.Location = new System.Drawing.Point(1071, 418);
            this.lblAnser.Name = "lblAnser";
            this.lblAnser.Size = new System.Drawing.Size(66, 20);
            this.lblAnser.TabIndex = 44;
            this.lblAnser.Text = "lblAnser";
            this.lblAnser.Visible = false;
            // 
            // linkFullBackup
            // 
            this.linkFullBackup.AutoSize = true;
            this.linkFullBackup.Location = new System.Drawing.Point(765, 58);
            this.linkFullBackup.Name = "linkFullBackup";
            this.linkFullBackup.Size = new System.Drawing.Size(176, 20);
            this.linkFullBackup.TabIndex = 45;
            this.linkFullBackup.TabStop = true;
            this.linkFullBackup.Text = "Gesamter XML-Backup";
            this.linkFullBackup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFullBackup_LinkClicked);
            // 
            // linkLangBackup
            // 
            this.linkLangBackup.AutoSize = true;
            this.linkLangBackup.Location = new System.Drawing.Point(765, 92);
            this.linkLangBackup.Name = "linkLangBackup";
            this.linkLangBackup.Size = new System.Drawing.Size(197, 20);
            this.linkLangBackup.TabIndex = 46;
            this.linkLangBackup.TabStop = true;
            this.linkLangBackup.Text = "XML-Backup fuer Sprache";
            this.linkLangBackup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLangBackup_LinkClicked);
            // 
            // linkReadBackup
            // 
            this.linkReadBackup.AutoSize = true;
            this.linkReadBackup.Location = new System.Drawing.Point(765, 122);
            this.linkReadBackup.Name = "linkReadBackup";
            this.linkReadBackup.Size = new System.Drawing.Size(126, 20);
            this.linkReadBackup.TabIndex = 47;
            this.linkReadBackup.TabStop = true;
            this.linkReadBackup.Text = "Backup einlesen";
            // 
            // langeditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 450);
            this.Controls.Add(this.linkReadBackup);
            this.Controls.Add(this.linkLangBackup);
            this.Controls.Add(this.linkFullBackup);
            this.Controls.Add(this.lblAnser);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.lblSelectFormular);
            this.Controls.Add(this.ImgEditFlag);
            this.Controls.Add(this.lblTransCulture);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtTrans);
            this.Controls.Add(this.TxtFallback);
            this.Controls.Add(this.listDBKeys);
            this.Controls.Add(this.lblDBFunctions);
            this.Controls.Add(this.langCurrNativeName);
            this.Controls.Add(this.langCurrInternName);
            this.Controls.Add(this.BtnEditRemove);
            this.Controls.Add(this.ImgAddLang);
            this.Controls.Add(this.lblAddLang);
            this.Controls.Add(this.BtnAddLang);
            this.Controls.Add(this.ImgCurrentLang);
            this.Controls.Add(this.BtnEditLang);
            this.Controls.Add(this.ImgFallback);
            this.Controls.Add(this.EditNativName);
            this.Controls.Add(this.EditFlagName);
            this.Controls.Add(this.listForms);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listNewLanguage);
            this.Controls.Add(this.lblCurrentLang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FlagName);
            this.Controls.Add(this.IntName);
            this.Controls.Add(this.NativName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listEditLanguage);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "langeditor";
            this.Text = "wjk-VideoDownloader Spracheditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LangEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ImgFallback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCurrentLang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAddLang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgEditFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listEditLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NativName;
        private System.Windows.Forms.Label IntName;
        private System.Windows.Forms.Label FlagName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentLang;
        private System.Windows.Forms.ListBox listNewLanguage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listForms;
        private System.Windows.Forms.Label EditFlagName;
        private System.Windows.Forms.Label EditNativName;
        private System.Windows.Forms.PictureBox ImgFallback;
        private System.Windows.Forms.LinkLabel BtnEditLang;
        private System.Windows.Forms.PictureBox ImgCurrentLang;
        private System.Windows.Forms.LinkLabel BtnAddLang;
        private System.Windows.Forms.PictureBox ImgAddLang;
        private System.Windows.Forms.Label lblAddLang;
        private System.Windows.Forms.LinkLabel BtnEditRemove;
        private System.Windows.Forms.Label langCurrInternName;
        private System.Windows.Forms.Label langCurrNativeName;
        private System.Windows.Forms.Label lblDBFunctions;
        private System.Windows.Forms.ListBox listDBKeys;
        private System.Windows.Forms.TextBox TxtFallback;
        private System.Windows.Forms.TextBox TxtTrans;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTransCulture;
        private System.Windows.Forms.PictureBox ImgEditFlag;
        private System.Windows.Forms.LinkLabel lblSelectFormular;
        private System.Windows.Forms.LinkLabel BtnSave;
        private System.Windows.Forms.LinkLabel BtnDelete;
        private System.Windows.Forms.LinkLabel BtnInsert;
        private System.Windows.Forms.Label lblAnser;
        private System.Windows.Forms.LinkLabel linkFullBackup;
        private System.Windows.Forms.LinkLabel linkLangBackup;
        private System.Windows.Forms.LinkLabel linkReadBackup;
    }
}