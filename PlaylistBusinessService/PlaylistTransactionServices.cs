using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistDataService;
using PlaylistModel;

namespace PlaylistBusinessService
{
    public class PlaylistTransactionServices
    {
        PlaylistValidationServices validationServices = new PlaylistValidationServices();
        PlaylistData playlistData = new PlaylistData();

        public bool CreatePlaylist(Playlist playlist)
        {
            bool result = false;

            if (validationServices.CheckIfPlaylistNameExists(playlist.name))
            {
                result = playlistData.AddPlaylist(playlist) > 0;
            }

            return result;
        }

        public bool CreatePlaylist(string name, string genre, string album, string artists)
        {
            Playlist playlist = new Playlist { name = name, genre = genre, album = album, artists = artists };

            return CreatePlaylist(playlist);
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            bool result = false;

            if (validationServices.CheckIfPlaylistNameExists(playlist.name))
            {
                result = playlistData.UpdatePlaylist(playlist) > 0;
            }

            return result;
        }

        public bool UpdatePlaylist(string name, string genre)
        {
            Playlist playlist = new Playlist { name = name, genre = genre };

            return UpdatePlaylist(playlist);
        }

        public bool DeletePlaylist(Playlist playlist)
        {
            bool result = false;

            if (validationServices.CheckIfPlaylistNameExists(playlist.name))
            {
                result = playlistData.DeletePlaylist(playlist) > 0;
            }

            return result;
        }
    }
}