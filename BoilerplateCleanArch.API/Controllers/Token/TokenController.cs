using BoilerplateCleanArch.API.DTO.Token;
using BoilerplateCleanArch.Application.Interfaces.ITokenService;
using BoilerplateCleanArch.Application.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.API.Controllers.Token
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(IConfiguration configuration, IUserService userService, ITokenService tokenService)
        {
            _configuration = configuration;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] RegisterDTO registerDTO)
        {
            //var result = await _authentication.RegisterUser(registerDTO.Email, registerDTO.Password);

            //if (result)
            //    return Ok($"User {registerDTO.Email}, was create sucessfully");
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
            //    return BadRequest(ModelState);
            //}

            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginDTO loginDTO)
        {
            //var result = await _authentication.Authenticate(loginDTO.Email, loginDTO.Password);

            //Criar autenticação após isso gerar token e atualizar no banco com token novo

            if (loginDTO != null)
            {
                var users = await _userService.GetUsers();
                var user = users.FirstOrDefault(x => x.Email == loginDTO.Email);

                var token = _tokenService.GenerateJWT(user);

                return Ok(token.AccessToken);

            }
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
