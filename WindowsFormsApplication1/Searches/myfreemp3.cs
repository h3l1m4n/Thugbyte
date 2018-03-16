using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication1.Searches
{
    class Myfreemp3 
    {
        public List<song> SearchResults;
        private bool isRemote;
        public delegate void LabelCurrentStatus(string status);
        private static readonly HttpClient client = new HttpClient();
        public event LabelCurrentStatus SetLabel;
        public Myfreemp3()
        {
            isRemote = false;
            SearchResults = new List<song>();
         
        }
        public Myfreemp3(bool isRemote)
        {
            this.isRemote = isRemote;
            SearchResults = new List<song>();
        }
        //public List<song> Search(string searchSong, int index,int russian)
        //{
        //    SearchResults.Clear();
        //    if (!isRemote)
        //    {
        //        SetLabel("Status: Starting");
        //    }

        //    var totalpages = GetAllPage(1, searchSong);


        //    for (var pages = 1; pages <= totalpages; pages++)
        //    {
        //        var htmlWeb = new HtmlWeb();
        //        var htmlDocument = htmlWeb.Load("https://my-free-mp3.net/mp3/" + searchSong + "?page=" + pages);
        //        if (!isRemote)
        //        {
        //            SetLabel("Status: Getting Pages");
        //        }
        //        var links = htmlDocument.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("data-aid"));

        //        foreach (var link in links)
        //        {
        //            var href = link.Attributes["data-aid"].Value;
        //            var time = link.Attributes["data-duration"].Value;
        //            var name = link.InnerText;
        //            var s = name.Split('-');
        //            if (!isRemote)
        //            {
        //                SetLabel("Status: Gathering data");
        //            }
        //            s[1] = s[1].Replace(" mp3", "");
        //            s[0] = s[0].Trim();
        //            s[1] = s[1].Trim();
        //            bool ruski = false;
        //            switch (russian)
        //            {
        //                case 0:
        //                    break;

        //                case 1:
        //                    ruski = HelperClass.ContainRussian(s[0]);

        //                    break;
        //                case 2:
        //                    ruski = HelperClass.ContainRussian(s[1]);

        //                    break;
        //                case 3:

        //                    ruski = HelperClass.ContainRussian(s[0] + " - " + s[1]);
        //                    break;

        //            }
        //            Debug.WriteLine("Russian: " + ruski.ToString());
        //            if (ruski == false)
        //            {







        //                if (index == 0)
        //                {
        //                    SearchResults.Add(new song("http://s.my-free-mp3.net/stream.php?q=" + href + "/", s[0], false,
        //                        time,
        //                        s[1]));
        //                }
        //                if (index == 1)
        //                {
        //                    if (string.Equals(s[0], searchSong, StringComparison.CurrentCultureIgnoreCase))
        //                    {
        //                        SearchResults.Add(new song("http://s.my-free-mp3.net/stream.php?q=" + href + "/", s[0],
        //                            false,
        //                            time,
        //                            s[1]));
        //                    }
        //                }
        //                if (index == 2)
        //                {
        //                    if (string.Equals(s[1], searchSong, StringComparison.CurrentCultureIgnoreCase))
        //                    {
        //                        SearchResults.Add(new song("http://s.my-free-mp3.net/stream.php?q=" + href + "/", s[0],
        //                            false,
        //                            time,
        //                            s[1]));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (!isRemote)
        //        SetLabel("Status: Done!");
        //    return SearchResults;
        //}

        private int GetAllPage(int startpage, string searchSong)
        {
            while (true)
            {
                if (!isRemote)
                {
                    SetLabel("Status: Converting into songs");
                }
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load("http://my-free-mp3.net/mp3/" + searchSong + "?page=" + startpage);
                var dinks = htmlDocument.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));

                // SetLabel("Status: Getting Pages :1");
                var maxpage = startpage;

                foreach (var dink in dinks)
                {
                    if (dink.Attributes["href"].Value.Contains("?page="))
                    {
                        maxpage = HelperClass.CleanString(dink.Attributes["href"].Value);
                    }
                }

                if (maxpage == startpage)
                {

                    return maxpage;
                }


                startpage = maxpage;
            }
        }



        public async Task<List<song>> SearchAsync(string searchSong, int index, int russian)
        {

            await MakePostAsync(searchSong);

            return SearchResults;

        }

        public void ConvertToList()
        {
            
        }
        private async         Task
MakePostAsync(string searchSong)
        {
            var httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>();
            parameters["q"] = searchSong;

            var response = await httpClient.PostAsync(@"https://my-free-mp3.net/api/search.php", new FormUrlEncodedContent(parameters));
            var contents = await response.Content.ReadAsStringAsync();
            string tempstring = contents.Replace("(", "");
            tempstring = tempstring.Replace(")", "");
            tempstring = tempstring.Replace(";", "");
            RootObject m = JsonConvert.DeserializeObject<RootObject>(tempstring);

            for (int i = 1; i != m.response.Count; i++)
            {
                
                jsonSong ms = JsonConvert.DeserializeObject<jsonSong>(m.response[i].ToString());
                SearchResults.Add(new song(ms.artist, ms.url, ms.duration, ms.title));
            }
        }
    }
    public class RootObject
    {
        public List<object> response { get; set; }
    }
    public class jsonSong
    {
        public int aid { get; set; }
        public int owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string url { get; set; }
    }
}
