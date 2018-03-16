using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WindowsFormsApplication1.Searches
{
    class Mp3pm:ISearch
    {
        public delegate void LabelCurrentStatus(string status);

        public event LabelCurrentStatus SetLabel;
        public List<song> SearchResults;
        private bool isRemote;
        public Mp3pm(bool isRemote )
        {
            this.isRemote = isRemote;
            SearchResults = new List<song>();
         
        }

        public Mp3pm()
        {
            isRemote = false;
            SearchResults = new List<song>();
        }
  

        public List<song> SearchAsync(string searchSong, int index,int russian)
        {
            SearchResults.Clear();
            if (!isRemote) {
                SetLabel("Status: Starting");
        }
        for (

        var pages = 1; pages <= GetAllPageSecond(searchSong); pages++)
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load(@"http://mp3pn.info//s/f/" + searchSong + "/page/" + pages);
                if (!isRemote)
                {
                    SetLabel("Status: Loading Songs");
                }

                if (htmlDocument == null) continue;
                htmlDocument.DocumentNode.SelectNodes(".//tbody");
                var res = htmlDocument.DocumentNode.SelectNodes(".//*[@id='xbody']")
                    .Select(row => row.Descendants("li")
                        .Select(td => td.OuterHtml).ToList())
                    .ToList();

                var flattened = res.SelectMany(x => x).ToArray();
                if (!isRemote)
                {
                    SetLabel("Status: Converting into Songs");
                }
                for (var k = 1; k <= flattened.Length - 1; k++)
                {
                    ConvertToSong(flattened[k], index, searchSong,russian);
                }
            }
            if (!isRemote)
            {
                SetLabel("Status: Done!");
            }
            return SearchResults;
        }
        private void ConvertToSong(string song, int index, string searchSong, int russian)
        {
            try
            {
                string[] s = { "Artist", "Titel" };
               
                var href = "";
                var name = "test";
                //get song name
                var namedoc = new HtmlDocument();
                namedoc.LoadHtml(song);

                var anchor1 = namedoc.DocumentNode.SelectSingleNode("//h4");
                if (anchor1 != null)
                {
                    name = anchor1.InnerText.Trim();
                }
                if (name.Contains("\n\t\t\t"))
                {
                    s = name.Split(new[] { "\n\t\t\t" },
                        StringSplitOptions.None);

                   
                
                    s[0] = s[0].Trim();
                    if (s[1].Length <= 0)
                    {
                        s[1] = "No Info";
                    }
                    else
                    {
                        s[1] = s[1].Trim();
                    }
                }

                var time = "";
                var timedoc = new HtmlDocument();
                timedoc.LoadHtml(song);

                var anchor2 = timedoc.DocumentNode.SelectSingleNode("//em");
                if (anchor2 != null)
                {
                    time = anchor2.InnerText;
                }
                time = HelperClass.String2Sek(time).ToString();
                ////get url
                var doc = new HtmlDocument();
                doc.LoadHtml(song);

                var anchor = doc.DocumentNode.SelectSingleNode("//li");
                if (anchor != null)
                {
                    href = anchor.Attributes["data-download-url"].Value;
                }
                bool ruski = false;
                switch (russian)
                {
                    case 0:
                        break;

                    case 1:
                        ruski = HelperClass.ContainRussian(s[0]);

                        break;
                    case 2:
                        ruski = HelperClass.ContainRussian(s[1]);

                        break;
                    case 3:

                        ruski = HelperClass.ContainRussian(s[0] + " - " + s[1]);
                        break;

                }
                Debug.WriteLine("Russian: " + ruski.ToString());
                if (ruski == false)
                {

               

                    if (index == 0)
                {
                    SearchResults.Add(new song(href, s[0], false, time,
                        s[1]));
                }
                if (index == 1)
                {
                    if (string.Equals(s[0], searchSong, StringComparison.CurrentCultureIgnoreCase))
                    {
                        SearchResults.Add(new song(href, s[0], false, time,
                            s[1]));
                    }
                }
                if (index == 2)
                {
                    if (string.Equals(s[1], searchSong, StringComparison.CurrentCultureIgnoreCase))
                    {
                        SearchResults.Add(new song(href, s[0], false, time,
                            s[1]));
                    }
                }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int GetAllPageSecond(string searchSong)
        {
            var totalpage = 1;
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load("http://mp3pm.ws/s/f/" + searchSong);
         
            var anchor1 = htmlDocument.DocumentNode.SelectSingleNode(".//*[@id='xbody']/div[3]/span/i");
            if (anchor1 != null)
            {
                return HelperClass.CleanString(anchor1.InnerText);
            }
            return totalpage;
        }


    }
}
