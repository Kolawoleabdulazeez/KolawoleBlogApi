using BusinessLogic.IServices;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
//using LoginRequest = Domain.Models.LoginRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
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

     
        // POST api/<UserController>
        [HttpPost]
        public IActionResult CreateUser([FromBody]CreateUserDto user)
        {
           User? newUser =  _userService.CreateUser(user, out string message );
            return (newUser is null) ? BadRequest(message) : Ok(message);

        }


        [Authorize]
        [HttpPatch]
        public IActionResult UpdateUserName(UpdateUserDto user)
        {
            User? existingUser = _userService.UpdateUser(user, out string message   );

            if (existingUser is null)
            {
                return BadRequest(message);
            }
            return Ok(message);

            
        }



        //12th March 
        [HttpPost("login")]
        public  IActionResult Login([FromBody] LoginRequestDto model)
        {
            User? user = _userService.LoginUser(model, out string message);
            if (user is null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Set JWT token in Authorization header
            Response.Headers["Authorization"] = $"Bearer {message}";

            // Optionally return token in the response body as well
            return Ok("Login successful");
        }


        [Authorize]
        [HttpGet("logout")]
        public IActionResult logout(int  Id)
        {
            return _userService.LogoutUser(Id, out string message) ? Ok(message) : BadRequest(message);
        }
    }
}
