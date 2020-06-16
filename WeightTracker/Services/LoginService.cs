using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeightTracker.Helpers;
using WeightTracker.Models;

namespace WeightTracker.Services
{
        public interface ILoginService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<LoginInfo> GetAll();
    }

    public class LoginService : ILoginService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<LoginInfo> _logins = new List<LoginInfo>
        { 
            new LoginInfo { Guid = Guid.Parse("a22c0829-22f5-435e-943b-baf1a643893a"), Username = "test", Password = "test" } 
        };

        private readonly AppSettings _appSettings;

        public LoginService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var login = _logins.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (login == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(login);

            return new AuthenticateResponse(login, token);
        }

        public IEnumerable<LoginInfo> GetAll()
        {
            return _logins;
        }

        // helper methods

        private string GenerateJwtToken(LoginInfo login)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, login.Guid.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}