using BoilerplateCleanArch.API.DTO.Token;
using BoilerplateCleanArch.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.API.Controllers.Token
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] RegisterDTO registerDTO)
        {
            var result = await _authentication.RegisterUser(registerDTO.Email, registerDTO.Password);

            if (result)
                return Ok($"User {registerDTO.Email}, was create sucessfully");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _authentication.Authenticate(loginDTO.Email, loginDTO.Password);

            if (result)
                return GenerateToken(loginDTO);
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        private ActionResult<UserTokenDTO> GenerateToken(LoginDTO loginDTO)
        {
            var claims = new[]
            {
                new Claim("email", loginDTO.Email),
                new Claim("valor", "qualquer coisa"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(30);

            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims, expires: expiration, signingCredentials: credentials);

            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }
    }
}
