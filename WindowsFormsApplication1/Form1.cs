using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1.Searches;
using HtmlAgilityPack;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int WM_HOTKEY = 0x0312;
        public const int MOD_ALT = 0x0001;
        private const int LEADING_SPACE = 12;
        private const int CLOSE_SPACE = 15;
        private const int CLOSE_AREA = 15;

        private readonly IniFile _myIni;
        private readonly List<song> _playlist;

        private readonly string _version = "1.5.8";

        private bool _coverArt;
        public int _currentIndex;
        private SongTab _currenttab;
        private int _device;
        private DownloadManager _dlman;
        private HtmlWeb _htmlWeb;
        private bool _isFromPlayList;
        private NancySelfHost _nancy;
        private bool _notify;
        public List<song> _queueList;
        private bool _related;
        private List<song> _searchResults;
        private bool _serial;
        private int _serialPort;
        private bool _showLyrics;

        private bool _slack;
        private string _slackapiurl;
        private string _slackChannel;
        private string _slackUsername;
        private bool _tracking;
        private AudioPlayer _workerObject;

        public Form1()
        {
            InitializeComponent();
            HelperClass.SetupFirstRun();

            _searchResults = new List<song>();
            _playlist = new List<song>();
            _myIni = new IniFile();
            _queueList = new List<song>();
            CheckIniFile();
            LoadSettings();
            cbFilter.SelectedIndex = 0;
            cbSource.SelectedIndex = 0;
            cbRussian.SelectedIndex = 0;

            tbSearch.KeyPress += CheckKeys;
            SetHotKeys();

            if (!_showLyrics)
                rtbLyrics.Enabled = false;
            SetAutoComplete();
            lbVersion.Text = "Version: " + _version;
            CheckForNewVersion();
            SetStatistic(_version);
        }

        private void LoadSettings()
        {
            _showLyrics = Convert.ToBoolean(_myIni.Read("ShowLyrics", "Common"));
            pbMusictrack.SetState(Convert.ToInt32(_myIni.Read("BarColor", "Common")));
            _related = Convert.ToBoolean(_myIni.Read("RelatedArtist", "Common"));
            _coverArt = Convert.ToBoolean(_myIni.Read("AlbumArt", "Common"));
            _notify = Convert.ToBoolean(_myIni.Read("Notify", "Common"));
            _device = Convert.ToInt32(_myIni.Read("Device", "Device"));
            _tracking = Convert.ToBoolean(_myIni.Read("Tracking", "Common"));
            tbVolume.Value = Convert.ToInt32(_myIni.Read("Volume", "Device"));
            _serial = Convert.ToBoolean(_myIni.Read("Serial", "Device"));
            _serialPort = Convert.ToInt32(_myIni.Read("SerialPort", "Device"));
            _slack = Convert.ToBoolean(_myIni.Read("Enabled", "Slack"));
            _slackapiurl = _myIni.Read("ApiKey", "Slack");
            _slackUsername = _myIni.Read("Botname", "Slack");
            _slackChannel = _myIni.Read("Channel", "Slack");
            LoadSkin();
        }

        private void LoadSkin()
        {
            btSearch.BackColor = Color.FromName(_myIni.Read("SearchButtonBackground", "Buttons"));
            cbSource.BackColor = Color.FromName(_myIni.Read("SourceButtonBackground", "Buttons"));
            btPlayPause.BackColor = Color.FromName(_myIni.Read("PlayButtonBackground", "Buttons"));
            cbFilter.BackColor = Color.FromName(_myIni.Read("FilterButtonBackground", "Buttons"));
            button5.BackColor = Color.FromName(_myIni.Read("NextButtonBackground", "Buttons"));

            btSearch.ForeColor = Color.FromName(_myIni.Read("SearchButtonText", "Buttons"));
            cbSource.ForeColor = Color.FromName(_myIni.Read("SourceButtonText", "Buttons"));
            btPlayPause.ForeColor = Color.FromName(_myIni.Read("PlayButtonText", "Buttons"));
            cbFilter.ForeColor = Color.FromName(_myIni.Read("FilterButtonText", "Buttons"));
            button5.ForeColor = Color.FromName(_myIni.Read("NextButtonText", "Buttons"));


            BackColor = Color.FromName(_myIni.Read("MainFormBackground", "MainForm"));
            menuStrip1.BackColor = Color.FromName(_myIni.Read("MenuBackground", "MainForm"));
            lbVersion.ForeColor = Color.FromName(_myIni.Read("VersionText", "MainForm"));
            lblCurrentSec.ForeColor = Color.FromName(_myIni.Read("CurrentSecondsText", "MainForm"));
            cbRepeat.ForeColor = Color.FromName(_myIni.Read("CheckboxRepeatText", "MainForm"));
            cbShuffle.ForeColor = Color.FromName(_myIni.Read("CheckboxSuffleText", "MainForm"));
            lblTotal.ForeColor = Color.FromName(_myIni.Read("TotalHitText", "MainForm"));
            label3.ForeColor = Color.FromName(_myIni.Read("label3Text", "MainForm"));
            label2.ForeColor = Color.FromName(_myIni.Read("label2Text", "MainForm"));
            lbStatus.ForeColor = Color.FromName(_myIni.Read("lbStatusText", "MainForm"));
            label1.ForeColor = Color.FromName(_myIni.Read("label1Text", "MainForm"));
            menuStrip1.ForeColor = Color.FromName(_myIni.Read("menuStrip1Text", "MainForm"));


            lbRelated.BackColor = Color.FromName(_myIni.Read("lbRelatedBackground", "TextBoxes"));
            rtbLyrics.BackColor = Color.FromName(_myIni.Read("rtbLyricsBackground", "TextBoxes"));
            tbSearch.BackColor = Color.FromName(_myIni.Read("tbSearchBackground", "TextBoxes"));


            lbRelated.ForeColor = Color.FromName(_myIni.Read("lbRelatedText", "TextBoxes"));
            rtbLyrics.ForeColor = Color.FromName(_myIni.Read("rtbLyricsText", "TextBoxes"));
            tbSearch.ForeColor = Color.FromName(_myIni.Read("tbSearchText", "TextBoxes"));
        }

        private void SetHotKeys()
        {
            RegisterHotKey(Handle, 1, MOD_ALT, Convert.ToInt32(_myIni.Read("Next", "HotKeys")));
            RegisterHotKey(Handle, 2, MOD_ALT, Convert.ToInt32(_myIni.Read("Play", "HotKeys")));
        }

        private void CheckIniFile()
        {
            if (!_myIni.KeyExists("ShowLyrics", "Common"))
                _myIni.Write("ShowLyrics", "True", "Common");
            if (!_myIni.KeyExists("Serial", "Device"))
                _myIni.Write("Serial", "False", "Device");
            if (!_myIni.KeyExists("BarColor", "Common"))
                _myIni.Write("BarColor", "2", "Common");
            if (!_myIni.KeyExists("Network", "Common"))
                _myIni.Write("Network", "False", "Common");
            if (!_myIni.KeyExists("RelatedArtist", "Common"))
                _myIni.Write("RelatedArtist", "True", "Common");
            if (!_myIni.KeyExists("AlbumArt", "Common"))
                _myIni.Write("AlbumArt", "True", "Common");
            if (!_myIni.KeyExists("Notify", "Common"))
                _myIni.Write("Notify", "True", "Common");
            if (!_myIni.KeyExists("SortDownload", "Common"))
                _myIni.Write("SortDownload", "True", "Common");
            if (!_myIni.KeyExists("Autostart", "Common"))
                _myIni.Write("Autostart", "False", "Common");
            if (!_myIni.KeyExists("Play", "HotKeys"))
                _myIni.Write("Play", "80", "HotKeys");
            if (!_myIni.KeyExists("Next", "HotKeys"))
                _myIni.Write("Next", "78", "HotKeys");
            if (!_myIni.KeyExists("Device", "Device"))
                _myIni.Write("Device", "0", "Device");
            if (!_myIni.KeyExists("Tracking", "Common"))
                _myIni.Write("Tracking", "True", "Common");
            if (!_myIni.KeyExists("Serverip", "ServerClient"))
                _myIni.Write("Serverip", "127.0.0.1", "ServerClient");
            if (!_myIni.KeyExists("Serverport", "ServerClient"))
                _myIni.Write("Serverport", "1337", "ServerClient");
            if (!_myIni.KeyExists("AllowNext", "ServerClient"))
                _myIni.Write("AllowNext", "True", "ServerClient");
            if (!_myIni.KeyExists("AllowPause", "ServerClient"))
                _myIni.Write("AllowPause", "True", "ServerClient");
            if (!_myIni.KeyExists("Volume", "Device"))
                _myIni.Write("Volume", "10", "Device");
            if (!_myIni.KeyExists("SerialPort", "Device"))
                _myIni.Write("SerialPort", "1", "Device");
            if (!_myIni.KeyExists("Enabled", "Slack"))
                _myIni.Write("Enabled", "False", "Slack");
            if (!_myIni.KeyExists("Botname", "Slack"))
                _myIni.Write("Botname", "ThugByte", "Slack");
            if (!_myIni.KeyExists("Apikey", "Slack"))
                _myIni.Write("Apikey", "", "Slack");
            if (!_myIni.KeyExists("Channel", "Slack"))
                _myIni.Write("Channel", "#random", "Slack");

            CheckThemeFile();
        }

        private void CheckThemeFile()
        {
            if (!_myIni.KeyExists("MainFormBackground", "MainForm"))
                _myIni.Write("MainFormBackground", "ButtonFace", "MainForm");
            if (!_myIni.KeyExists("MenuBackground", "MainForm"))
                _myIni.Write("MenuBackground", "ButtonFace", "MainForm");
            if (!_myIni.KeyExists("VersionText", "MainForm"))
                _myIni.Write("VersionText", "Black", "MainForm");
            if (!_myIni.KeyExists("CurrentSecondsText", "MainForm"))
                _myIni.Write("CurrentSecondsText", "Black", "MainForm");
            if (!_myIni.KeyExists("CheckboxRepeatText", "MainForm"))
                _myIni.Write("CheckboxRepeatText", "Black", "MainForm");
            if (!_myIni.KeyExists("CheckboxSuffleText", "MainForm"))
                _myIni.Write("CheckboxSuffleText", "Black", "MainForm");
            if (!_myIni.KeyExists("TotalHitText", "MainForm"))
                _myIni.Write("TotalHitText", "Black", "MainForm");
            if (!_myIni.KeyExists("label3Text", "MainForm"))
                _myIni.Write("label3Text", "Black", "MainForm");
            if (!_myIni.KeyExists("labeldefaultText", "MainForm"))
                _myIni.Write("label2Text", "Black", "MainForm");
            if (!_myIni.KeyExists("label2Text", "MainForm"))
                _myIni.Write("lbStatusText", "Black", "MainForm");
            if (!_myIni.KeyExists("menuStrip1Text", "MainForm"))
                _myIni.Write("menuStrip1Text", "Black", "MainForm");
            if (!_myIni.KeyExists("NextButtonText", "Buttons"))
                _myIni.Write("NextButtonText", "Black", "Buttons");
            if (!_myIni.KeyExists("FilterButtonText", "Buttons"))
                _myIni.Write("FilterButtonText", "Black", "Buttons");
            if (!_myIni.KeyExists("PlayButtonText", "Buttons"))
                _myIni.Write("PlayButtonText", "Black", "Buttons");
            if (!_myIni.KeyExists("SourceButtonText", "Buttons"))
                _myIni.Write("SourceButtonText", "Black", "Buttons");
            if (!_myIni.KeyExists("SearchButtonText", "Buttons"))
                _myIni.Write("SearchButtonText", "Black", "Buttons");
            if (!_myIni.KeyExists("NextButtonBackground", "Buttons"))
                _myIni.Write("NextButtonBackground", "ButtonFace", "Buttons");
            if (!_myIni.KeyExists("FilterButtonBackground", "Buttons"))
                _myIni.Write("FilterButtonBackground", "ButtonFace", "Buttons");
            if (!_myIni.KeyExists("PlayButtonBackground", "Buttons"))
                _myIni.Write("PlayButtonBackground", "ButtonFace", "Buttons");
            if (!_myIni.KeyExists("SourceButtonBackground", "Buttons"))
                _myIni.Write("SourceButtonBackground", "ButtonFace", "Buttons");
            if (!_myIni.KeyExists("SearchButtonBackground", "Buttons"))
                _myIni.Write("SearchButtonBackground", "ButtonFace", "Buttons");
            if (!_myIni.KeyExists("lvSearchBackground", "TextBoxes"))
                _myIni.Write("lvSearchBackground", "White", "TextBoxes");
            if (!_myIni.KeyExists("rtbLyricsText", "TextBoxes"))
                _myIni.Write("rtbLyricsText", "Black", "TextBoxes");
            if (!_myIni.KeyExists("lbRelatedText", "TextBoxes"))
                _myIni.Write("lbRelatedText", "Black", "TextBoxes");
            if (!_myIni.KeyExists("lbRelatedText", "TextBoxes"))
                _myIni.Write("lbRelatedText", "Black", "TextBoxes");
            if (!_myIni.KeyExists("lvSearchText", "TextBoxes"))
                _myIni.Write("lvSearchText", "Black", "TextBoxes");
            if (!_myIni.KeyExists("tbSearchBackground", "TextBoxes"))
                _myIni.Write("tbSearchBackground", "White", "TextBoxes");
            if (!_myIni.KeyExists("rtbLyricsBackground", "TextBoxes"))
                _myIni.Write("rtbLyricsBackground", "White", "TextBoxes");
            if (!_myIni.KeyExists("lbRelatedBackground", "TextBoxes"))
                _myIni.Write("lbRelatedBackground", "White", "TextBoxes");
        }

        private void SetStatistic(string version)
        {
            if (!_tracking) return;
            var htmlWeb = new HtmlWeb();
            htmlWeb.Load("http://kluwert.se/groovy/stattest.php?pc=" + Environment.MachineName + "&version=" +
                         HelperClass.Sanitize(version));
        }

        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
                StartSearch();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12,
                e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void renderTabExit()
        {
            var tabLength = tabControl1.ItemSize.Width;

            // measure the text in each tab and make adjustment to the size
            for (var i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var currentPage = tabControl1.TabPages[i];

                var currentTabLength = TextRenderer.MeasureText(currentPage.Text, tabControl1.Font).Width;
                // adjust the length for what text is written
                currentTabLength += LEADING_SPACE + CLOSE_SPACE + CLOSE_AREA;

                if (currentTabLength > tabLength)
                    tabLength = currentTabLength;
            }

            // create the new size
            var newTabSize = new Size(tabLength, tabControl1.ItemSize.Height);
            tabControl1.ItemSize = newTabSize;
        }


        private void CheckForNewVersion()
        {
            var updater = new update(_version);
            if (updater.CheckForNewVersion())
                using (var form = new CustomBox(updater.Change))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        updater.StartUpdater();
                        Environment.Exit(0);
                    }
                }
        }


        //private int GetSelecetedIndex(ComboBox cb)
        //{
        //    if (cb.InvokeRequired)
        //        return (int)cb.Invoke(new Func<int>(GetSelecetedIndex(cb)));
        //    return cb.SelectedIndex;
        //}
        public bool GetCbRandom()
        {
            return cbShuffle.Checked;
        }

        public bool GetCbLoop()
        {
            return cbRepeat.Checked;
        }

        private void SetHardware(string songinfo)
        {
            var iIdx = default(int);
            var c = new byte[129];
            //Send buffer
            var CCount = default(int);

            var result = songinfo;
            if (songinfo.Length > 40)
                result = songinfo.Substring(0, 40);


            try
            {
                if (!sp.IsOpen)
                {
                    sp.PortName = "COM" + _serialPort;
                    sp.Open();
                }
                for (iIdx = 0; iIdx <= result.Length - 1; iIdx++)
                    c[iIdx] = (byte) Strings.Asc(result.Substring(iIdx, 1));

                sp.Write(c, 0, iIdx);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Debug.WriteLine("Error could not set Title");
            }
        }

        private void ClearScreen()
        {
            string[] s = null;
            var iIdx = default(int);
            var c = new byte[129];
            //Send buffer
            var CCount = default(int);
            //Send buffer counter
            var clearscreen = "%04%01%67%49%88%23";

            if (!sp.IsOpen)
            {
                sp.PortName = "COM" + _serialPort;
                sp.Open();
            }

            s = Strings.Split(clearscreen, "%");
            for (iIdx = 0; iIdx <= Information.UBound(s); iIdx++)
                if (!string.IsNullOrEmpty(s[iIdx]))
                {
                    c[CCount] = (byte) Conversion.Val(s[iIdx]);
                    //Set character to binarry array
                    CCount = CCount + 1;
                }
            sp.Write(c, 0, CCount);
            //Output from serial port
        }

        private void PostSlack(song sendsong)

        {
            var urlWithAccessToken = _slackapiurl;

            var client = new SlackClient(urlWithAccessToken);

            client.PostMessage(username: _slackUsername,
                text: "Song: " + sendsong.GetSongInfo() + " Duratation: " + sendsong.SecToMin(),
                channel: _slackChannel);
        }

        //public void PlaySong(song playingSong,SongTab stTab)
        //{
        //    if (_simpleClient != null)
        //    {
        //        _simpleClient.Send(_searchResults[lvSearch.FocusedItem.Index].Compactinfo());
        //    }
        //    else
        //    {
        //        if (playingSong.URL == "NULL")
        //        {
        //            Debug.WriteLine(_currentIndex);
        //            _searchResults[_currentIndex].URL =
        //                HelperClass.Resolvkey(_searchResults[_currentIndex].Key);
        //            playingSong.URL = _searchResults[_currentIndex].URL;
        //        }

        //        Totaltime(_isFromPlayList
        //            ? _playlist[_currentIndex].SecToMin()
        //            : _searchResults[_currentIndex].SecToMin());

        //        Stopthread();

        //        _workerObject = new AudioPlayer(playingSong.GetUrl(), _device);
        //        _workerObject.SongComplete += NextSong;
        //        _workerObject.GetVolume += GetVolume;

        //        var workerThread = new Thread(_workerObject.DoWork);
        //        _workerObject.SongCurrTime += SetTime;
        //        workerThread.Start();
        //        SetText($"{playingSong.SecToMin()}", label1);
        //        SetText($"{playingSong.Artist}" + "\n" + playingSong.Songname, label4);

        //        if (_showLyrics)
        //            SetRichText(PullLyrics(playingSong.Artist, playingSong.Songname), rtbLyrics);

        //        if (_related)
        //            SetSimilareArtists(playingSong.Artist);
        //        if (_coverArt)
        //            PullAlbumArt(playingSong.Artist, playingSong.Songname);
        //        if (_notify)
        //            if (WindowState == FormWindowState.Minimized)
        //                mynotifyicon.ShowBalloonTip(5000, playingSong.Artist, playingSong.Songname, ToolTipIcon.None);
        //        if (_serial)
        //        {
        //            ClearScreen();
        //            SetHardware(playingSong.GetSongInfo());
        //        }
        //        if (_slack)
        //        {
        //            PostSlack(playingSong);
        //        }

        //    }
        //}

        public void PlaySong(song playingSong, SongTab stTab)
        {
            _currenttab = stTab;
            if (playingSong.URL == "NULL")
            {
                stTab._searchSongs[stTab._currentindex].URL =
                    HelperClass.Resolvkey(stTab._searchSongs[stTab._currentindex].Key);
                playingSong.URL = stTab._searchSongs[stTab._currentindex].URL;
            }

            Totaltime(stTab._searchSongs[stTab._currentindex].SecToMin());

            Stopthread();

            _workerObject = new AudioPlayer(playingSong.GetUrl(), _device);
            _workerObject.SongComplete += stTab.NextSong;
            _workerObject.GetVolume += GetVolume;

            var workerThread = new Thread(_workerObject.DoWork);
            _workerObject.SongCurrTime += SetTime;
            workerThread.Start();
            SetText($"{playingSong.SecToMin()}", label1);
            SetText($"{playingSong.Artist}" + "\n" + playingSong.Songname, label4);

            if (_showLyrics)
                SetRichText(PullLyrics(playingSong.Artist, playingSong.Songname), rtbLyrics);

            if (_related)
                SetSimilareArtists(playingSong.Artist);
            if (_coverArt)
                PullAlbumArt(playingSong.Artist, playingSong.Songname);
            if (_notify)
                if (WindowState == FormWindowState.Minimized)
                    mynotifyicon.ShowBalloonTip(5000, playingSong.Artist, playingSong.Songname, ToolTipIcon.None);
            if (_serial)
            {
                ClearScreen();
                SetHardware(playingSong.GetSongInfo());
            }
            if (_slack)
                PostSlack(playingSong);
        }

        private void PullAlbumArt(string artist, string currSong)
        {
            try
            {
                var url =
                    $"http://ws.audioscrobbler.com/2.0/?method=track.getInfo&api_key=97be004c555375dec1f9455cafbf2ae1&artist={artist.Trim()}&track={currSong.Trim()}&format=json";

                var response = JsonConvert.DeserializeObject<LastFMInfo>(new WebClient().DownloadString(url));

                var request = WebRequest.Create(response.track.album.image[2].imageurl);

                using (var rep = request.GetResponse())
                {
                    using (var stream = rep.GetResponseStream())
                    {
                        if (stream != null) pbAlbum.Image = System.Drawing.Image.FromStream(stream);
                    }
                }
            }
            catch (Exception)
            {
                pbAlbum.Image = Resources.artwork;
            }
        }

        private void SetSimilareArtists(string artist)
        {
            ClearListbox(lbRelated);

            try
            {
                var url =
                    $"http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist={artist.Trim()}&api_key=97be004c555375dec1f9455cafbf2ae1&limit=10&format=json";

                var response = JsonConvert.DeserializeObject<SimArt>(new WebClient().DownloadString(url));
                foreach (var relatedArtists in response.similarartists.artist)
                    AddListBox(lbRelated, relatedArtists.name);
            }
            catch (Exception)
            {
                // ignored
            }
        }


        private void SetTime(double currenttime)
        {
            var x = currenttime;
            var t = TimeSpan.FromSeconds(x);

            var formatedTime = $"{t.Minutes:D2}M:{t.Seconds:D2}S";

            var xy = (int) (x + 0.5d);
            SetText(formatedTime, lblCurrentSec);
            if (xy <= pbMusictrack.Maximum)
                SetSpan(xy);
        }

        private void Totaltime(string time)
        {
            SetTotal(HelperClass.String2Sek(time));
        }


        private void Stopthread()
        {
            try
            {
                _workerObject.RequestStop();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 1);
            UnregisterHotKey(Handle, 2);
            if (_dlman != null)
                _dlman.Dispose();


            Environment.Exit(Environment.ExitCode);
        }


        public void DownloadSong(song itemsong)
        {
            if (_dlman == null)
            {
                _dlman = new DownloadManager();
                _dlman.Show();
            }
            _dlman.AddItemsListview(itemsong);
        }

        private void pbMusictrack_MouseClick(object sender, MouseEventArgs e)
        {
            if (pbMusictrack.Value <= 0) return;
            float absoluteMouse = PointToClient(MousePosition).X - pbMusictrack.Bounds.X;
            var calcFactor = pbMusictrack.Width / (float) pbMusictrack.Maximum;
            var relativeMouse = absoluteMouse / calcFactor;
            pbMusictrack.Value = Convert.ToInt32(relativeMouse);
            var ts = TimeSpan.FromSeconds(pbMusictrack.Value);
            _workerObject.SongJump(ts);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _currenttab.NextSong();
            }


            catch (Exception)
            {
                MessageBox.Show(@"How do you Next which does not exist?", @"Error", MessageBoxButtons.OK);
            }
        }


        private void btPlayPause_Click(object sender, EventArgs e)
        {
            try
            {
                _workerObject.RequestPause();
            }
            catch (Exception)
            {
                MessageBox.Show(@"No song playing or selected.", @"Error", MessageBoxButtons.OK);
            }
        }


        //Method replaces first letter of all words to UPPERCASE and replaces all spaces with underscores.


        private string PullLyrics(string strArtist, string strSongTitle)
        {
            strArtist = strArtist.Trim();
            strSongTitle = strSongTitle.Trim();

            string sLyrics = null;
            var sUrl = @"http://lyrics.wikia.com/index.php?title=" + HelperClass.Sanitize(strArtist) + ":" +
                       HelperClass.Sanitize(strSongTitle);

            _htmlWeb = new HtmlWeb {AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("iso-8859-2")};
            var htmlDocument = _htmlWeb.Load(sUrl);
            try
            {
                var dinks =
                    htmlDocument.DocumentNode.SelectNodes("//div[@class='lyricbox']//text()")
                        .Select(x => x.InnerText.Trim());
                var links = dinks as string[] ?? dinks.ToArray();
                for (var i = 0; i < links.Length - 1; i++)
                    sLyrics += links.ElementAt(i) + "\n\n";
                if (sLyrics != null)
                {
                    sLyrics = WebUtility.HtmlDecode(sLyrics);

                    return sLyrics;
                }
            }

            catch (Exception)
            {
                sLyrics = "No lyrics found";
            }
            return sLyrics;
        }


        private void SetAutoComplete()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(File.ReadAllLines(@"autocomp.txt"));
            SetSearch(tbSearch, source);
        }


        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            StartSearch();
        }

        private void removeDupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(@"autocomp.txt", File.ReadAllLines(@"autocomp.txt").Distinct());
        }


        private void downloadManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dlman == null)
                _dlman = new DownloadManager();
            _dlman.Show();
        }

        private void cmsDownload_Click(object sender, EventArgs e)
        {
            var downloadsong = _currenttab.GetSelectedSong();


            if (_dlman == null)
            {
                _dlman = new DownloadManager();
                _dlman.Show();
            }
            DownloadSong(downloadsong);
        }

        public void SetSearchBox(string text)
        {
            tbSearch.Text = text;
        }


        private void lbRelated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbRelated.SelectedIndex > -1)
            {
                tbSearch.Text = lbRelated.SelectedItem.ToString();
                StartSearch();
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            StartSearch();
        }

        private void StartSearch()
        {
            switch (cbSource.SelectedIndex)
            {
                case 2:
                    new Thread(
                        () =>
                        {
                            var mp3m = new Mp3pm();
                            mp3m.SetLabel += SetStatus;
                            Debug.Write("Source 3");
                            _searchResults = mp3m.SearchAsync(tbSearch.Text, ReadControlText(cbFilter),
                                ReadControlText(cbRussian));

                            AddNewTab(_searchResults);
                            SetText("Total: " + _searchResults.Count(), lblTotal);
                            SetValueSearch(tbSearch, tbSearch.Text);
                        }).Start();
                    break;
                case 1:
                    new Thread(
                        () =>
                        {
                            var pleer = new Pleer();
                            pleer.SetLabel += SetStatus;

                            Debug.Write("Source 2");
                            _searchResults = pleer.SearchAsync(tbSearch.Text, ReadControlText(cbFilter),
                                ReadControlText(cbRussian));

                            AddNewTab(_searchResults);
                            SetText("Total: " + _searchResults.Count(), lblTotal);
                            SetValueSearch(tbSearch, tbSearch.Text);
                        }).Start();
                    break;
                case 0:
                    new Thread(
                        async () =>
                        {
                            var myfreemp3 = new Myfreemp3();
                            myfreemp3.SetLabel += SetStatus;
                            Debug.Write("Source 1");
                            _searchResults = await myfreemp3.SearchAsync(tbSearch.Text, ReadControlText(cbFilter),
                                ReadControlText(cbRussian));

                            AddNewTab(_searchResults);
                            SetText("Total: " + _searchResults.Count(), lblTotal);
                            SetValueSearch(tbSearch, tbSearch.Text);
                        }).Start();
                    break;
            }

            var file2 = new StreamWriter(@"autocomp.txt", true);
            file2.WriteLine(tbSearch.Text);
            file2.Close();
            renderTabExit();
        }

        public void AddNewTab(List<song> sr)
        {
            var myUserControl = new SongTab(sr, this);

            var myTabPage = new TabPage(); //Create new tabpage
            myTabPage.Controls.Add(myUserControl);
            myTabPage.Text = tbSearch.Text;

            AddTabControl(tabControl1, myTabPage);
        }


        private float GetVolume()
        {
            if (tbVolume.InvokeRequired)
                return (float) tbVolume.Invoke(new Func<float>(GetVolume));
            if (tbVolume.Value == 1)
                return 0.0F;


            return tbVolume.Value * 0.05f;
        }

        private void tbVolume_ValueChanged(object sender, EventArgs e)
        {
            _myIni.Write("Volume", tbVolume.Value.ToString(), "Device");
            _workerObject?.SetVolume(GetVolume());
        }


        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Options())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadSettings();
                    UnregisterHotKey(Handle, Convert.ToInt32(_myIni.Read("Next", "HotKeys")));
                    UnregisterHotKey(Handle, Convert.ToInt32(_myIni.Read("Play", "HotKeys")));
                    SetHotKeys();
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (_notify)
                if (WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = false;
                    mynotifyicon.Visible = true;
                    SetHotKeys();
                }
        }

        private void mynotifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            mynotifyicon.Visible = false;
            WindowState = FormWindowState.Normal;
            SetHotKeys();
        }

        private void cmsNotifyPlayPause_Click(object sender, EventArgs e)
        {
            try
            {
                _workerObject.RequestPause();
            }
            catch (Exception)
            {
                MessageBox.Show(@"No song playing or selected.", @"Error", MessageBoxButtons.OK);
            }
        }

        private void cmsNotifyNext_Click(object sender, EventArgs e)
        {
            try
            {
                //NextSong();
            }
            catch (Exception)
            {
                MessageBox.Show(@"No song playing or selected.", @"Error", MessageBoxButtons.OK);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }


        private void SetStatus(string status)
        {
            SetText(status, lbStatus);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && (int) m.WParam == 1)
                try
                {
                    _currenttab.NextSong();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"No song playing or selected.", @"Error", MessageBoxButtons.OK);
                }
            if (m.Msg == WM_HOTKEY && (int) m.WParam == 2)
                try
                {
                    _workerObject.RequestPause();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"No song playing or selected.", @"Error", MessageBoxButtons.OK);
                }
            base.WndProc(ref m);
        }


        private void openWebserviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_nancy != null)
                Process.Start("http://localhost:666");
            else
                MessageBox.Show("You forgot to start the webservice", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                //lvSearch.BackColor = colorDialog1.Color;
                lbRelated.BackColor = colorDialog1.Color;
                rtbLyrics.BackColor = colorDialog1.Color;
                tbSearch.BackColor = colorDialog1.Color;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                //lvSearch.ForeColor = colorDialog1.Color;
                lbRelated.ForeColor = colorDialog1.Color;
                rtbLyrics.ForeColor = colorDialog1.Color;
                tbSearch.ForeColor = colorDialog1.Color;
            }
        }

        private void backgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                BackColor = colorDialog1.Color;
                menuStrip1.BackColor = colorDialog1.Color;
            }
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.

                lbRelated.ForeColor = colorDialog1.Color;
                lbVersion.ForeColor = colorDialog1.Color;
                lblCurrentSec.ForeColor = colorDialog1.Color;

                cbRepeat.ForeColor = colorDialog1.Color;
                cbShuffle.ForeColor = colorDialog1.Color;
                lblTotal.ForeColor = colorDialog1.Color;
                label3.ForeColor = colorDialog1.Color;
                label2.ForeColor = colorDialog1.Color;
                lbStatus.ForeColor = colorDialog1.Color;
                label1.ForeColor = colorDialog1.Color;
                menuStrip1.ForeColor = colorDialog1.Color;
            }
        }

        private void textToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                cbSource.ForeColor = colorDialog1.Color;
                cbFilter.ForeColor = colorDialog1.Color;
                btPlayPause.ForeColor = colorDialog1.Color;
                btSearch.ForeColor = colorDialog1.Color;
                button5.ForeColor = colorDialog1.Color;
            }
        }

        private void backgroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                cbSource.BackColor = colorDialog1.Color;
                cbFilter.BackColor = colorDialog1.Color;
                btPlayPause.BackColor = colorDialog1.Color;
                btSearch.BackColor = colorDialog1.Color;
                button5.BackColor = colorDialog1.Color;
                btSearch.FlatAppearance.BorderColor = colorDialog1.Color;
            }
        }

        private void resetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BackColor = default(Color);
            menuStrip1.BackColor = default(Color);
            lbRelated.ForeColor = default(Color);
            lbVersion.ForeColor = default(Color);
            lblCurrentSec.ForeColor = default(Color);

            cbRepeat.ForeColor = default(Color);
            cbShuffle.ForeColor = default(Color);
            lblTotal.ForeColor = default(Color);
            label3.ForeColor = default(Color);
            label2.ForeColor = default(Color);
            lbStatus.ForeColor = default(Color);
            label1.ForeColor = default(Color);
            menuStrip1.ForeColor = default(Color);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lvSearch.BackColor = default(Color);
            lbRelated.BackColor = default(Color);
            rtbLyrics.BackColor = default(Color);
            tbSearch.BackColor = default(Color);
            //lvSearch.ForeColor = default(Color);
            lbRelated.ForeColor = default(Color);
            rtbLyrics.ForeColor = default(Color);
            tbSearch.ForeColor = default(Color);
        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cbSource.BackColor = default(Color);
            cbFilter.BackColor = default(Color);
            btPlayPause.BackColor = default(Color);
            btSearch.BackColor = default(Color);
            button5.BackColor = default(Color);
            cbSource.ForeColor = default(Color);
            cbFilter.ForeColor = default(Color);
            btPlayPause.ForeColor = default(Color);
            btSearch.ForeColor = default(Color);
            button5.ForeColor = default(Color);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainForm
            _myIni.Write("lbStatusText", lbStatus.ForeColor.Name, "MainForm");
            _myIni.Write("CurrentSecondsText", lblCurrentSec.ForeColor.Name, "MainForm");
            _myIni.Write("CheckboxRepeatText", cbRepeat.ForeColor.Name, "MainForm");
            _myIni.Write("CheckboxSuffleText", cbShuffle.ForeColor.Name, "MainForm");
            _myIni.Write("TotalHitText", lblTotal.ForeColor.Name, "MainForm");
            _myIni.Write("label3Text", label3.ForeColor.Name, "MainForm");
            _myIni.Write("label2Text", label2.ForeColor.Name, "MainForm");
            _myIni.Write("menuStrip1Text", menuStrip1.ForeColor.Name, "MainForm");
            _myIni.Write("MainFormBackground", BackColor.Name, "MainForm");
            _myIni.Write("MenuBackground", menuStrip1.BackColor.Name, "MainForm");


            //Buttons
            _myIni.Write("NextButtonText", button5.ForeColor.Name, "Buttons");
            _myIni.Write("FilterButtonText", cbFilter.ForeColor.Name, "Buttons");
            _myIni.Write("PlayButtonText", btPlayPause.ForeColor.Name, "Buttons");
            _myIni.Write("SourceButtonText", cbSource.ForeColor.Name, "Buttons");
            _myIni.Write("SearchButtonText", btSearch.ForeColor.Name, "Buttons");

            _myIni.Write("NextButtonBackground", button5.BackColor.Name, "Buttons");
            _myIni.Write("FilterButtonBackground", cbFilter.BackColor.Name, "Buttons");
            _myIni.Write("PlayButtonBackground", btPlayPause.BackColor.Name, "Buttons");
            _myIni.Write("SourceButtonBackground", cbSource.BackColor.Name, "Buttons");
            _myIni.Write("SearchButtonBackground", btSearch.BackColor.Name, "Buttons");

            //Boxes
            //_myIni.Write("lvSearchBackground", lvSearch.BackColor.Name, "Buttons");
            _myIni.Write("rtbLyricsText", rtbLyrics.ForeColor.Name, "Buttons");
            _myIni.Write("lbRelatedText", lbRelated.ForeColor.Name, "Buttons");
            // _myIni.Write("lvSearchText", lvSearch.ForeColor.Name, "Buttons");
            _myIni.Write("tbSearchBackground", tbSearch.BackColor.Name, "Buttons");
            _myIni.Write("rtbLyricsBackground", rtbLyrics.BackColor.Name, "Buttons");
            _myIni.Write("lbRelatedBackground", lbRelated.BackColor.Name, "Buttons");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void testSlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                var closeButton = new Rectangle(r.Right - 15, r.Top + 4, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #region InvokeFunctions

        private delegate void SetTextCallback(string text, Label lab);

        private delegate void SetRichTextCallback(string text, Control rtb);

        private delegate void SetSpanCallback(int time);

        private delegate void SetTotalCallback(int time);


        private delegate void SetListViewSelectedCallBack(int time, ListView listb);

        private delegate void SetSearchCallBack(TextBox tb, AutoCompleteStringCollection suggest);

        private delegate void AddListviewCallback(ListViewItem newlv, ListView oldlv);

        private delegate void ClearListviewCallback(ListView oldlv);

        private delegate void ClearListBoxviewCallback(ListBox oldlb);

        private delegate void SetListViewClearCallBack(ListView listv);


        private delegate void SettListViewAddCallBack(ListView listv, List<song> sr);

        private delegate void SetSearchValueCallBack(TextBox tb, string suggest);

        private delegate void SetTabValueCallback(TabControl tc, TabPage tp);

        private delegate void SetAddListBoxCallBack(ListBox listb, string artist);

        public static int ReadControlText(ComboBox varControl)
        {
            if (varControl.InvokeRequired)
                return (int) varControl.Invoke(
                    new Func<int>(() => ReadControlText(varControl))
                );
            var varText = varControl.SelectedIndex;
            return varText;
        }


        private void AddTabControl(TabControl tc, TabPage tp)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tabControl1.InvokeRequired)
            {
                SetTabValueCallback d = AddTabControl;
                Invoke(d, tc, tp);
            }
            else
            {
                tc.TabPages.Add(tp);
            }
        }

        private void SetRichText(string text, Control rtb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (rtb.InvokeRequired)
            {
                SetRichTextCallback d = SetRichText;
                Invoke(d, text, rtb);
            }
            else
            {
                rtb.Text = text;
            }
        }

        private void ClearListbox(ListBox oldlb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (oldlb.InvokeRequired)
            {
                ClearListBoxviewCallback d = ClearListbox;
                Invoke(d, oldlb);
            }
            else
            {
                oldlb.Items.Clear();
            }
        }

        private void AddListBox(ListBox listb, string artist)
        {
            if (listb.InvokeRequired)
            {
                SetAddListBoxCallBack d = AddListBox;
                Invoke(d, listb, artist);
            }
            else
            {
                listb.Items.Add(artist);
            }
        }


        private void SetText(string text, Label lab)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (lab.InvokeRequired)
            {
                SetTextCallback d = SetText;
                Invoke(d, text, lab);
            }
            else
            {
                lab.Text = text;
            }
        }

        private void SetSpan(int time)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pbMusictrack.InvokeRequired)
            {
                SetSpanCallback d = SetSpan;
                Invoke(d, time);
            }
            else
            {
                pbMusictrack.Value = time;
            }
        }

        private void SetTotal(int time)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pbMusictrack.InvokeRequired)
            {
                SetTotalCallback d = SetTotal;
                Invoke(d, time);
            }
            else
            {
                pbMusictrack.Maximum = time + 1;
            }
        }

        private void SetSearch(TextBox tb, AutoCompleteStringCollection suggest)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pbMusictrack.InvokeRequired)
            {
                SetSearchCallBack d = SetSearch;
                Invoke(d, tb, suggest);
            }
            else
            {
                tb.AutoCompleteCustomSource = suggest;
            }
        }

        private void SetValueSearch(TextBox tb, string suggest)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pbMusictrack.InvokeRequired)
            {
                SetSearchValueCallBack d = SetValueSearch;
                Invoke(d, tb, suggest);
            }
            else
            {
                tb.AutoCompleteCustomSource.Add(suggest);
            }
        }


        private void SetListViewClear(ListView listv)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (listv.InvokeRequired)
            {
                SetListViewClearCallBack d = SetListViewClear;
                Invoke(d, listv);
            }
            else
            {
                listv.Items.Clear();
            }
        }

        private void ListViewAdd(ListView listv, List<song> sr)
        {
            if (listv.InvokeRequired)
            {
                SettListViewAddCallBack d = ListViewAdd;
                Invoke(d, listv, sr);
            }
            else
            {
                foreach (var song in sr)
                {
                    var fixedlv = new ListViewItem(song.Artist);

                    fixedlv.SubItems.Add(song.Songname);
                    fixedlv.SubItems.Add(song.SecToMin());
                    fixedlv.ToolTipText = song.GetSongInfo();
                    listv.Items.Add(fixedlv);
                }
            }
        }

        #endregion
    }


    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);

        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr) state, IntPtr.Zero);
        }
    }
}