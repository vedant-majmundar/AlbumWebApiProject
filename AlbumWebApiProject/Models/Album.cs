using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumWebApiProject.Models
{
    public class Album
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Song> AlbumSongList { get; set; }

        /// <summary>
        /// Constructor to build the album
        /// </summary>
        public Album(string Id, string Title, List<Song> AlbumSongList)
        {
            this.AlbumSongList = AlbumSongList;
            this.Id = Id;
            this.Title = Title;
            this.AlbumSongList = AlbumSongList;
        }

        public Album() { }

        
        /// <summary>
        /// Retrieve the song list in the album.
        /// </summary>
        /// <returns></returns>
        public List<Song> GetAlbumSongList()
        {
            return AlbumSongList;
        }

    }
}
