using Microsoft.AspNetCore.Mvc;
using PlaylistBusinessService;
using PlaylistModel;
using System.Reflection;
using System.Xml.Linq;

namespace MusicPlaylist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicPlaylistController : Controller
    {
        PlaylistBusiness _playlistBusiness;
        PlaylistTransactionServices _transactionServices;

        public MusicPlaylistController()
        {
            _playlistBusiness = new PlaylistBusiness();
            _transactionServices = new PlaylistTransactionServices();
        }

        [HttpGet]
        public IEnumerable<MusicPlaylist.API.Playlist> GetPlaylist()
        {
            var activemusic = _playlistBusiness.GetAllPlaylist();

            List<MusicPlaylist.API.Playlist> music = new List<Playlist>();

            foreach (var item in activemusic)
            {
                music.Add(new API.Playlist { name = item.name, genre = item.genre, album = item.album, artists = item.artists });
            }

            return music;
        }

        [HttpPost]
        public JsonResult AddPlaylist(Playlist request)
        {
            var result = _transactionServices.CreatePlaylist(request.name, request.genre, request.album, request.artists);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdatePlaylist(Playlist request)
        {
            var result = _transactionServices.UpdatePlaylist(request.name, request.genre);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeletePLaylist(Playlist request)
        {
            var result = _transactionServices.DeletePlaylist(new PlaylistModel.Playlist
            {
                name = request.name,
                genre = request.genre,
                album = request.album,
                artists = request.artists
            });

            return new JsonResult(result);
        }



    }
}