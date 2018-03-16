namespace WindowsFormsApplication1
{
    partial class Playlistcreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playlistcreator));
            this.btOK = new System.Windows.Forms.Button();
            this.btFuckOff = new System.Windows.Forms.Button();
            this.tbPlaylistName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(141, 49);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "Done!";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btFuckOff
            // 
            this.btFuckOff.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFuckOff.Location = new System.Drawing.Point(25, 49);
            this.btFuckOff.Name = "btFuckOff";
            this.btFuckOff.Size = new System.Drawing.Size(75, 23);
            this.btFuckOff.TabIndex = 1;
            this.btFuckOff.Text = "Cancel";
            this.btFuckOff.UseVisualStyleBackColor = true;
            // 
            // tbPlaylistName
            // 
            this.tbPlaylistName.Location = new System.Drawing.Point(25, 12);
            this.tbPlaylistName.Name = "tbPlaylistName";
            this.tbPlaylistName.Size = new System.Drawing.Size(191, 20);
            this.tbPlaylistName.TabIndex = 2;
            // 
            // Playlistcreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 83);
            this.Controls.Add(this.tbPlaylistName);
            this.Controls.Add(this.btFuckOff);
            this.Controls.Add(this.btOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Playlistcreator";
            this.Text = "playlistcreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btFuckOff;
        private System.Windows.Forms.TextBox tbPlaylistName;
    }
}