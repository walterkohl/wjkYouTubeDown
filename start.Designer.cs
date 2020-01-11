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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bitte den Link aus YouTube hierher kopieren.";
            // 
            // TxtUri
            // 
            this.TxtUri.Location = new System.Drawing.Point(12, 32);
            this.TxtUri.Name = "TxtUri";
            this.TxtUri.Size = new System.Drawing.Size(634, 26);
            this.TxtUri.TabIndex = 1;
            this.TxtUri.TextChanged += new System.EventHandler(this.TxtUri_TextChanged);
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(669, 67);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(119, 32);
            this.ReadFile.TabIndex = 2;
            this.ReadFile.Text = "Datei lesen";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dateiname zum Speichern";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(226, 73);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(420, 26);
            this.TxtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nachfolgende Videoinformationen in Datei speichern";
            // 
            // CheckSaveInfo
            // 
            this.CheckSaveInfo.AutoSize = true;
            this.CheckSaveInfo.Checked = true;
            this.CheckSaveInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSaveInfo.Location = new System.Drawing.Point(477, 109);
            this.CheckSaveInfo.Name = "CheckSaveInfo";
            this.CheckSaveInfo.Size = new System.Drawing.Size(169, 24);
            this.CheckSaveInfo.TabIndex = 6;
            this.CheckSaveInfo.Text = "Ja: Infos speichern";
            this.CheckSaveInfo.UseVisualStyleBackColor = true;
            // 
            // TxtInfos
            // 
            this.TxtInfos.Location = new System.Drawing.Point(12, 147);
            this.TxtInfos.Multiline = true;
            this.TxtInfos.Name = "TxtInfos";
            this.TxtInfos.Size = new System.Drawing.Size(634, 146);
            this.TxtInfos.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(669, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 106);
            this.button1.TabIndex = 8;
            this.button1.Text = "Verzeichnis zum Speichern wählen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Speichern unter";
            // 
            // TxtPath
            // 
            this.TxtPath.Location = new System.Drawing.Point(12, 347);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(634, 26);
            this.TxtPath.TabIndex = 10;
            this.TxtPath.TextChanged += new System.EventHandler(this.TxtPath_TextChanged);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(669, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "Speichern";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(669, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 35);
            this.button3.TabIndex = 12;
            this.button3.Text = "Name okay?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(521, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "*** Speichern ***";
            this.label5.UseWaitCursor = true;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(181, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Die Datei existiert, bitte umbenennen!";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.OliveDrab;
            this.label7.Location = new System.Drawing.Point(12, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Info-Datei gespeichert unter: ";
            this.label7.Visible = false;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.Red;
            this.BtnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnReset.Location = new System.Drawing.Point(669, 313);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(119, 34);
            this.BtnReset.TabIndex = 16;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.LawnGreen;
            this.BtnAbout.Location = new System.Drawing.Point(669, 16);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(119, 42);
            this.BtnAbout.TabIndex = 17;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.BackColor = System.Drawing.Color.Lime;
            this.BtnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnHelp.Location = new System.Drawing.Point(669, 353);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(119, 47);
            this.BtnHelp.TabIndex = 18;
            this.BtnHelp.Text = "Hilfe";
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "wjk-YouTube-Download";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnHelp;
    }
}

