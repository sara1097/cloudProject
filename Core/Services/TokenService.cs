﻿using Core.Interfaces;
using Domin.DTOs;
using Domin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly Jwt _jwt;

        public TokenService(IOptions<Jwt> jwt, UserManager<User> userManager)
        {
            _jwt = jwt.Value;
        }

        public string GenerateJwtToken(User user)
        {
         

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            
         
            claims.Add(new Claim(ClaimTypes.Role, "User"));
          

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddMinutes(_jwt.ExpiryDurationInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool StoreTokenAsync(User user, string token)
        {
            // Implementation to store the token if needed
            return true;
        }
    }
}
