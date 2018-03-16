namespace WindowsFormsApplication1
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTracking = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.cbNotify = new System.Windows.Forms.CheckBox();
            this.cbRelated = new System.Windows.Forms.CheckBox();
            this.cbAlbum = new System.Windows.Forms.CheckBox();
            this.cbLyrics = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDlSort = new System.Windows.Forms.CheckBox();
            this.btDlpath = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btDone = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPlay = new System.Windows.Forms.TextBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPlay = new System.Windows.Forms.CheckBox();
            this.cbNext = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPortNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbScd = new System.Windows.Forms.CheckBox();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSlackchannel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSlackApi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBotname = new System.Windows.Forms.TextBox();
            this.cbSlack = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTracking);
            this.groupBox1.Controls.Add(this.cbAutoStart);
            this.groupBox1.Controls.Add(this.cbNotify);
            this.groupBox1.Controls.Add(this.cbRelated);
            this.groupBox1.Controls.Add(this.cbAlbum);
            this.groupBox1.Controls.Add(this.cbLyrics);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbTracking
            // 
            this.cbTracking.AutoSize = true;
            this.cbTracking.Location = new System.Drawing.Point(217, 51);
            this.cbTracking.Name = "cbTracking";
            this.cbTracking.Size = new System.Drawing.Size(68, 17);
            this.cbTracking.TabIndex = 6;
            this.cbTracking.Text = "Tracking";
            this.cbTracking.UseVisualStyleBackColor = true;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(14, 52);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(68, 17);
            this.cbAutoStart.TabIndex = 5;
            this.cbAutoStart.Text = "Autostart";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // cbNotify
            // 
            this.cbNotify.AutoSize = true;
            this.cbNotify.Location = new System.Drawing.Point(14, 24);
            this.cbNotify.Name = "cbNotify";
            this.cbNotify.Size = new System.Drawing.Size(115, 17);
            this.cbNotify.TabIndex = 4;
            this.cbNotify.Text = "Notification Bubble";
            this.cbNotify.UseVisualStyleBackColor = true;
            // 
            // cbRelated
            // 
            this.cbRelated.AutoSize = true;
            this.cbRelated.Location = new System.Drawing.Point(130, 51);
            this.cbRelated.Name = "cbRelated";
            this.cbRelated.Size = new System.Drawing.Size(89, 17);
            this.cbRelated.TabIndex = 3;
            this.cbRelated.Text = "Related Artist";
            this.cbRelated.UseVisualStyleBackColor = true;
            // 
            // cbAlbum
            // 
            this.cbAlbum.AutoSize = true;
            this.cbAlbum.Location = new System.Drawing.Point(217, 24);
            this.cbAlbum.Name = "cbAlbum";
            this.cbAlbum.Size = new System.Drawing.Size(71, 17);
            this.cbAlbum.TabIndex = 2;
            this.cbAlbum.Text = "Album Art";
            this.cbAlbum.UseVisualStyleBackColor = true;
            // 
            // cbLyrics
            // 
            this.cbLyrics.AutoSize = true;
            this.cbLyrics.Location = new System.Drawing.Point(130, 24);
            this.cbLyrics.Name = "cbLyrics";
            this.cbLyrics.Size = new System.Drawing.Size(53, 17);
            this.cbLyrics.TabIndex = 1;
            this.cbLyrics.Text = "Lyrics";
            this.cbLyrics.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbDlSort);
            this.groupBox2.Controls.Add(this.btDlpath);
            this.groupBox2.Controls.Add(this.tbPath);
            this.groupBox2.Location = new System.Drawing.Point(8, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 88);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Download Path";
            // 
            // cbDlSort
            // 
            this.cbDlSort.AutoSize = true;
            this.cbDlSort.Location = new System.Drawing.Point(6, 65);
            this.cbDlSort.Name = "cbDlSort";
            this.cbDlSort.Size = new System.Drawing.Size(168, 17);
            this.cbDlSort.TabIndex = 2;
            this.cbDlSort.Text = "Sort Artist When Downloading";
            this.cbDlSort.UseVisualStyleBackColor = true;
            // 
            // btDlpath
            // 
            this.btDlpath.Location = new System.Drawing.Point(225, 31);
            this.btDlpath.Name = "btDlpath";
            this.btDlpath.Size = new System.Drawing.Size(75, 23);
            this.btDlpath.TabIndex = 1;
            this.btDlpath.Text = "Browse";
            this.btDlpath.UseVisualStyleBackColor = true;
            this.btDlpath.Click += new System.EventHandler(this.btDlpath_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(6, 33);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(213, 20);
            this.tbPath.TabIndex = 0;
            // 
            // btDone
            // 
            this.btDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btDone.Location = new System.Drawing.Point(163, 426);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(75, 23);
            this.btDone.TabIndex = 3;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbNext);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbPlay);
            this.groupBox4.Location = new System.Drawing.Point(7, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 119);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hotkeys";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Next Hotkey";
            // 
            // tbNext
            // 
            this.tbNext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNext.Location = new System.Drawing.Point(99, 46);
            this.tbNext.Name = "tbNext";
            this.tbNext.Size = new System.Drawing.Size(31, 20);
            this.tbNext.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Play Hotkey";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "The Hotkeys are used with \r\n\"ALT + Whatever you want\"";
            // 
            // tbPlay
            // 
            this.tbPlay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPlay.Location = new System.Drawing.Point(24, 46);
            this.tbPlay.Name = "tbPlay";
            this.tbPlay.Size = new System.Drawing.Size(31, 20);
            this.tbPlay.TabIndex = 0;
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(318, 21);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(120, 21);
            this.cbDevices.TabIndex = 6;
            // 
            // cbColors
            // 
            this.cbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Items.AddRange(new object[] {
            "Green",
            "Red",
            "Yellow"});
            this.cbColors.Location = new System.Drawing.Point(320, 50);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(63, 21);
            this.cbColors.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbPlay);
            this.groupBox3.Controls.Add(this.cbNext);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbPortNum);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbServerIp);
            this.groupBox3.Location = new System.Drawing.Point(7, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 106);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client & Server Setting";
            // 
            // cbPlay
            // 
            this.cbPlay.AutoSize = true;
            this.cbPlay.Location = new System.Drawing.Point(182, 58);
            this.cbPlay.Name = "cbPlay";
            this.cbPlay.Size = new System.Drawing.Size(82, 17);
            this.cbPlay.TabIndex = 5;
            this.cbPlay.Text = "Play & Pause";
            this.cbPlay.UseVisualStyleBackColor = true;
            // 
            // cbNext
            // 
            this.cbNext.AutoSize = true;
            this.cbNext.Location = new System.Drawing.Point(182, 35);
            this.cbNext.Name = "cbNext";
            this.cbNext.Size = new System.Drawing.Size(76, 17);
            this.cbNext.TabIndex = 4;
            this.cbNext.Text = "Next Song";
            this.cbNext.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port";
            // 
            // tbPortNum
            // 
            this.tbPortNum.Location = new System.Drawing.Point(15, 70);
            this.tbPortNum.Name = "tbPortNum";
            this.tbPortNum.Size = new System.Drawing.Size(64, 20);
            this.tbPortNum.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP";
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(15, 32);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(115, 20);
            this.tbServerIp.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbScd);
            this.groupBox5.Controls.Add(this.cbCom);
            this.groupBox5.Location = new System.Drawing.Point(320, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(92, 65);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scd122U";
            // 
            // cbScd
            // 
            this.cbScd.AutoSize = true;
            this.cbScd.Location = new System.Drawing.Point(6, 18);
            this.cbScd.Name = "cbScd";
            this.cbScd.Size = new System.Drawing.Size(65, 17);
            this.cbScd.TabIndex = 1;
            this.cbScd.Text = "Enabled";
            this.cbScd.UseVisualStyleBackColor = true;
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(6, 36);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(70, 21);
            this.cbCom.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.tbSlackchannel);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.tbSlackApi);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.tbBotname);
            this.groupBox6.Controls.Add(this.cbSlack);
            this.groupBox6.Location = new System.Drawing.Point(173, 185);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(223, 116);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Slack";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Channel";
            // 
            // tbSlackchannel
            // 
            this.tbSlackchannel.Location = new System.Drawing.Point(0, 93);
            this.tbSlackchannel.Name = "tbSlackchannel";
            this.tbSlackchannel.Size = new System.Drawing.Size(100, 20);
            this.tbSlackchannel.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Api Key";
            // 
            // tbSlackApi
            // 
            this.tbSlackApi.Location = new System.Drawing.Point(2, 24);
            this.tbSlackApi.Name = "tbSlackApi";
            this.tbSlackApi.Size = new System.Drawing.Size(190, 20);
            this.tbSlackApi.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bot Name";
            // 
            // tbBotname
            // 
            this.tbBotname.Location = new System.Drawing.Point(2, 60);
            this.tbBotname.Name = "tbBotname";
            this.tbBotname.Size = new System.Drawing.Size(100, 20);
            this.tbBotname.TabIndex = 1;
            // 
            // cbSlack
            // 
            this.cbSlack.AutoSize = true;
            this.cbSlack.Location = new System.Drawing.Point(153, 96);
            this.cbSlack.Name = "cbSlack";
            this.cbSlack.Size = new System.Drawing.Size(65, 17);
            this.cbSlack.TabIndex = 0;
            this.cbSlack.Text = "Enabled";
            this.cbSlack.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 461);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbColors);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbRelated;
        private System.Windows.Forms.CheckBox cbAlbum;
        private System.Windows.Forms.CheckBox cbLyrics;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDlSort;
        private System.Windows.Forms.Button btDlpath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.CheckBox cbNotify;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPlay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.CheckBox cbTracking;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPlay;
        private System.Windows.Forms.CheckBox cbNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPortNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbScd;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBotname;
        private System.Windows.Forms.CheckBox cbSlack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSlackApi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSlackchannel;
    }
}