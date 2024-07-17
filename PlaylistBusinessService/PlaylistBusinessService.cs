using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistBusinessService
{
    public class PlaylistValidationServices
    {
        PlaylistBusiness getServices = new PlaylistBusiness();

        public bool CheckIfPlaylistNameExists(string name)
        {
            bool result = getServices.GetPlaylist(name) != null;
            return result;
        }

        public bool CheckIfPlaylistNameExists(string name, string genre, string album, string artists)
        {
            bool result = getServices.GetPlaylist(name, genre, album, artists) != null;
            return result;
        }
    }
}