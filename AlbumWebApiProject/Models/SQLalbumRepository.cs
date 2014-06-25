using System.Collections.Generic;

namespace AlbumWebApiProject.Models
{
    public class SqlAlbumRepository : IAlbumRepository
    {
        private List<Album> albums = new List<Album>();
        private int _nextId = 1;

        /// <summary>
        /// The Sql Album Repository.
        /// </summary>
        public SqlAlbumRepository()
        {
        }

        /// <summary>
        /// Returns the album out of the database.
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public Album GetAlbum(string albumName)
        {
            // TODO - Implement Sql Album retrieval and return Album
            return null;
        }

        /// <summary>
        /// Retrieve the song list in the album.
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <returns>A list of songs.</returns>
        public IEnumerable<Song> GetAlbumDetails(string albumName)
        {
            Album album = GetAlbum(albumName);
            return album.GetAlbumSongList();
        }

        /// <summary>
        /// A method searches an album by name and insets songs in the album. 
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <param name="songList">A collection of song list.</param>
        /// <returns>The new album after adding new songs.</returns>
        public Album AddSongs(string albumName, IEnumerable<Song> songList)
        {
            // TODO -  WORK IN PROGRESS 
            Album album = GetAlbum(albumName);
            return album;
        }

        public void RemoveSong(string albumName, int songId)
        {
            // TODO -  WORK IN PROGRESS 
        }

        public bool UpdateSong(string albumName, Song song)
        {
            // TODO -  WORK IN PROGRESS 
            return true;
        }
    }
}