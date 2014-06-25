using AlbumWebApiProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlbumWebApiProject.Controllers
{
    public class AlbumController : ApiController
    {

        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }

        /// <summary>
        /// Get album details by name. (Return information about Songs in album.)
        /// /api/controller/GetAlbumDetails?albumName="string"
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <returns>A collection of songs.</returns>
        public IEnumerable<Song> GetAlbumDetails(string albumName)
        {
            List<Song> item = _albumRepository.GetAlbumDetails(albumName).ToList();

            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }

        /// <summary>
        /// Add songs to an album.
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="songList"></param>
        /// <returns></returns>
        public HttpResponseMessage PostSongs(string albumName, List<Song> songList)
        {

            Album album = _albumRepository.AddSongs(albumName, songList);
            var response = Request.CreateResponse<Album>(HttpStatusCode.Created, album);
            return response;
        }

        /// <summary>
        /// Update Song info
        /// </summary>
        /// <param name="albumName">The album name.</param>
        /// <param name="song">The song which needs to be updated.</param>
        public HttpResponseMessage PutSong(string albumName, Song song)
        {
            bool status = _albumRepository.UpdateSong(albumName, song);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, status);
            return response;
        }
    }
}
