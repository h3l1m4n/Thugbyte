using System;
using System.Collections.Generic;
using System.Diagnostics;
using HtmlAgilityPack;
using static WindowsFormsApplication1.HelperClass;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1.Searches
{
    internal class Pleer : ISearch
    {
        public delegate void LabelCurrentStatus(string status);

        private readonly bool isRemote;
        public List<song> SearchResults;

        public Pleer()
        {
            isRemote = false;
            SearchResults = new List<song>();
        }

        public Pleer(bool isRemote)
        {
            this.isRemote = isRemote;
            SearchResults = new List<song>();
        }

        public List<song> SearchAsync(string searchSong, int index, int russian)
        {
            if (!isRemote)
                SetLabel("Status: Getting Number of Pages");
            var nbrofpages = GetNumberOfPages("http://pleer.net/search?page=1" + "&q=" + searchSong);
            for (var pages = 1; pages <= nbrofpages; pages++)
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load("http://pleer.net/search?page=" + pages + "&q=" + searchSong);
                if (!isRemote)
                    SetLabel("Status: Adding songs");
                try
                {
                    foreach (
                        var li in
                        htmlDocument.DocumentNode.SelectNodes(
                            "/html/body/div[2]/div[3]/div[2]/div/div[3]/div[1]/div/div/ol//li"))
                    {
                        bool ruski = false;
                        var artist = li.Attributes["singer"].Value;
                        var songname = li.Attributes["song"].Value;
                        var fullsong = artist + " - " + songname;
                        switch (russian)
                        {
                            case 0:
                                break;

                            case 1:
                                ruski = HelperClass.ContainRussian(artist);
                             
                                break;
                            case 2:
                                ruski = HelperClass.ContainRussian(songname);
                                
                                break;
                            case 3:

                                ruski = HelperClass.ContainRussian(fullsong);
                                break;

                        }
                        Debug.WriteLine("Russian: " + ruski.ToString());
                     if(ruski == false)
                        { 
                        switch (index)
                        {
                            case 0:
                                SearchResults.Add(new song(artist, li.Attributes["link"].Value,
                                    li.Attributes["duration"].Value, songname));
                                break;
                            case 1:
                                if (artist == searchSong)
                                    SearchResults.Add(new song(artist, li.Attributes["link"].Value,
                                        li.Attributes["duration"].Value, songname));
                                break;
                            case 2:
                                if (songname == searchSong)
                                    SearchResults.Add(new song(artist, li.Attributes["link"].Value,
                                        li.Attributes["duration"].Value, songname));
                                break;
                        }
                        }
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine("Could not find anymore");
                }
            }
            if (!isRemote)
                SetLabel("Status: Done");
            return SearchResults;
        }

        public event LabelCurrentStatus SetLabel;


        private int GetNumberOfPages(string url)
        {
            var totalpage = 1;
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);

            var anchor1 =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "/html/body/div[2]/div[3]/div[2]/div/div[3]/div[1]/div/ul/li[1]/a");
            if (anchor1 != null)
            {
                Debug.WriteLine(CleanString(anchor1.InnerHtml));
                var totalsongs = (double) CleanString(anchor1.InnerHtml)/20;
                var wholeNumber = (int) Math.Ceiling(totalsongs);
                return wholeNumber;
            }

            return totalpage;
        }
    }
}