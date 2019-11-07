using DJMobileAPI.Service;
using DJMobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DJMobileAPI.Controllers
{
    public class DJController : ApiController
    {
        private SongService _songService = new SongService();
        private UserService _userService = new UserService();

        public DJController()
        {
        }

        // GET api/dj?searchText=
        [HttpGet]
        public List<TrackDTO> GetSongs(string searchText)
        {
            var songs = _songService.GetSongs(searchText);
            return songs;
        }

        // GET api/dj/callback?code=
        [HttpGet]
        [Route("api/dj/callback")]
        public string LoginUser(string code)
        {
            var authToken = _userService.GetAuthToken(code);
            return authToken;
        }

        // POST api/dj/queue
        [HttpPost]
        [Route("api/dj/queue")]
        public void PostQueue(List<string> addedSongs)
        {

        }

        // POST api/dj/addFilters
        [HttpPost]
        [Route("api/dj/queue")]
        public void AddFilters(List<string> addedFilters)
        {

        }

        // POST api/dj/removeFilters
        public void RemoveFilters(List<string> removedFilters)
        {

        }
    }
}
