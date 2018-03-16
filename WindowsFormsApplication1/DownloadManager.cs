using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DownloadManager : Form
    {
        private int _downloadIndex;
        private List<song> _downloadQueue;
        private IniFile _myIni;
        private string _path;
        private bool _sortArtist;


        private Stopwatch _sw;
        private bool downloading;

        public DownloadManager()
        {
            InitializeComponent();
        }

        private void DownloadManager_Load(object sender, EventArgs e)
        {
            _downloadQueue = new List<song>();
            _myIni = new IniFile();
            _path = _myIni.Read("Path", "Common");
            _sortArtist = Convert.ToBoolean(_myIni.Read("SortDownload", "Common"));
        }

        private void DownloadManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public void AddItemsListview(song itemSong)
        {
            var item1 = new ListViewItem(itemSong.Artist);
            item1.SubItems.Add(itemSong.Songname);
            item1.SubItems.Add("Not Started yet");
            listView1.Items.Add(item1);
            listView1.Items[_downloadIndex].ForeColor = Color.Orange;
            ;
            _downloadQueue.Add(itemSong);
            lbTotalSongs.Text = "Total: " + listView1.Items.Count;
            if (downloading == false)
            {
                DownloadFile(itemSong.URL, itemSong);
                downloading = true;
            }
        }

        public void DownloadFile(string url, song fileName)
        {
            var bgThread = new Thread(() =>
            {
                _sw = new Stopwatch();
                _sw.Start();

                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("User-Agent: Other");

                    webClient.DownloadFileCompleted +=
                        DownloadCompleted;
                    webClient.DownloadProgressChanged +=
                        DownloadStatusChanged;
                    if (_sortArtist)
                    {
                        var ArtistPath = _path + "\\" + HelperClass.CleanFileName(fileName.Artist);
                        System.IO.Directory.CreateDirectory(ArtistPath);
                        webClient.DownloadFileAsync(new Uri(url), ArtistPath + "\\" + HelperClass.CleanFileName(fileName.GetSongInfo()) + ".mp3");
                    }
                    else
                    {
                        webClient.DownloadFileAsync(new Uri(url), _path + fileName.GetSongInfo() + ".mp3");
                    }
                    
                }
            });

            bgThread.Start();
        }

        private void DownloadStatusChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate
            {
                var percent = 0;

                if (e.ProgressPercentage == percent) return;
                percent = e.ProgressPercentage;
                listView1.Items[_downloadIndex].SubItems[2].Text = percent.ToString();
            });
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate
            {
                if (e.Error == null)
                {
                    listView1.Items[_downloadIndex].SubItems[2].Text = "Completed";
                    listView1.Items[_downloadIndex].ForeColor = Color.Green;
                    ;
                }
                else
                {
                    listView1.Items[_downloadIndex].SubItems[2].Text = "Error";
                    listView1.Items[_downloadIndex].ForeColor = Color.Red;
                }

                _downloadIndex++;
                if (_downloadIndex < listView1.Items.Count)
                {
                    DownloadFile(_downloadQueue[_downloadIndex].URL, _downloadQueue[_downloadIndex]);
                }
                else
                {
                    downloading = false;
                }
            });
        }

        private void btPath_Click(object sender, EventArgs e)
        {
            Process.Start(@_path);
        }
    }
}