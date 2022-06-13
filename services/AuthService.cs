using BCrypt.Net;
using Countify.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Countify.services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;

        public AuthService(IConfiguration config)
        {
            this.config = config;
        }

        public string Hash(string s)
        {
            return BCrypt.Net.BCrypt.HashPassword(s);
        }

        public string login(User user)
        {
            //passing data to JWT
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            //defining the secret for token generation
            var secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("AppSettings:secret").Value));

            //signing the token
            var cred = new SigningCredentials(secret, SecurityAlgorithms.HmacSha512Signature);

            //creating the token
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
