using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistModel;
using System.Data.SqlClient;
//Final
namespace PlaylistDataService

{
    public class SqlDbData
    {
        string connectionString
            = "Server = tcp:52.139.168.198,1433; Database = MusicPlaylist; User Id = sa; Password = LiamPogi123!";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Playlist> GetPlaylistByGenre(string genre)
        {
            string selectStatement = "SELECT name, genre, album, artists FROM playlist WHERE genre = @genre";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@genre", genre);

            sqlConnection.Open();
            List<Playlist> playlists = new List<Playlist>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string playlistGenre = reader["genre"].ToString();
                string album = reader["album"].ToString();
                string artists = reader["artists"].ToString();

                Playlist playlist = new Playlist
                {
                    name = name,
                    genre = playlistGenre,
                    album = album,
                    artists = artists
                };

                playlists.Add(playlist);
            }

            sqlConnection.Close();
            return playlists;
        }

        public List<Playlist> GetPlaylistSorted(string sortBy)
        {
            string selectStatement = $"SELECT name, genre, album, artists FROM playlists ORDER BY {sortBy}";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Playlist> playlists = new List<Playlist>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string playlistGenre = reader["genre"].ToString();
                string album = reader["album"].ToString();
                string artists = reader["artists"].ToString();

                Playlist playlist = new Playlist
                {
                    name = name,
                    genre = playlistGenre,
                    album = album,
                    artists = artists
                };

                playlists.Add(playlist);
            }

            sqlConnection.Close();
            return playlists;
        }

        public List<Playlist> GetPlaylist()
        {
            string selectStatement = "SELECT name, genre, album, artists FROM playlist";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Playlist> playlist = new List<Playlist>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string genre = reader["genre"].ToString();
                string album = reader["album"].ToString();
                string artists = reader["artists"].ToString();

                Playlist readPlaylist = new Playlist();
                readPlaylist.name = name;
                readPlaylist.genre = genre;
                readPlaylist.album = album;
                readPlaylist.artists = artists;

                playlist.Add(readPlaylist);
            }

            sqlConnection.Close();

            return playlist;
        }

        public int AddPlaylist(string name, string genre, string album, string artists)
        {
            int success;

            string insertStatement = "INSERT INTO playlist VALUES (@name, @genre, @album, @artists)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@genre", genre);
            insertCommand.Parameters.AddWithValue("@album", album);
            insertCommand.Parameters.AddWithValue("@artists", artists);

            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdatePlaylist(string name, string genre)
        {
            int success;

            string updateStatement = $"UPDATE playlist SET genre = @Genre WHERE name = @name";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Genre", genre);
            updateCommand.Parameters.AddWithValue("@name", name);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeletePlaylist(string name)
        {
            int success;

            string deleteStatement = $"DELETE FROM playlist WHERE name = @name";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@name", name);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}