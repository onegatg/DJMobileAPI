using DJMobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DJMobileAPI.Repository
{
    public class SongRepository
    {
        public SongRepository() { }

        public List<TrackDTO> GetSongs(string searchText)
        {
            string searchUrl = "https://api.spotify.com/v1/search?q=" + searchText + "&type=artist";
            List<TrackDTO> trackList = new List<TrackDTO>();
            try { 
            var webRequest = WebRequest.Create(searchUrl);
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", "Bearer BQD5Q2FBJUmMuLuzxvuC5JY34O2FPsQCMvLcGkNcvCGzDCcVlgAJe9jhCHArKKnNeI1st6S2YZOuIuBmBrNR3rpOo3nMq2EB--cGZa1-UdrjGSPi9MHh4i_GW7psAWK2ytcqkYncbC9pQnhttdvbzJ_P3PPyPLzt4qChzmhx59ift9Zc_-HdOFp7TfuJ4Y1_ujIvGXStsTG5P0Xq");

                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                    }
                }
            }
                return trackList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return trackList;
            }
}
    }
}