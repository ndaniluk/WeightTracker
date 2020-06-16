using System;

namespace WeightTracker.Models
{
    public class AuthenticateResponse
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(LoginInfo login, string token)
        {
            Guid = login.Guid;
            Username = login.Username;
            IsAdmin = login.IsAdmin;
            Token = token;
        }
    }
}