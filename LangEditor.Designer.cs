namespace wjkYouTupe
{
    partial class LangEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LangEditor));
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
            this.label9 = new System.Windows.Forms.Label();
            this.listControls = new System.Windows.Forms.ListBox();
            this.EditFlagName = new System.Windows.Forms.Label();
            this.EditNativName = new System.Windows.Forms.Label();
            this.ImgFallback = new System.Windows.Forms.PictureBox();
            this.BtnEditLang = new System.Windows.Forms.LinkLabel();
            this.ImgCurrentLang = new System.Windows.Forms.PictureBox();
            this.BtnAddLang = new System.Windows.Forms.LinkLabel();
            this.ImgAddLang = new System.Windows.Forms.PictureBox();
            this.lblAddLang = new System.Windows.Forms.Label();
            this.BtnEditRemove = new System.Windows.Forms.LinkLabel();
            this.textControl = new System.Windows.Forms.TextBox();
            this.langCurrInternName = new System.Windows.Forms.Label();
            this.langCurrNativeName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listDBKeys = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtFallback = new System.Windows.Forms.TextBox();
            this.TxtTrans = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTransCulture = new System.Windows.Forms.Label();
            this.ImgEditFlag = new System.Windows.Forms.PictureBox();
            this.lblSelectFormular = new System.Windows.Forms.LinkLabel();
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Gegenkontrolle";
            // 
            // listControls
            // 
            this.listControls.FormattingEnabled = true;
            this.listControls.ItemHeight = 20;
            this.listControls.Location = new System.Drawing.Point(568, 303);
            this.listControls.Name = "listControls";
            this.listControls.Size = new System.Drawing.Size(148, 124);
            this.listControls.TabIndex = 15;
            this.listControls.SelectedIndexChanged += new System.EventHandler(this.listControls_SelectedIndexChanged);
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
            // textControl
            // 
            this.textControl.Location = new System.Drawing.Point(769, 366);
            this.textControl.Multiline = true;
            this.textControl.Name = "textControl";
            this.textControl.ReadOnly = true;
            this.textControl.Size = new System.Drawing.Size(384, 61);
            this.textControl.TabIndex = 25;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(962, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Datenbank-Inhalte";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(966, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Inhalt Ausgangssprache";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(966, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Control: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1041, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "lblControlBasic";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(769, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Derzeitiger Controller-Inhalt";
            // 
            // listDBKeys
            // 
            this.listDBKeys.FormattingEnabled = true;
            this.listDBKeys.ItemHeight = 20;
            this.listDBKeys.Location = new System.Drawing.Point(773, 21);
            this.listDBKeys.Name = "listDBKeys";
            this.listDBKeys.Size = new System.Drawing.Size(148, 124);
            this.listDBKeys.TabIndex = 33;
            this.listDBKeys.SelectedIndexChanged += new System.EventHandler(this.listDBKeys_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(966, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "Basisinhalt";
            // 
            // TxtFallback
            // 
            this.TxtFallback.Location = new System.Drawing.Point(773, 161);
            this.TxtFallback.Multiline = true;
            this.TxtFallback.Name = "TxtFallback";
            this.TxtFallback.ReadOnly = true;
            this.TxtFallback.Size = new System.Drawing.Size(380, 61);
            this.TxtFallback.TabIndex = 35;
            // 
            // TxtTrans
            // 
            this.TxtTrans.Location = new System.Drawing.Point(773, 266);
            this.TxtTrans.Multiline = true;
            this.TxtTrans.Name = "TxtTrans";
            this.TxtTrans.Size = new System.Drawing.Size(380, 61);
            this.TxtTrans.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(773, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 20);
            this.label14.TabIndex = 37;
            this.label14.Text = "Der übersetzte Inhalt";
            // 
            // lblTransCulture
            // 
            this.lblTransCulture.AutoSize = true;
            this.lblTransCulture.Location = new System.Drawing.Point(1066, 239);
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
            // LangEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 450);
            this.Controls.Add(this.lblSelectFormular);
            this.Controls.Add(this.ImgEditFlag);
            this.Controls.Add(this.lblTransCulture);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtTrans);
            this.Controls.Add(this.TxtFallback);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listDBKeys);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.langCurrNativeName);
            this.Controls.Add(this.langCurrInternName);
            this.Controls.Add(this.textControl);
            this.Controls.Add(this.BtnEditRemove);
            this.Controls.Add(this.ImgAddLang);
            this.Controls.Add(this.lblAddLang);
            this.Controls.Add(this.BtnAddLang);
            this.Controls.Add(this.ImgCurrentLang);
            this.Controls.Add(this.BtnEditLang);
            this.Controls.Add(this.ImgFallback);
            this.Controls.Add(this.EditNativName);
            this.Controls.Add(this.EditFlagName);
            this.Controls.Add(this.listControls);
            this.Controls.Add(this.label9);
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
            this.Name = "LangEditor";
            this.Text = "wjk-VideoDownloader Spracheditor";
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listControls;
        private System.Windows.Forms.Label EditFlagName;
        private System.Windows.Forms.Label EditNativName;
        private System.Windows.Forms.PictureBox ImgFallback;
        private System.Windows.Forms.LinkLabel BtnEditLang;
        private System.Windows.Forms.PictureBox ImgCurrentLang;
        private System.Windows.Forms.LinkLabel BtnAddLang;
        private System.Windows.Forms.PictureBox ImgAddLang;
        private System.Windows.Forms.Label lblAddLang;
        private System.Windows.Forms.LinkLabel BtnEditRemove;
        private System.Windows.Forms.TextBox textControl;
        private System.Windows.Forms.Label langCurrInternName;
        private System.Windows.Forms.Label langCurrNativeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listDBKeys;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtFallback;
        private System.Windows.Forms.TextBox TxtTrans;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTransCulture;
        private System.Windows.Forms.PictureBox ImgEditFlag;
        private System.Windows.Forms.LinkLabel lblSelectFormular;
    }
}