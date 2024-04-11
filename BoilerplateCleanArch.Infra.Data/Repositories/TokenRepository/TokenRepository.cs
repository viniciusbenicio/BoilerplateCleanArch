﻿using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IUserRepository.ITokenRepository;
using BoilerplateCleanArch.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BoilerplateCleanArch.Infra.Data.Repositories.TokenRepository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _userContext;
        private readonly IConfiguration _configuration;

        public TokenRepository(ApplicationDbContext userContext, IConfiguration configuration)
        {
            _userContext = userContext;
            _configuration = configuration;
        }
        public User GenerateJWT(User user)
        {
            var claims = new[]
             {
                new Claim("email", user.Email),
                new Claim("valor", "qualquer coisa"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(30);

            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims, expires: expiration, signingCredentials: credentials);

            return new User(user.FirstName)
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
