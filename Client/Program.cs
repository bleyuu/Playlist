using PlaylistBusinessService;
using PlaylistDataService;
using PlaylistModel;
using System.Net;
using System.Net.Mail;


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

        static void SendEmail(string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.mailtrap.io")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("e2a7b3b6444a55", "dfa18920f8bc11"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("Saguntify@email.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add("danieljosesagun@gmail.com");

                smtpClient.Send(mailMessage);
                Console.WriteLine("\nEmail sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        static void DisplayPlaylist()
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetAllPlaylist();

            string emailBody = "Playlist details:\n";

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artist: {playlist.artists}");

                emailBody += $"\nName: {playlist.name}\n";
                emailBody += $"    - Genre: {playlist.genre}\n";
                emailBody += $"    - Album: {playlist.album}\n";
                emailBody += $"    - Artist: {playlist.artists}\n";
            }

            SendEmail("Playlist Displayed", emailBody);
        }


        static void SearchPlaylistByGenre(string genre)
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetPlaylistByGenre(genre);

            string emailBody = $"Search results for genre {genre}:\n";

            if (playlists.Count == 0)
            {
                Console.WriteLine($"No playlist found with genre {genre}.");
                emailBody += "No results found.";
                SendEmail("Search Results", emailBody);
                return;
            }

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artists: {playlist.artists}");

                emailBody += $"\nName: {playlist.name}\n";
                emailBody += $"    - Genre: {playlist.genre}\n";
                emailBody += $"    - Album: {playlist.album}\n";
                emailBody += $"    - Artists: {playlist.artists}\n";
            }

            SendEmail("Search Results", emailBody);
        }


        static void SortPlaylist(string sortBy)
        {
            PlaylistBusiness playlistService = new PlaylistBusiness();
            var playlists = playlistService.GetPlaylistSorted(sortBy);

            string emailBody = $"Playlist sorted by {sortBy}:\n";

            if (playlists.Count == 0)
            {
                Console.WriteLine($"No playlist found to sort by {sortBy}.");
                emailBody += "No results found.";
                SendEmail("Sort Results", emailBody);
                return;
            }

            foreach (var playlist in playlists)
            {
                Console.WriteLine($"\nName: {playlist.name}");
                Console.WriteLine($"    - Genre: {playlist.genre}");
                Console.WriteLine($"    - Album: {playlist.album}");
                Console.WriteLine($"    - Artists: {playlist.artists}");

                // Append each playlist entry to the email body
                emailBody += $"\nName: {playlist.name}\n";
                emailBody += $"    - Genre: {playlist.genre}\n";
                emailBody += $"    - Album: {playlist.album}\n";
                emailBody += $"    - Artists: {playlist.artists}\n";
            }

            // Send email after sorting the playlist
            SendEmail($"Playlist Sorted by {sortBy}", emailBody);
        }

    }
}