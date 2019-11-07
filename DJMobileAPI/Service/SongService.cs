using DJMobileAPI.Models;
using DJMobileAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJMobileAPI.Service
{
    public class SongService
    {
        private SongRepository _songRepository = new SongRepository();

        public SongService()
        {
        }

        public List<TrackDTO> GetSongs(string searchText)
        {

            var songs = _songRepository.GetSongs(searchText);
            return songs;
        }
    }
}