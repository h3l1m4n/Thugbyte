namespace WindowsFormsApplication1
{
    partial class DownloadManager
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.chArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDownload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbTotalSongs = new System.Windows.Forms.Label();
            this.btPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chArtist,
            this.chSong,
            this.chDownload});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 72);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(654, 275);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chArtist
            // 
            this.chArtist.Text = "Artists";
            this.chArtist.Width = 212;
            // 
            // chSong
            // 
            this.chSong.Text = "Song";
            this.chSong.Width = 201;
            // 
            // chDownload
            // 
            this.chDownload.Text = "Download Status";
            this.chDownload.Width = 153;
            // 
            // lbTotalSongs
            // 
            this.lbTotalSongs.AutoSize = true;
            this.lbTotalSongs.Location = new System.Drawing.Point(12, 32);
            this.lbTotalSongs.Name = "lbTotalSongs";
            this.lbTotalSongs.Size = new System.Drawing.Size(31, 13);
            this.lbTotalSongs.TabIndex = 1;
            this.lbTotalSongs.Text = "Total";
            // 
            // btPath
            // 
            this.btPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btPath.Image = global::WindowsFormsApplication1.Properties.Resources.folder;
            this.btPath.Location = new System.Drawing.Point(618, 12);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(48, 43);
            this.btPath.TabIndex = 2;
            this.btPath.UseVisualStyleBackColor = true;
            this.btPath.Click += new System.EventHandler(this.btPath_Click);
            // 
            // DownloadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 359);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.lbTotalSongs);
            this.Controls.Add(this.listView1);
            this.Name = "DownloadManager";
            this.Text = "DownloadManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadManager_FormClosing);
            this.Load += new System.EventHandler(this.DownloadManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chArtist;
        private System.Windows.Forms.ColumnHeader chSong;
        private System.Windows.Forms.ColumnHeader chDownload;
        private System.Windows.Forms.Label lbTotalSongs;
        private System.Windows.Forms.Button btPath;
    }
}