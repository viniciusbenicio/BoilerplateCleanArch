using BoilerplateCleanArch.API.DTO.Token;
using BoilerplateCleanArch.Application.Interfaces.ITokenService;
using BoilerplateCleanArch.Application.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.API.Controllers.Token
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(IUserService userService, ITokenService tokenService)
        {
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
            if (loginDTO is not null)
            {
                var users = await _userService.GetUsers();
                var user = users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
                var token = _tokenService.GenerateJWT(user);
                return Ok(token.AccessToken);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LogoutUser")]
        public async Task<IActionResult> Logout([FromBody] UserLogoutDTO userLogoutDTO)
        {
            ClaimsPrincipal user = HttpContext.User;

            if (user is not null)
            {
                var logoutUser = await _userService.GetUserByAccessToken(userLogoutDTO.AccessToken);
                //await _userService.DeleteTokens(logoutUser.Id);

                return Ok(logoutUser);
            }

            return BadRequest();
        }
    }
}
