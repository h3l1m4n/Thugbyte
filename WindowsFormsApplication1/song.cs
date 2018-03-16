using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class song : IComparable<song>
    {
        private string artist;
        private string rate;
        private string size;
        private string songname;

        private string time;
        private string url;
        private string key;

        public song()
        {
        }
        public song( string artist, string key, string time, string songname)
        {
            this.key = key;
            this.artist = artist;
            this.time = time;
            this.songname = songname;
            url = "NULL";
            songname.Replace("mp3", "");
        }
        public song(string url, string artist, bool isFromPlayList, string time, string songname)
        {
            this.url = url;
            this.artist = artist;
            this.time = time;
            this.songname = songname;
        
            songname.Replace("mp3", "");
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public string Songname
        {
            get { return songname; }
            set { songname = value; }
        }

        public int CompareTo(song Song)
        {
            if (artist == Song.artist)
            {
                if (songname == Song.songname)
                {
                    return time.CompareTo(Song.Time);
                }
            }
            return Artist.CompareTo(Song.Artist);
        }

        public string GetUrl()
        {
            return url;
        }

        public string SecToMin()
        {
            var timespan = TimeSpan.FromSeconds(Convert.ToDouble(time));
            return timespan.ToString(@"mm\:ss");
        }

        public string GetSongInfo()
        {
            return artist + " - " + songname;
        }

        public string Compactinfo()
        {
            var info = artist + "╣" + songname + "╣" + time + "╣" + url;
            return HelperClass.EncryptString(info);

        }

       
    }
}