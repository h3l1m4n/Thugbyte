//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using HtmlAgilityPack;

//namespace WindowsFormsApplication1
//{
//    internal class Search
//    {
//        private List<song> _searchResults;

//        public delegate void LabelCurrentStatus(string status);

//        public event LabelCurrentStatus SetLabel;

//        public Search()
//        {
//            _searchResults = new List<song>();
//        }

//        //private int GetAllPage(int startpage, string searchSong)
//        //{
//        //    while (true)
//        //    {

//        //        var htmlWeb = new HtmlWeb();
//        //        var htmlDocument = htmlWeb.Load("http://www.myfreemp3.pro/mp3/" + searchSong + "?page=" + startpage);
//        //        var dinks = htmlDocument.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("href"));

//        //       // SetLabel("Status: Getting Pages :1");
//        //        var maxpage = startpage;

//        //        foreach (var dink in dinks)
//        //        {
//        //            if (dink.Attributes["href"].Value.Contains("?page="))
//        //            {
//        //                maxpage = HelperClass.CleanString(dink.Attributes["href"].Value);
//        //            }
//        //        }

//        //        if (maxpage == startpage)
//        //        {

//        //            return maxpage;
//        //        }


//        //        startpage = maxpage;
//        //    }
//        //}



//        public List<song> FirstSearch(string searchSong, int index)
//        {

//          //  _searchResults.Clear();

//          ////  SetLabel("Status: Start Searching :1");
//          //  var totalpages = GetAllPage(1, searchSong);


//          //  for (var pages = 1; pages <= totalpages; pages++)
//          //  {
//          //      var htmlWeb = new HtmlWeb();
//          //      var htmlDocument = htmlWeb.Load("http://www.myfreemp3.pro/mp3/" + searchSong + "?page=" + pages);

//          //      var links = htmlDocument.DocumentNode.Descendants("a").Where(x => x.Attributes.Contains("data-aid"));

//          //      foreach (var link in links)
//          //      {
//          //          var href = link.Attributes["data-aid"].Value;
//          //          var time = link.Attributes["data-duration"].Value;
//          //          var name = link.InnerText;
//          //          var s = name.Split('-');

//          //          s[1] = s[1].Replace(" mp3", "");
//          //          s[0] = s[0].Trim();
//          //          s[1] = s[1].Trim();
//          //          if (index == 0)
//          //          {
//          //              _searchResults.Add(new song("http://s.myfreemp3.space/stream.php?q=" + href + "/", s[0], false,
//          //                  time,
//          //                  s[1]));
//          //          }
//          //          if (index == 1)
//          //          {
//          //              if (string.Equals(s[0], searchSong, StringComparison.CurrentCultureIgnoreCase))
//          //              {
//          //                  _searchResults.Add(new song("http://s.myfreemp3.space/stream.php?q=" + href + "/", s[0],
//          //                      false,
//          //                      time,
//          //                      s[1]));
//          //              }
//          //          }
//          //          if (index == 2)
//          //          {
//          //              if (string.Equals(s[1], searchSong, StringComparison.CurrentCultureIgnoreCase))
//          //              {
//          //                  _searchResults.Add(new song("http://s.myfreemp3.space/stream.php?q=" + href + "/", s[0],
//          //                      false,
//          //                      time,
//          //                      s[1]));
//          //              }
//          //          }
//          //      }
//          //  }
//          //  //SetLabel("Status: Done!");
//          //  return _searchResults;
//        }

//        public List<song> SearchSecond(string searchSong, int index)
//        {
//            _searchResults.Clear();
//            SetLabel("Status: Start Searching :2");
//            for (var pages = 1; pages <= GetAllPageSecond(searchSong); pages++)
//            {
//                var htmlWeb = new HtmlWeb();
//                var htmlDocument = htmlWeb.Load(@"http://mp3pm.ws/s/f/" + searchSong + "/page/" + pages);


//                if (htmlDocument == null) continue;
//                htmlDocument.DocumentNode.SelectNodes(".//tbody");
//                var res = htmlDocument.DocumentNode.SelectNodes(".//*[@id='xbody']")
//                    .Select(row => row.Descendants("li")
//                        .Select(td => td.OuterHtml).ToList())
//                    .ToList();

//                var flattened = res.SelectMany(x => x).ToArray();
//                for (var k = 1; k <= flattened.Length - 1; k++)
//                {
//                    ConvertToSong(flattened[k], index, searchSong);
//                }
//            }
//            SetLabel("Status: Done!");
//            return _searchResults;
//        }

//        private void ConvertToSong(string song, int index, string searchSong)
//        {
//            try
//            {
//                string[] s = {"Artist", "Titel"};
//                SetLabel("Status: Cleaning stuff");
//                var href = "";
//                var name = "test";
//                //get song name
//                var namedoc = new HtmlDocument();
//                namedoc.LoadHtml(song);

//                var anchor1 = namedoc.DocumentNode.SelectSingleNode("//h4");
//                if (anchor1 != null)
//                {
//                    name = anchor1.InnerText.Trim();
//                }
//                if (name.Contains("\n\t\t\t"))
//                {
//                    s = name.Split(new[] {"\n\t\t\t"},
//                        StringSplitOptions.None);

//                    Debug.WriteLine(s[1]);
//                    s[0] = s[0].Trim();
//                    if (s[1].Length <= 0)
//                    {
//                        s[1] = "No Info";
//                    }
//                    else
//                    {
//                        s[1] = s[1].Trim();
//                    }
//                }

//                var time = "";
//                var timedoc = new HtmlDocument();
//                timedoc.LoadHtml(song);

//                var anchor2 = timedoc.DocumentNode.SelectSingleNode("//em");
//                if (anchor2 != null)
//                {
//                    time = anchor2.InnerText;
//                }
//                time = HelperClass.String2Sek(time).ToString();
//                ////get url
//                var doc = new HtmlDocument();
//                doc.LoadHtml(song);

//                var anchor = doc.DocumentNode.SelectSingleNode("//li");
//                if (anchor != null)
//                {
//                    href = anchor.Attributes["data-download-url"].Value;
//                }


//                if (index == 0)
//                {
//                    _searchResults.Add(new song(href, s[0], false, time,
//                        s[1]));
//                }
//                if (index == 1)
//                {
//                    if (string.Equals(s[0], searchSong, StringComparison.CurrentCultureIgnoreCase))
//                    {
//                        _searchResults.Add(new song(href, s[0], false, time,
//                            s[1]));
//                    }
//                }
//                if (index == 2)
//                {
//                    if (string.Equals(s[1], searchSong, StringComparison.CurrentCultureIgnoreCase))
//                    {
//                        _searchResults.Add(new song(href, s[0], false, time,
//                            s[1]));
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        private int GetAllPageSecond(string searchSong)
//        {
//            var totalpage = 1;
//            var htmlWeb = new HtmlWeb();
//            var htmlDocument = htmlWeb.Load("http://mp3pm.ws/s/f/" + searchSong);
//            SetLabel("Status: Getting Pages :2");
//            var anchor1 = htmlDocument.DocumentNode.SelectSingleNode(".//*[@id='xbody']/div[3]/span/i");
//            if (anchor1 != null)
//            {
//                return HelperClass.CleanString(anchor1.InnerText);
//            }
//            return totalpage;
//        }



       
//    }
//}
