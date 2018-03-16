namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMusictrack = new System.Windows.Forms.ProgressBar();
            this.lblCurrentSec = new System.Windows.Forms.Label();
            this.cbShuffle = new System.Windows.Forms.CheckBox();
            this.cbRepeat = new System.Windows.Forms.CheckBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btPlayPause = new System.Windows.Forms.Button();
            this.rtbLyrics = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDupesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWebserviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.textboxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRelated = new System.Windows.Forms.ListBox();
            this.pbAlbum = new System.Windows.Forms.PictureBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lbVersion = new System.Windows.Forms.Label();
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsNotifyPlayPause = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNotifyNext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cbRussian = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.cmsNotify.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Location = new System.Drawing.Point(8, 121);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(165, 21);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(177, 120);
            this.btSearch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(55, 24);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(696, 641);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "00:00";
            // 
            // pbMusictrack
            // 
            this.pbMusictrack.Location = new System.Drawing.Point(147, 624);
            this.pbMusictrack.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pbMusictrack.Name = "pbMusictrack";
            this.pbMusictrack.Size = new System.Drawing.Size(598, 16);
            this.pbMusictrack.TabIndex = 13;
            this.pbMusictrack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMusictrack_MouseClick);
            // 
            // lblCurrentSec
            // 
            this.lblCurrentSec.AutoSize = true;
            this.lblCurrentSec.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSec.Location = new System.Drawing.Point(143, 641);
            this.lblCurrentSec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentSec.Name = "lblCurrentSec";
            this.lblCurrentSec.Size = new System.Drawing.Size(49, 20);
            this.lblCurrentSec.TabIndex = 14;
            this.lblCurrentSec.Text = "00:00";
            // 
            // cbShuffle
            // 
            this.cbShuffle.AutoSize = true;
            this.cbShuffle.Location = new System.Drawing.Point(19, 64);
            this.cbShuffle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbShuffle.Name = "cbShuffle";
            this.cbShuffle.Size = new System.Drawing.Size(64, 20);
            this.cbShuffle.TabIndex = 15;
            this.cbShuffle.Text = "Shuffle";
            this.cbShuffle.UseVisualStyleBackColor = true;
            // 
            // cbRepeat
            // 
            this.cbRepeat.AutoSize = true;
            this.cbRepeat.Location = new System.Drawing.Point(87, 64);
            this.cbRepeat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbRepeat.Name = "cbRepeat";
            this.cbRepeat.Size = new System.Drawing.Size(93, 20);
            this.cbRepeat.TabIndex = 16;
            this.cbRepeat.Text = "Repeat Song";
            this.cbRepeat.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(627, 223);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 16);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total Hits: 0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(19, 624);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 31);
            this.button5.TabIndex = 18;
            this.button5.Text = "Next";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btPlayPause
            // 
            this.btPlayPause.Location = new System.Drawing.Point(19, 591);
            this.btPlayPause.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btPlayPause.Name = "btPlayPause";
            this.btPlayPause.Size = new System.Drawing.Size(86, 31);
            this.btPlayPause.TabIndex = 20;
            this.btPlayPause.Text = "Play/Pause";
            this.btPlayPause.UseVisualStyleBackColor = true;
            this.btPlayPause.Click += new System.EventHandler(this.btPlayPause_Click);
            // 
            // rtbLyrics
            // 
            this.rtbLyrics.DetectUrls = false;
            this.rtbLyrics.Location = new System.Drawing.Point(711, 77);
            this.rtbLyrics.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rtbLyrics.Name = "rtbLyrics";
            this.rtbLyrics.ReadOnly = true;
            this.rtbLyrics.Size = new System.Drawing.Size(231, 425);
            this.rtbLyrics.TabIndex = 22;
            this.rtbLyrics.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(816, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Lyrics";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.downloadManagerToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.colorManagerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.removeDupesToolStripMenuItem,
            this.testSlackToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // removeDupesToolStripMenuItem
            // 
            this.removeDupesToolStripMenuItem.Name = "removeDupesToolStripMenuItem";
            this.removeDupesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeDupesToolStripMenuItem.Text = "RemoveDupes";
            this.removeDupesToolStripMenuItem.Click += new System.EventHandler(this.removeDupesToolStripMenuItem_Click);
            // 
            // testSlackToolStripMenuItem
            // 
            this.testSlackToolStripMenuItem.Name = "testSlackToolStripMenuItem";
            this.testSlackToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.testSlackToolStripMenuItem.Text = "Test Slack";
            this.testSlackToolStripMenuItem.Click += new System.EventHandler(this.testSlackToolStripMenuItem_Click);
            // 
            // downloadManagerToolStripMenuItem
            // 
            this.downloadManagerToolStripMenuItem.Name = "downloadManagerToolStripMenuItem";
            this.downloadManagerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.downloadManagerToolStripMenuItem.Text = "Download Manager";
            this.downloadManagerToolStripMenuItem.Click += new System.EventHandler(this.downloadManagerToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWebserviceToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.testingToolStripMenuItem.Text = "Server & Client";
            // 
            // openWebserviceToolStripMenuItem
            // 
            this.openWebserviceToolStripMenuItem.Name = "openWebserviceToolStripMenuItem";
            this.openWebserviceToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openWebserviceToolStripMenuItem.Text = "Open Webservice";
            this.openWebserviceToolStripMenuItem.Click += new System.EventHandler(this.openWebserviceToolStripMenuItem_Click);
            // 
            // colorManagerToolStripMenuItem
            // 
            this.colorManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.textboxesToolStripMenuItem,
            this.buttonToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.colorManagerToolStripMenuItem.Name = "colorManagerToolStripMenuItem";
            this.colorManagerToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.colorManagerToolStripMenuItem.Text = "Color Manager";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem2,
            this.textToolStripMenuItem1,
            this.resetToolStripMenuItem2});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.backgroundToolStripMenuItem.Text = "Main Form";
            // 
            // backgroundToolStripMenuItem2
            // 
            this.backgroundToolStripMenuItem2.Name = "backgroundToolStripMenuItem2";
            this.backgroundToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem2.Text = "Background";
            this.backgroundToolStripMenuItem2.Click += new System.EventHandler(this.backgroundToolStripMenuItem2_Click);
            // 
            // textToolStripMenuItem1
            // 
            this.textToolStripMenuItem1.Name = "textToolStripMenuItem1";
            this.textToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.textToolStripMenuItem1.Text = "Text";
            this.textToolStripMenuItem1.Click += new System.EventHandler(this.textToolStripMenuItem1_Click);
            // 
            // resetToolStripMenuItem2
            // 
            this.resetToolStripMenuItem2.Name = "resetToolStripMenuItem2";
            this.resetToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.resetToolStripMenuItem2.Text = "Reset";
            this.resetToolStripMenuItem2.Click += new System.EventHandler(this.resetToolStripMenuItem2_Click);
            // 
            // textboxesToolStripMenuItem
            // 
            this.textboxesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem1,
            this.textToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.textboxesToolStripMenuItem.Name = "textboxesToolStripMenuItem";
            this.textboxesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.textboxesToolStripMenuItem.Text = "Textboxes";
            // 
            // backgroundToolStripMenuItem1
            // 
            this.backgroundToolStripMenuItem1.Name = "backgroundToolStripMenuItem1";
            this.backgroundToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem1.Text = "Background";
            this.backgroundToolStripMenuItem1.Click += new System.EventHandler(this.backgroundToolStripMenuItem1_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // buttonToolStripMenuItem
            // 
            this.buttonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem3,
            this.textToolStripMenuItem2,
            this.resetToolStripMenuItem1});
            this.buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            this.buttonToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.buttonToolStripMenuItem.Text = "Button";
            // 
            // backgroundToolStripMenuItem3
            // 
            this.backgroundToolStripMenuItem3.Name = "backgroundToolStripMenuItem3";
            this.backgroundToolStripMenuItem3.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem3.Text = "Background";
            this.backgroundToolStripMenuItem3.Click += new System.EventHandler(this.backgroundToolStripMenuItem3_Click);
            // 
            // textToolStripMenuItem2
            // 
            this.textToolStripMenuItem2.Name = "textToolStripMenuItem2";
            this.textToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.textToolStripMenuItem2.Text = "Text";
            this.textToolStripMenuItem2.Click += new System.EventHandler(this.textToolStripMenuItem2_Click);
            // 
            // resetToolStripMenuItem1
            // 
            this.resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
            this.resetToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.resetToolStripMenuItem1.Text = "Reset";
            this.resetToolStripMenuItem1.Click += new System.EventHandler(this.resetToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // lbRelated
            // 
            this.lbRelated.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbRelated.FormattingEnabled = true;
            this.lbRelated.ItemHeight = 16;
            this.lbRelated.Location = new System.Drawing.Point(8, 334);
            this.lbRelated.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.lbRelated.Name = "lbRelated";
            this.lbRelated.Size = new System.Drawing.Size(224, 164);
            this.lbRelated.TabIndex = 31;
            this.lbRelated.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbRelated_MouseDoubleClick);
            // 
            // pbAlbum
            // 
            this.pbAlbum.Location = new System.Drawing.Point(763, 504);
            this.pbAlbum.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pbAlbum.Name = "pbAlbum";
            this.pbAlbum.Size = new System.Drawing.Size(179, 162);
            this.pbAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbum.TabIndex = 30;
            this.pbAlbum.TabStop = false;
            // 
            // cbFilter
            // 
            this.cbFilter.AllowDrop = true;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "All",
            "Match Artist",
            "Match Song"});
            this.cbFilter.Location = new System.Drawing.Point(0, 89);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(143, 24);
            this.cbFilter.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 317);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Related Artists";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(254, 59);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(43, 16);
            this.lbStatus.TabIndex = 36;
            this.lbStatus.Text = "Status:";
            // 
            // tbVolume
            // 
            this.tbVolume.LargeChange = 4;
            this.tbVolume.Location = new System.Drawing.Point(5, 520);
            this.tbVolume.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbVolume.Maximum = 20;
            this.tbVolume.Minimum = 1;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbVolume.Size = new System.Drawing.Size(121, 45);
            this.tbVolume.TabIndex = 37;
            this.tbVolume.Value = 20;
            this.tbVolume.ValueChanged += new System.EventHandler(this.tbVolume_ValueChanged);
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(851, 24);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(39, 16);
            this.lbVersion.TabIndex = 38;
            this.lbVersion.Text = "label4";
            // 
            // mynotifyicon
            // 
            this.mynotifyicon.BalloonTipText = "test1";
            this.mynotifyicon.BalloonTipTitle = "test2";
            this.mynotifyicon.ContextMenuStrip = this.cmsNotify;
            this.mynotifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyicon.Icon")));
            this.mynotifyicon.Text = "ThugByte";
            this.mynotifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mynotifyicon_MouseDoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsNotifyPlayPause,
            this.cmsNotifyNext,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsNotify.Size = new System.Drawing.Size(139, 76);
            // 
            // cmsNotifyPlayPause
            // 
            this.cmsNotifyPlayPause.Name = "cmsNotifyPlayPause";
            this.cmsNotifyPlayPause.Size = new System.Drawing.Size(138, 22);
            this.cmsNotifyPlayPause.Text = "Play / Pause";
            this.cmsNotifyPlayPause.Click += new System.EventHandler(this.cmsNotifyPlayPause_Click);
            // 
            // cmsNotifyNext
            // 
            this.cmsNotifyNext.Name = "cmsNotifyNext";
            this.cmsNotifyNext.Size = new System.Drawing.Size(138, 22);
            this.cmsNotifyNext.Text = "Next";
            this.cmsNotifyNext.Click += new System.EventHandler(this.cmsNotifyNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // cbSource
            // 
            this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "Source 1",
            "Source 2",
            "Source 3"});
            this.cbSource.Location = new System.Drawing.Point(8, 88);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(164, 24);
            this.cbSource.TabIndex = 42;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(377, 578);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 44);
            this.label4.TabIndex = 43;
            this.label4.Text = "Artist\r\nTitle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sp
            // 
            this.sp.BaudRate = 19600;
            // 
            // tabControl1
            // 
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(258, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(442, 423);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 44;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // cbRussian
            // 
            this.cbRussian.AllowDrop = true;
            this.cbRussian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRussian.FormattingEnabled = true;
            this.cbRussian.Items.AddRange(new object[] {
            "None",
            "Russian Artist",
            "Russian Song",
            "No Russkii"});
            this.cbRussian.Location = new System.Drawing.Point(0, 39);
            this.cbRussian.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cbRussian.Name = "cbRussian";
            this.cbRussian.Size = new System.Drawing.Size(143, 24);
            this.cbRussian.TabIndex = 45;
            this.cbRussian.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbRussian);
            this.groupBox1.Controls.Add(this.cbFilter);
            this.groupBox1.Location = new System.Drawing.Point(19, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 144);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "Remove";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Match";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(947, 670);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSource);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbRelated);
            this.Controls.Add(this.pbAlbum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbLyrics);
            this.Controls.Add(this.btPlayPause);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cbRepeat);
            this.Controls.Add(this.cbShuffle);
            this.Controls.Add(this.lblCurrentSec);
            this.Controls.Add(this.pbMusictrack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ThugByte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.cmsNotify.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbMusictrack;
        private System.Windows.Forms.Label lblCurrentSec;
        private System.Windows.Forms.CheckBox cbShuffle;
        private System.Windows.Forms.CheckBox cbRepeat;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btPlayPause;
        private System.Windows.Forms.RichTextBox rtbLyrics;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDupesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadManagerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbAlbum;
        private System.Windows.Forms.ListBox lbRelated;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon mynotifyicon;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem cmsNotifyPlayPause;
        private System.Windows.Forms.ToolStripMenuItem cmsNotifyNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWebserviceToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.ToolStripMenuItem colorManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textboxesToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.ToolStripMenuItem testSlackToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox cbRussian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

