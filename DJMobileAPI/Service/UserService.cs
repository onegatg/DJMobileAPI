using DJMobileAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJMobileAPI.Service
{
    public class UserService
    {
        private UserRepository _userRepository = new UserRepository();

        public UserService()
        {
        }
        public string GetAuthToken(string code)
        {
            var authToken = _userRepository.GetAuthToken(code);
            return authToken;
        }
    }
}