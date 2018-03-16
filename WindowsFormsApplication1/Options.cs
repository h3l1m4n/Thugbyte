using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NAudio.CoreAudioApi;

namespace WindowsFormsApplication1
{
    public partial class Options : Form
    {
        readonly string keyName = "ThugByte";
        readonly string assemblyLocation = Assembly.GetExecutingAssembly().Location;  // Or the EXE path.
        private readonly IniFile _myIni;
        public Options()
        {
            InitializeComponent();

             _myIni = new IniFile();
            LoadSettings();
          
        }

        private void LoadSettings()
        {
            
            cbLyrics.Checked = Convert.ToBoolean(_myIni.Read("ShowLyrics", "Common"));
      
            cbRelated.Checked = Convert.ToBoolean(_myIni.Read("RelatedArtist", "Common"));
            cbAlbum.Checked = Convert.ToBoolean(_myIni.Read("AlbumArt", "Common"));
            cbDlSort.Checked = Convert.ToBoolean(_myIni.Read("SortDownload", "Common"));
            cbNotify.Checked = Convert.ToBoolean(_myIni.Read("Notify", "Common"));
            cbAutoStart.Checked = Convert.ToBoolean(_myIni.Read("Autostart", "Common"));
            cbTracking.Checked = Convert.ToBoolean(_myIni.Read("Tracking", "Common"));
            cbPlay.Checked = Convert.ToBoolean(_myIni.Read("AllowPause", "ServerClient"));
            cbNext.Checked = Convert.ToBoolean(_myIni.Read("AllowNext", "ServerClient"));
            var tempplay = Convert.ToInt32(_myIni.Read("Play", "HotKeys"));
            var tempnext = Convert.ToInt32(_myIni.Read("Next", "HotKeys"));
            tbPlay.Text = Convert.ToChar(tempplay).ToString();
            tbNext.Text = Convert.ToChar(tempnext).ToString();
            tbPath.Text = _myIni.Read("Path", "Common");
            cbColors.SelectedIndex = Convert.ToInt32(_myIni.Read("BarColor", "Common")) - 1;
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            cbDevices.Items.AddRange(items: devices.ToArray());
            cbDevices.SelectedIndex = Convert.ToInt32(_myIni.Read("Device", "Device"));
            tbServerIp.Text = _myIni.Read("Serverip", "ServerClient");
            tbPortNum.Text = _myIni.Read("Serverport", "ServerClient");
            cbScd.Checked = Convert.ToBoolean(_myIni.Read("Serial", "Device"));
            cbSlack.Checked = Convert.ToBoolean(_myIni.Read("Enabled", "Slack"));
            tbSlackApi.Text = _myIni.Read("ApiKey", "Slack");
            tbBotname.Text = _myIni.Read("Botname", "Slack");
            tbSlackchannel.Text = _myIni.Read("Channel", "Slack");
            PopulateCom();


        }

        private void PopulateCom()
        {
            for (int i = 0; i <= 20; i++)
            {
                cbCom.Items.Add("Com"+i);
            }
            cbCom.SelectedIndex = Convert.ToInt32(_myIni.Read("SerialPort", "Device"));
        }

        private void SaveSettings()
        {

            _myIni.Write("Path", tbPath.Text, "Common");
            _myIni.Write("ShowLyrics", Convert.ToBoolean(cbLyrics.Checked).ToString(), "Common");
            _myIni.Write("RelatedArtist", Convert.ToBoolean(cbRelated.Checked).ToString(), "Common");
            _myIni.Write("AlbumArt", Convert.ToBoolean(cbAlbum.Checked).ToString(), "Common");
            _myIni.Write("SortDownload", Convert.ToBoolean(cbDlSort.Checked).ToString(), "Common");
            _myIni.Write("Notify", Convert.ToBoolean(cbNotify.Checked).ToString(), "Common");
            _myIni.Write("Autostart", Convert.ToBoolean(cbAutoStart.Checked).ToString(), "Common");
            _myIni.Write("Device", cbDevices.SelectedIndex.ToString(), "Device");
            _myIni.Write("Tracking", Convert.ToBoolean(cbTracking.Checked).ToString(), "Common");
            _myIni.Write("AllowNext", Convert.ToBoolean(cbTracking.Checked).ToString(), "ServerClient");
            _myIni.Write("AllowPause", Convert.ToBoolean(cbTracking.Checked).ToString(), "ServerClient");
            _myIni.Write("Serverip", tbServerIp.Text, "ServerClient");
            _myIni.Write("Serverport", tbPortNum.Text, "ServerClient");
            _myIni.Write("Serial", Convert.ToBoolean(cbScd.Checked).ToString(), "Device");
            _myIni.Write("SerialPort", cbCom.SelectedIndex.ToString(), "Device");
            var color = cbColors.SelectedIndex + 1;
            _myIni.Write("BarColor",color.ToString(), "Common");
            int tempplay = tbPlay.Text[0];
            _myIni.Write("Play",tempplay.ToString(),"HotKeys");
            int tempnext = tbNext.Text[0];
            _myIni.Write("Next", tempnext.ToString(), "HotKeys");
            _myIni.Write("Enabled", Convert.ToBoolean(cbSlack.Checked).ToString(), "Slack");
            _myIni.Write("Apikey", tbSlackApi.Text, "Slack");
            _myIni.Write("Botname", tbBotname.Text, "Slack");
            _myIni.Write("Channel", tbSlackchannel.Text, "Slack");


            if (cbAutoStart.Checked)
            {
                Util.SetAutoStart(keyName, assemblyLocation);

            }
            else
            {
                if (Util.IsAutoStartEnabled(keyName, assemblyLocation))
                Util.UnSetAutoStart(keyName);
            }
           

        }

        private void btDlpath_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            tbPath.Text = fbd.SelectedPath + "\\";
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Close();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
    public class Util
    {
        private const string RunLocation = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Sets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);
            key.SetValue(keyName, assemblyLocation);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RunLocation);
            if (key == null)
                return false;

            string value = (string)key.GetValue(keyName);
            if (value == null)
                return false;

            return (value == assemblyLocation);
        }

        /// <summary>
        /// Unsets the autostart value for the assembly.
        /// </summary>
        /// <param name="keyName">Registry Key Name</param>
        public static void UnSetAutoStart(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);
            key.DeleteValue(keyName);
        }
    }
}
