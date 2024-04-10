using BoilerplateCleanArch.Application.DTOS.User;
using BoilerplateCleanArch.Application.Interfaces.IUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var users = await _userService.GetUsers();
            if (users == null)
                return NotFound("Users not found");

            return Ok(users);
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("Invalid Data");

            await _userService.Add(userDTO);

            return new CreatedAtRouteResult("GetUser", new { id = userDTO.Id }, userDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO userDTO)
        {
            if (id != userDTO.Id)
                return BadRequest();

            if (userDTO == null)
                return BadRequest();

            await _userService.Update(userDTO);

            return Ok(userDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var userDTO = await _userService.GetById(id);

            if (userDTO == null)
                return NotFound("Category not found");

            await _userService.Remove(userDTO.Id);

            return Ok(userDTO);
        }

    }
}
