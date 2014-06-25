using System.Collections.Generic;

namespace AlbumWebApiProject.Models
{
    public interface IAlbumRepository
    {
        Album GetAlbum(string albumName);
        IEnumerable<Song> GetAlbumDetails(string albumName);
        Album AddSongs(string albumName, IEnumerable<Song> songList);
        bool UpdateSong(string albumName, Song song);
        void RemoveSong(string albumName, int songId);
    }
}
