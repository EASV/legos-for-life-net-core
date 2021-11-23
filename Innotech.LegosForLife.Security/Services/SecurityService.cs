using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using InnoTech.LegosForLife.Security.IServices;
using InnoTech.LegosForLife.Security.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InnoTech.LegosForLife.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IAuthUserService _authUserService;

        public SecurityService(
            IConfiguration configuration,
            IAuthUserService authUserService)
        {
            _authUserService = authUserService;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var user = _authUserService.GetUser(username);
            //Validate User - Generate
            if (Authenticate(password, user))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    null,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);
                return new JwtToken
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Ok"
                };
            }

            return new JwtToken
            {
                Message = "User or Password not correct"
            };
        }

        private bool Authenticate(string plainTextPassword, AuthUser user)
        {
            if (user == null || user.HashedPassword.Length <= 0 || user.Salt.Length <= 0) 
                return false;

            var hashedPasswordFromPlain = HashedPassword(plainTextPassword, user.Salt);
            return user.HashedPassword.Equals(hashedPasswordFromPlain);
        }

        public string HashedPassword(string plainTextPassword, byte[] userSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainTextPassword,
                salt: userSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}