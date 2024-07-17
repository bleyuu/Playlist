using PlaylistBusinessService;
using PlaylistDataService;
using PlaylistModel;

namespace Client
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Music Playlist");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display Playlist");
                Console.WriteLine("2. Search for Music (by genre)");
                Console.WriteLine("3. Sort Playlist");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nPlaylist:");
                        DisplayPlaylist();
                        Console.WriteLine("---------------------------");
                        break;
                    case "2":
                        Console.Write("\nEnter the genre of music to search: ");
                        string genre = Console.ReadLine();
                        Console.WriteLine($"\nUniversities of type {genre}:");
                        SearchPlaylistByGenre(genre);
                        Console.WriteLine("---------------------------");
                        break;
                    case "3":
                        Console.Write("\nEnter the criteria to sort playlist by (name, genre, album): ");
                        string sortBy = Console.ReadLine();
                        if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase) || sortBy.Equals("genre", StringComparison.OrdinalIgnoreCase) || sortBy.Equals("album", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"\nPlaylist sorted by {sortBy}:");
                            SortPlaylist(sortBy);
                            Console.WriteLine("---------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid criteria. Please enter 'name', 'genre', or 'album'.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("\nExiting program...");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
        }
        static void DisplayPlaylist()
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetAllPlaylist();

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artist: {playlist.artists}");

            }
        }

        static void SearchPlaylistByGenre(string genre)
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetPlaylistByGenre(genre);

            if (playlists.Count == 0)
            {
                Console.WriteLine($"No playlist found with genre {genre}.");
                return;
            }

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artists: {playlist.artists}");

            }
        }

        static void SortPlaylist(string sortBy)
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetPlaylistSorted(sortBy);

            if (playlists.Count == 0)
            {
                Console.WriteLine($"No playlist found to sort by {sortBy}.");
                return;
            }

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artists: {playlist.artists}");

            }

        }
    }
}
