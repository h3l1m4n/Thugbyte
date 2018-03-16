using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ShareForm : Form
    {
        public ShareForm()
        {
            InitializeComponent();
        }

        public song Song { get; private set; }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbKey.Text.Length > 0)
            {
                var exploded = HelperClass.DecryptSong(tbKey.Text).Split('╣');
                Song = new song(exploded[3], exploded[0], true, exploded[2], exploded[1]);
                MessageBox.Show(Song.GetSongInfo());
            }

           
        }

       
    }
}