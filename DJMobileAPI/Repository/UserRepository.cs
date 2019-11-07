using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace DJMobileAPI.Repository
{
    public class UserRepository
    {
        public UserRepository() { }

        public string GetAuthToken(string code)
        {
            dynamic jsonObject;
            string authToken = "";
            string redirectUri = "http://localhost:8888/callback";
            string  grantType = "authorization_code";
            var authorizationBytes = System.Text.Encoding.UTF8.GetBytes("47a5c9cece574b54bd77ab03ddc871a8:2bf2b897723844f5a1e2c1c094f10e49");
            var authorization = System.Convert.ToBase64String(authorizationBytes);
            string searchUrl = "https://accounts.spotify.com/api/token";
            try
            {
                var webRequest = WebRequest.Create(searchUrl);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    string poststring = String.Format("code={0}&redirect_uri={1}&grant_type={2}", code, redirectUri, grantType);

                    byte[] bytedata = System.Text.Encoding.UTF8.GetBytes(poststring);
                    webRequest.ContentLength = bytedata.Length;

                    webRequest.Headers.Add("Authorization", "Basic " + authorization);

                    Stream requestStream = webRequest.GetRequestStream();
                    requestStream.Write(bytedata, 0, bytedata.Length);
                    requestStream.Close();
                    // Get the response from remote server
                    HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            jsonObject = JObject.Parse(jsonResponse);
                            authToken = jsonObject.access_token;
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                            Console.WriteLine(String.Format(authToken));
                        }
                    }
                }
                    return authToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return authToken;
            }
        }
    }
}