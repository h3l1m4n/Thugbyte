using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Playlistcreator : Form
    {
        public Playlistcreator()
        {
            InitializeComponent();
        }

        public string PlaylistName { get; private set; }

        private void btOK_Click(object sender, EventArgs e)
        {
            PlaylistName = tbPlaylistName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}