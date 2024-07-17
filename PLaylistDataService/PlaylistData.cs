using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistModel;

namespace PlaylistDataService
{
    public class PlaylistData
    {
        List<Playlist> playlist;
        SqlDbData sqlData;

        public PlaylistData()
        {
            playlist = new List<Playlist>();
            sqlData = new SqlDbData();
        }

        public List<Playlist> GetPlaylistByGenre(string genre)
        {
            return sqlData.GetPlaylistByGenre(genre);
        }


        public List<Playlist> GetPlaylistSorted(string sortBy)
        {
            return sqlData.GetPlaylistSorted(sortBy);
        }

        public List<Playlist> GetPlaylist()
        {
            playlist = sqlData.GetPlaylist();
            return playlist;
        }

        public int AddPlaylist(Playlist playlist)
        {
            return sqlData.AddPlaylist(playlist.name, playlist.genre, playlist.album, playlist.artists);
        }

        public int UpdatePlaylist(Playlist playlist)
        {
            return sqlData.UpdatePlaylist(playlist.name, playlist.genre);
        }

        public int DeletePlaylist(Playlist playlist)
        {
            return sqlData.DeletePlaylist(playlist.name);
        }

    }
}