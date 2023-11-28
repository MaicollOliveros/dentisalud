using Entidades;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Denti_Salud.Config;
using Denti_Salud.Models;

namespace Denti_Salud.Service
{
    public class JwtService
    {

        private readonly AppSetting _appSettings;

        public JwtService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public LoginViewModel GenerateToken(User user)
        {
            // return null if user not found
            if (user == null)
                return null;

            var userResponse = new LoginViewModel() { 
                Name = user.Name, 
                UserName = user.UserName,
                Email = user.Email,
                MobilePhone = user.MobilePhone,
                Role = user.Role,

            };

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    //new Claim(ClaimTypes.MobilePhone, user.MobilePhone.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);

            return userResponse;
        }
    }
}
