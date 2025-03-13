using DataAccess.IRepositories;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }



        // POST api/<CommentController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] MakeCommentsDto comment)
        {
            return ( _commentService.CreateComment(comment, out string message) is null ) ? BadRequest(message) : Ok(message);
        }


        [Authorize]
        [HttpPost("update")]
        public IActionResult UpdateComment([FromBody] UpdateComment comment)
        {
            return (_commentService.UpdateComment(comment, out string message) is null) ? BadRequest(message) : Ok(message);
        }


    }
}
