using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SharePlaylist : Form
    {
        public string PlaylistName { get; private set; }
        public string PlaylistString { get; set; }
        public SharePlaylist()
        {
            InitializeComponent();
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            PlaylistName = tbListName.Text;
            PlaylistString = rtbLink.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
