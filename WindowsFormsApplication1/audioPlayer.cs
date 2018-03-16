using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.Wave;

namespace WindowsFormsApplication1
{
    public class AudioPlayer
    {
        public delegate float GetVolumeEventHandler();

        public delegate void SongCompleteEventHandler();

        public delegate void SongCurrentTime(double tp);

        public delegate void SongTotalTime(TimeSpan tp);

        private readonly Stream _ms = new MemoryStream();
        private readonly string _url;
        private readonly int _device;

        private WaveStream _blockAlignedStream;
        private bool _isPaused;
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;
        private float _volume = 1.0F;
        private readonly CookieContainer cookie = new CookieContainer();

        public AudioPlayer(string url, int device)
        {
            _url = url;
            _device = device;
        }

        public event SongCompleteEventHandler SongComplete;
        public event GetVolumeEventHandler GetVolume;
        public event SongCurrentTime SongCurrTime;
        public event SongTotalTime SongTotTime;

        public void DoWork()
        {
            PlayMp3FromUrl(_url);
        }

        public void PlayMp3FromUrl(string url)
        {
            new Thread(delegate(object o)
            {
             


                var request = (HttpWebRequest) WebRequest.Create(url);
                request.CookieContainer = cookie;
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko";
                request.Method = "GET";
                request.Accept = "text/html";
                request.AllowAutoRedirect = true;
                request.Timeout = 15000;
                request.ReadWriteTimeout = 15000;
                try
                {
                    var response = request.GetResponse();


                    using (var stream = response.GetResponseStream())
                    {
                        var buffer = new byte[65536]; // 64KB chunks
                        int read;
                        while (stream != null && (read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            var pos = _ms.Position;
                            _ms.Position = _ms.Length;
                            _ms.Write(buffer, 0, read);
                            _ms.Position = pos;
                        }
                    }
                }
                catch (WebException)
                {
                    Debug.WriteLine("Error retriving or playing stream");

                    if (SongComplete != null) SongComplete();
                }
            }).Start();

            // Pre-buffering some data to allow NAudio to start playing
            while (_ms.Length < 65536*10)
                Thread.Sleep(1000);

            _ms.Position = 0;
            try
            {
                using (
                    _blockAlignedStream =
                        new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(_ms)))
                    )
                {
                    using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.DeviceNumber = _device;
                        waveOut.Init(_blockAlignedStream);
                       
                        waveOut.Play();

                        while (waveOut.PlaybackState != PlaybackState.Stopped)
                        {
                            if (GetVolume != null) waveOut.Volume = GetVolume();
                           // Debug.WriteLine(GetVolume());

                            if (_shouldStop)
                            {
                                waveOut.Stop();
                            }

                            if (_isPaused)
                            {
                                waveOut.Pause();
                            }
                            if (!_isPaused)
                            {
                                waveOut.Resume();
                            }


                            if (waveOut.PlaybackState == PlaybackState.Playing)
                                Thread.Sleep(100);
                            SongCurrTime?.Invoke(_blockAlignedStream.CurrentTime.TotalSeconds);
                            if (waveOut.PlaybackState == PlaybackState.Paused)
                            {
                                Thread.Sleep(1000);
                            }
                        }
                        if (waveOut.PlaybackState == PlaybackState.Paused)
                            Debug.WriteLine("IM here 1");
                        if (_shouldStop) return;
                        Debug.WriteLine("IM here 2");
                        _shouldStop = false;
                        waveOut.Stop();
                            
                        waveOut.Dispose();
                        SongComplete?.Invoke();
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Error happend, moving to next song");
                SongComplete?.Invoke();
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void RequestPause()
        {
            _isPaused = !_isPaused;
        }

        public void RequestResume()
        {
            _isPaused = false;
        }

        public TimeSpan Totaltime()
        {
            return _blockAlignedStream.TotalTime;
        }

        public void SongJump(TimeSpan time)
        {
            _blockAlignedStream.SetPosition(time);
        }

        public void SetVolume(float newValue)
        {
            _volume = newValue;
        }

        protected virtual void OnSongTotTime(TimeSpan tp)
        {
            SongTotTime?.Invoke(tp);
        }
    }
}

public static class WaveStreamExtensions
{
    // Set position of WaveStream to nearest block to supplied position
    public static void SetPosition(this WaveStream strm, long position)
    {
        // distance from block boundary (may be 0)
        var adj = position%strm.WaveFormat.BlockAlign;
        // adjust position to boundary and clamp to valid range
        var newPos = Math.Max(0, Math.Min(strm.Length, position - adj));
        // set playback position
        strm.Position = newPos;
    }

    // Set playback position of WaveStream by seconds
    public static void SetPosition(this WaveStream strm, double seconds)
    {
        strm.SetPosition((long) (seconds*strm.WaveFormat.AverageBytesPerSecond));
    }

    // Set playback position of WaveStream by time (as a TimeSpan)
    public static void SetPosition(this WaveStream strm, TimeSpan time)
    {
        strm.SetPosition(time.TotalSeconds);
    }

    // Set playback position of WaveStream relative to current position
    public static void Seek(this WaveStream strm, double offset)
    {
        strm.SetPosition(strm.Position + (long) (offset*strm.WaveFormat.AverageBytesPerSecond));
    }
}