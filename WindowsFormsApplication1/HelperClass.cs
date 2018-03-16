using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1.Searches;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    static class HelperClass
    {


        public static string DecryptSong(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                var encryptKey = "QXb30T4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                var byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                var provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                var transform = provider.CreateDecryptor(key, IV);
                var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
            }

            var encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }
      public static string Resolvkey(string key)
        {

            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var json = JsonConvert.DeserializeObject<PleerHelper>(wc.DownloadString("http://pleer.net/site_api/files/get_url?action=play&id=" + key));
            return json.track_link;


        }
        public static string EncryptString(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                var encryptKey = "QXb30T4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                var byteInput = Encoding.UTF8.GetBytes(inputString);
                var provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                var transform = provider.CreateEncryptor(key, IV);
                var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
            }
            return Convert.ToBase64String(memStream.ToArray());
        }
        public static string Sanitize(string s)
        {
            var array = s.Trim().ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array).Trim().Replace(' ', '_');
        }

        public static int String2Sek(string time)
        {
            var result = time.Split(':');
            var totaltime = 0;

            if (result.Length == 3)
            {
                var hour = int.Parse(result[0]);
                var minutes = int.Parse(result[0]);
                var sec = int.Parse(result[1]);
                totaltime = (hour * 60) * 60;
                totaltime += minutes * 60;
                totaltime += sec;
            }
            else if (result.Length == 2)
            {
                var minutes = int.Parse(result[0]);
                var sec = int.Parse(result[1]);
                totaltime = minutes * 60;
                totaltime += sec;
            }


            return totaltime;
        }
        public static int CleanString(string s)
        {
            s = Regex.Replace(s, "[^0-9.]", "");
            return Convert.ToInt32(s);
        }
        //This would be true for the string "abcабв" because it contains at least one cyrillic character.
        public static bool ContainRussian(string text)
        {
            if (Regex.IsMatch(text, @"\p{IsCyrillic}"))
            {
                return true;
            }
            return false;
        }


        public static void SetupFirstRun()
        {
            if (!File.Exists(Application.StartupPath + @"\autocomp.txt"))
            {
                File.WriteAllText(Application.StartupPath + @"\autocomp.txt", @"Rammstein");
            }
            if (!Directory.Exists(Application.StartupPath + @"\playlists"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\playlists");
                var fi = new FileInfo(Application.StartupPath + @"\playlists\ThugByte.Groovy");
                fi.Create().Dispose();
            }
            if (!File.Exists("ThugByte.ini"))
            {
                File.WriteAllText(Application.StartupPath + @"\ThugByte.ini", Resources.ThugByte);
            }
            if (!File.Exists("ThugUpdater.exe"))
            {
                var path = Path.Combine(Application.StartupPath, "ThugUpdater.exe");
                File.WriteAllBytes(path, Resources.ThugUpdater);
            }
        }

        public static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
    }
}
