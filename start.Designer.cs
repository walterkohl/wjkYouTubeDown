namespace wjkYouTupe
{
    partial class Start
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUri = new System.Windows.Forms.TextBox();
            this.ReadFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckSaveInfo = new System.Windows.Forms.CheckBox();
            this.TxtInfos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.radioYouTube = new System.Windows.Forms.RadioButton();
            this.radioURL = new System.Windows.Forms.RadioButton();
            this.groupURL = new System.Windows.Forms.GroupBox();
            this.BtnPreviewFile = new System.Windows.Forms.Button();
            this.BtnPreviewURL = new System.Windows.Forms.Button();
            this.DdLang = new System.Windows.Forms.ListBox();
            this.checkRememberPath = new System.Windows.Forms.CheckBox();
            this.SelectedLang = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupURL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TxtUri
            // 
            resources.ApplyResources(this.TxtUri, "TxtUri");
            this.TxtUri.Name = "TxtUri";
            this.TxtUri.TextChanged += new System.EventHandler(this.TxtUri_TextChanged);
            // 
            // ReadFile
            // 
            resources.ApplyResources(this.ReadFile, "ReadFile");
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TxtName
            // 
            resources.ApplyResources(this.TxtName, "TxtName");
            this.TxtName.Name = "TxtName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // CheckSaveInfo
            // 
            resources.ApplyResources(this.CheckSaveInfo, "CheckSaveInfo");
            this.CheckSaveInfo.Checked = true;
            this.CheckSaveInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSaveInfo.Name = "CheckSaveInfo";
            this.CheckSaveInfo.UseVisualStyleBackColor = true;
            // 
            // TxtInfos
            // 
            resources.ApplyResources(this.TxtInfos, "TxtInfos");
            this.TxtInfos.Name = "TxtInfos";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TxtPath
            // 
            resources.ApplyResources(this.TxtPath, "TxtPath");
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.TextChanged += new System.EventHandler(this.TxtPath_TextChanged);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Name = "label5";
            this.label5.UseWaitCursor = true;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.Red;
            this.BtnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.BtnReset, "BtnReset");
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.BtnAbout, "BtnAbout");
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.BackColor = System.Drawing.Color.Lime;
            this.BtnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.BtnHelp, "BtnHelp");
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // radioYouTube
            // 
            resources.ApplyResources(this.radioYouTube, "radioYouTube");
            this.radioYouTube.Checked = true;
            this.radioYouTube.Name = "radioYouTube";
            this.radioYouTube.TabStop = true;
            this.radioYouTube.UseVisualStyleBackColor = true;
            // 
            // radioURL
            // 
            resources.ApplyResources(this.radioURL, "radioURL");
            this.radioURL.Name = "radioURL";
            this.radioURL.UseVisualStyleBackColor = true;
            // 
            // groupURL
            // 
            this.groupURL.Controls.Add(this.radioURL);
            this.groupURL.Controls.Add(this.radioYouTube);
            resources.ApplyResources(this.groupURL, "groupURL");
            this.groupURL.Name = "groupURL";
            this.groupURL.TabStop = false;
            // 
            // BtnPreviewFile
            // 
            this.BtnPreviewFile.BackColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.BtnPreviewFile, "BtnPreviewFile");
            this.BtnPreviewFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPreviewFile.Name = "BtnPreviewFile";
            this.BtnPreviewFile.UseVisualStyleBackColor = false;
            this.BtnPreviewFile.Click += new System.EventHandler(this.BtnPreviewFile_Click);
            // 
            // BtnPreviewURL
            // 
            this.BtnPreviewURL.BackColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.BtnPreviewURL, "BtnPreviewURL");
            this.BtnPreviewURL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPreviewURL.Name = "BtnPreviewURL";
            this.BtnPreviewURL.UseVisualStyleBackColor = false;
            this.BtnPreviewURL.Click += new System.EventHandler(this.BtnPreviewURL_Click);
            // 
            // DdLang
            // 
            this.DdLang.FormattingEnabled = true;
            resources.ApplyResources(this.DdLang, "DdLang");
            this.DdLang.Name = "DdLang";
            this.DdLang.SelectedValueChanged += new System.EventHandler(this.DdLang_SelectedIndexChanged);
            // 
            // checkRememberPath
            // 
            resources.ApplyResources(this.checkRememberPath, "checkRememberPath");
            this.checkRememberPath.Checked = true;
            this.checkRememberPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRememberPath.Name = "checkRememberPath";
            this.checkRememberPath.UseVisualStyleBackColor = true;
            // 
            // SelectedLang
            // 
            resources.ApplyResources(this.SelectedLang, "SelectedLang");
            this.SelectedLang.Name = "SelectedLang";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Start
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SelectedLang);
            this.Controls.Add(this.checkRememberPath);
            this.Controls.Add(this.DdLang);
            this.Controls.Add(this.BtnPreviewURL);
            this.Controls.Add(this.BtnPreviewFile);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtInfos);
            this.Controls.Add(this.CheckSaveInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReadFile);
            this.Controls.Add(this.TxtUri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupURL);
            this.Name = "Start";
            this.groupURL.ResumeLayout(false);
            this.groupURL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtUri;
        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckSaveInfo;
        private System.Windows.Forms.TextBox TxtInfos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnHelp;
        private System.Windows.Forms.RadioButton radioYouTube;
        private System.Windows.Forms.RadioButton radioURL;
        private System.Windows.Forms.GroupBox groupURL;
        private System.Windows.Forms.Button BtnPreviewFile;
        private System.Windows.Forms.Button BtnPreviewURL;
        private System.Windows.Forms.ListBox DdLang;
        private System.Windows.Forms.CheckBox checkRememberPath;
        private System.Windows.Forms.Label SelectedLang;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

