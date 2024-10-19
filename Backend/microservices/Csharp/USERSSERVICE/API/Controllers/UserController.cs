using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersService.Users.Application.Services;
using UsersService.Users.Domain.Entities;

namespace UsersService.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUserById(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<User?>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

// quiero crear un filtrado mas avanzado  de solo usuario 
// validar  si exte usuario existe
// post para usuario activos
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user, string plainPassword)
        {
            await _userService.AddUserAsync(user, plainPassword);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user, string? plainPassword = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userService.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.UpdateUserAsync(user, plainPassword);

            return NoContent();  // 204 NoContent es adecuado para actualizaciones exitosas sin necesidad de devolver un recurso
        }




         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userService.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);

            return NoContent(); // Devuelve NoContent ya que no hay información que devolver tras la eliminación
        }
        }
}
