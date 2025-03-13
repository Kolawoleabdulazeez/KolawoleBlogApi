using DataAccess.IRepositories;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {

        private readonly ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }


        // PUT api/<LikeController>/5
        [Authorize]
        [HttpPost()]
        public IActionResult Like([FromBody]LikesDto like)
        {
           return  _likeService.Like(like, out string message) ? Ok(message) : BadRequest(message);
        }




    }
}
