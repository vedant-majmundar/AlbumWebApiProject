using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AlbumWebApiProject.Models
{
    public class XmlalbumRepository : IAlbumRepository
    {
        private List<Album> allAlbumXmlData = new List<Album>();
        private XDocument albumData;

        /// <summary>
        /// The XML Album Repository.
        /// </summary>
        public XmlalbumRepository()
        {
            albumData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/AlbumAppSample.xml"));

            var albumList = albumData.Descendants("artist").Elements("album").Select(
                   alb => new Album
                   {
                       Id = alb.Attribute("Id").Value,
                       Title = alb.Attribute("title").Value,
                       AlbumSongList = alb.Elements("song").Select(
                           sng => new Song
                           {
                               songId = sng.Attribute("SongId").Value,
                               songTitle = sng.Attribute("title").Value,
                               length = sng.Attribute("length").Value
                           }).ToList()

                   }).ToList();
                

            allAlbumXmlData.AddRange(albumList);

        }

        /// <summary>
        /// Returns the album out of the database.
        /// </summary>
        /// <param name="albumName">The albumName</param>
        /// <returns>Returns the album</returns>
        public Album GetAlbum(string albumName)
        {
            Album album = allAlbumXmlData.Where(alb => alb.Title.Equals(albumName)).FirstOrDefault();
            return album;
        }

        /// <summary>
        /// Retrieve the song list in the album.
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <returns>A list of songs.</returns>
        public IEnumerable<Song> GetAlbumDetails(string albumName)
        {
            Album album = null;

            if (!string.IsNullOrWhiteSpace(albumName.Trim()))
                      album = GetAlbum(albumName);                
            
            return (album == null ? null :  album.GetAlbumSongList());
        }

        /// <summary>
        /// A method searches an album by name and inserts songs in the album. 
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <param name="songList">A collection of song list.</param>
        /// <returns>The new album after adding new songs.</returns>
        public Album AddSongs(string albumName, IEnumerable<Song> songList)
        {
            Album album = GetAlbum(albumName);

            List<Song> tempSongList = album.GetAlbumSongList();
            tempSongList.AddRange(songList);
            // TODO Write new songs to the XML
            albumData.Save(HttpContext.Current.Server.MapPath("~/App_Data/AlbumAppSample.xml"));
            return album;
        }

        /// <summary>
        /// It removes the song from the list and the xml file
        /// </summary>
        /// <param name="albumName">The album name</param>
        /// <param name="songId">The song Id</param>
        public void RemoveSong(string albumName, int songId)
        {
            // TODO Remove Song from the allAlbumXmlData
            // TODO remove and delete from the XML file.

        }

        /// <summary>
        /// It updates the song.
        /// </summary>
        /// <param name="albumName">The album name</param>
        /// <param name="song">The song</param>
        /// <returns>Returns true or false based on success or failure</returns>
        public bool UpdateSong(string albumName, Song song)
        {
            // TODO Retrieve the song from album and songlist
            // Update the song for the Album List and
            // Also update and write to XML file
            return true;
        }
    }
}