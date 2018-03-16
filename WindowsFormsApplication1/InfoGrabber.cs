using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public class Streamable
    {
        [JsonProperty("#text")]
        public string Text { get; set; }

        public string fulltrack { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
    }

    public class Image
    {
        [JsonProperty("#text")]
        public string imageurl { get; set; }

        public string size { get; set; }
    }

    public class Attr
    {
        public string position { get; set; }
    }

    public class Album
    {
        public string artist { get; set; }
        public string title { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public List<Image> image { get; set; }

        [DataMember(Name = "@attri")]
        public Attr Attri { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Toptags
    {
        public List<Tag> tag { get; set; }
    }

    public class Track
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public string duration { get; set; }
        public Streamable streamable { get; set; }
        public string listeners { get; set; }
        public string playcount { get; set; }
        public Artist artist { get; set; }
        public Album album { get; set; }
        public Toptags toptags { get; set; }
    }

    public class LastFMInfo
    {
        public Track track { get; set; }
    }
}