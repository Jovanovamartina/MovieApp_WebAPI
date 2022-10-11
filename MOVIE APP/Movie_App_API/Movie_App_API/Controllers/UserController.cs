
using BookApp.DTO.UsersDto;
using Busines.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookApp.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDto user)
        {
            try
            { 
                _userService.RegisterUser(user);
                return Ok("User added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] UserLoginDto user)
        {
            try
            {
                var token = _userService.Authenticate(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] UpdateUserDto user)
        {
            try
            {
                _userService.ForgotPassword(user);
                return Ok("Password changed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public IActionResult GetUSers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok("User is deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
