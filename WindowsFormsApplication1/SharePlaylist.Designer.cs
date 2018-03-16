namespace WindowsFormsApplication1
{
    partial class SharePlaylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharePlaylist));
            this.btImport = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbListName = new System.Windows.Forms.TextBox();
            this.rtbLink = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btImport
            // 
            this.btImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btImport.Location = new System.Drawing.Point(331, 198);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(75, 23);
            this.btImport.TabIndex = 0;
            this.btImport.Text = "Import";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(26, 198);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // tbListName
            // 
            this.tbListName.Location = new System.Drawing.Point(121, 25);
            this.tbListName.Name = "tbListName";
            this.tbListName.Size = new System.Drawing.Size(170, 20);
            this.tbListName.TabIndex = 2;
            // 
            // rtbLink
            // 
            this.rtbLink.Location = new System.Drawing.Point(26, 61);
            this.rtbLink.Name = "rtbLink";
            this.rtbLink.Size = new System.Drawing.Size(389, 131);
            this.rtbLink.TabIndex = 3;
            this.rtbLink.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Playlist Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encrypted Link";
            // 
            // SharePlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLink);
            this.Controls.Add(this.tbListName);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SharePlaylist";
            this.Text = "SharePlaylist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox tbListName;
        private System.Windows.Forms.RichTextBox rtbLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}