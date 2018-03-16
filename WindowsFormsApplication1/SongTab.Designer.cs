namespace WindowsFormsApplication1
{
    partial class SongTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvSearch = new System.Windows.Forms.ListView();
            this.chArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmsSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSearch
            // 
            this.lvSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chArtist,
            this.chSong,
            this.chTime});
            this.lvSearch.ContextMenuStrip = this.cmsSearch;
            this.lvSearch.FullRowSelect = true;
            this.lvSearch.HideSelection = false;
            this.lvSearch.Location = new System.Drawing.Point(-1, 1);
            this.lvSearch.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.lvSearch.MultiSelect = false;
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.ShowItemToolTips = true;
            this.lvSearch.Size = new System.Drawing.Size(384, 319);
            this.lvSearch.TabIndex = 27;
            this.lvSearch.UseCompatibleStateImageBehavior = false;
            this.lvSearch.View = System.Windows.Forms.View.Details;
            this.lvSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            this.lvSearch.DoubleClick += new System.EventHandler(this.lvSearch_DoubleClick);
            this.lvSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDown);
            // 
            // chArtist
            // 
            this.chArtist.Text = "Artist";
            this.chArtist.Width = 92;
            // 
            // chSong
            // 
            this.chSong.Text = "Song";
            this.chSong.Width = 209;
            // 
            // chTime
            // 
            this.chTime.Text = "Duratation";
            this.chTime.Width = 81;
            // 
            // cmsSearch
            // 
            this.cmsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDownload,
            this.cmsPlay,
            this.searchToolStripMenuItem,
            this.addToQToolStripMenuItem,
            this.copyLinkToolStripMenuItem});
            this.cmsSearch.Name = "cmsSearch";
            this.cmsSearch.Size = new System.Drawing.Size(149, 114);
            // 
            // cmsDownload
            // 
            this.cmsDownload.Name = "cmsDownload";
            this.cmsDownload.Size = new System.Drawing.Size(148, 22);
            this.cmsDownload.Text = "Download";
            this.cmsDownload.Click += new System.EventHandler(this.cmsDownload_Click);
            // 
            // cmsPlay
            // 
            this.cmsPlay.Name = "cmsPlay";
            this.cmsPlay.Size = new System.Drawing.Size(148, 22);
            this.cmsPlay.Text = "Play";
            this.cmsPlay.Click += new System.EventHandler(this.cmsPlay_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artistToolStripMenuItem,
            this.songToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // artistToolStripMenuItem
            // 
            this.artistToolStripMenuItem.Name = "artistToolStripMenuItem";
            this.artistToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.artistToolStripMenuItem.Text = "Artist";
            this.artistToolStripMenuItem.Click += new System.EventHandler(this.artistToolStripMenuItem_Click);
            // 
            // songToolStripMenuItem
            // 
            this.songToolStripMenuItem.Name = "songToolStripMenuItem";
            this.songToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.songToolStripMenuItem.Text = "Song";
            this.songToolStripMenuItem.Click += new System.EventHandler(this.songToolStripMenuItem_Click);
            // 
            // addToQToolStripMenuItem
            // 
            this.addToQToolStripMenuItem.Name = "addToQToolStripMenuItem";
            this.addToQToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addToQToolStripMenuItem.Text = "Add to Queue";
            this.addToQToolStripMenuItem.Click += new System.EventHandler(this.addToQToolStripMenuItem_Click);
            // 
            // copyLinkToolStripMenuItem
            // 
            this.copyLinkToolStripMenuItem.Name = "copyLinkToolStripMenuItem";
            this.copyLinkToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyLinkToolStripMenuItem.Text = "Copy Link";
            this.copyLinkToolStripMenuItem.Click += new System.EventHandler(this.copyLinkToolStripMenuItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(174, 321);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 13);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Total Hits: 0";
            // 
            // SongTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lvSearch);
            this.Name = "SongTab";
            this.Size = new System.Drawing.Size(442, 969);
            this.cmsSearch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSearch;
        private System.Windows.Forms.ColumnHeader chArtist;
        private System.Windows.Forms.ColumnHeader chSong;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ContextMenuStrip cmsSearch;
        private System.Windows.Forms.ToolStripMenuItem cmsDownload;
        private System.Windows.Forms.ToolStripMenuItem cmsPlay;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToolStripMenuItem;
    }
}
