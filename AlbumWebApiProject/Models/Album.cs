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

        ///// <summary>
        ///// Add new songs to the songList.
        ///// </summary>
        ///// <param name="songList"></param>
        ///// <returns></returns>
        //public List<Song> AddSong(List<Song> songList)
        //{
        //    //this.SongList.Add(new Song()
        //    //{
        //    //    songTitle = songName,
        //    //    length = songLength
        //    //});

        //    return songList;
        //}

        ///// <summary>
        ///// Update songs to the songList.
        ///// </summary>
        ///// <param name="songList"></param>
        ///// <returns></returns>
        //public List<Song> UpdateSong(List<Song> songList)
        //{
        //    //this.SongList.Add(new Song()
        //    //{
        //    //    songTitle = songName,
        //    //    length = songLength
        //    //});

        //    return songList;
        //}

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