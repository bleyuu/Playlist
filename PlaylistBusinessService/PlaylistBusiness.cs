using PlaylistDataService;
using PlaylistModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistBusinessService
{
    public class PlaylistBusiness
    {

        public List<Playlist> GetPlaylistByGenre(string genre)
        {
            PlaylistData playlistData = new PlaylistData();
            return playlistData.GetPlaylistByGenre(genre);
        }
        public List<Playlist> GetPlaylistSorted(string sortBy)
        {
            PlaylistData playlistData = new PlaylistData();
            return playlistData.GetPlaylistSorted(sortBy);
        }

        public List<Playlist> GetAllPlaylist()
        {
            PlaylistData playlistData = new PlaylistData();

            return playlistData.GetPlaylist();

        }


        public Playlist GetPlaylist(string name, string genre, string album, string artists)
        {
            Playlist foundPlaylist = new Playlist();

            foreach (var playlist in GetAllPlaylist())
            {
                if (playlist.name == name && playlist.genre == genre && playlist.album == album && playlist.artists == artists)
                {
                    foundPlaylist = playlist;
                }
            }

            return foundPlaylist;
        }

        public Playlist GetPlaylist(string name)
        {
            Playlist foundPlaylist = new Playlist();

            foreach (var playlist in GetAllPlaylist())
            {
                if (playlist.name == name)
                {
                    foundPlaylist = playlist;
                }
            }

            return foundPlaylist;
        }
    }
}