using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Gets all users", Description = "Returns a list of all users.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of users", typeof(IEnumerable<UserDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Get user by Id", Description = "Return an instance of user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return user by Id", typeof(UserDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Allows you to register a new user"), Description = "Return an instance of user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User was registered successfully", typeof(UserDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            return Ok(await _userService.RegisterAsync(registerDTO));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Allows you to log in", Description = "Return a bearer token."))]
        [SwaggerResponse(StatusCodes.Status200OK, "User was logged in successfully", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            return Ok(await _userService.LoginAsync(loginDTO));
        }

        [HttpPut]
        [Authorize]
        [SwaggerOperation(Summary = "Allows you to update a user info")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "User info was updated successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> UpdateAsync(UpdateUserDTO updateUserDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("The request data was not validated.");
            }

            await _userService.UpdateAsync(updateUserDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [SwaggerOperation(Summary = "Allows you to delete a user")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "User was deleted successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authorization has been denied for this request")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Access is forbidden. This endpoint is only accessible for 'admin' role.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not found! See json response for details.", typeof(ContentResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error! See json response for details.", typeof(ContentResult))]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _userService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
