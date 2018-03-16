using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EncryptedLink : Form
    {
        public EncryptedLink(string encryption)
        {
            InitializeComponent();
            richTextBox1.Text = encryption;
        }
    }
}