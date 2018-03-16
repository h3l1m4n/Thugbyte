namespace WindowsFormsApplication1
{
    partial class EncryptedPlaylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptedPlaylist));
            this.rtbLink = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLink
            // 
            this.rtbLink.Location = new System.Drawing.Point(0, 1);
            this.rtbLink.Name = "rtbLink";
            this.rtbLink.ReadOnly = true;
            this.rtbLink.Size = new System.Drawing.Size(420, 726);
            this.rtbLink.TabIndex = 0;
            this.rtbLink.Text = "";
            // 
            // EncryptedPlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 727);
            this.Controls.Add(this.rtbLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EncryptedPlaylist";
            this.Text = "EncryptedPlaylist";
            this.Load += new System.EventHandler(this.EncryptedPlaylist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLink;
    }
}