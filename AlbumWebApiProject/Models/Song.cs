using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumWebApiProject.Models
{
    public class Song
    {
        public string songId { get; set; }
        public string songTitle { get; set; }
        public string length { get; set; }

        public Song() { }

        public Song(string id, string title, string length)
        {
            this.songId = id;
            this.songTitle = title;
            this.length = length; 
        }
    }
}