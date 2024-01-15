using System.Runtime.CompilerServices;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Parts.API.Domain.Models;

namespace Shop.API.Extensions
{
    public static class ClientExtensions
    {
        public static void GenerateToken(this Client client, Role role, string secret, int expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(ClaimTypes.NameIdentifier, client.Login)     
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(token);
            client.Password = null;
        }
    }
}