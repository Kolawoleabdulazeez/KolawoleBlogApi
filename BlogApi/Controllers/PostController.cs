
using DataAccess.IRepositories;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public class PostIdDTO
        {
            public int Id { get; set; }
        }

        private readonly IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
         
        }

        // GET: api/<PostController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_postService.FindAllPosts());
        }

        // GET api/<PostController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            GetPostDto? post = _postService.FindPostBy(id, out string message);
            if (post is null)
            {
                return NotFound(message);
            }
            return Ok(post);
        }

        // POST api/<PostController>
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostDto post)
        {
            Post? newPost = _postService.CreatePost(post, out string message);
            return (newPost is null) ? BadRequest(message) : Ok(message);
        }

        // Patch api/<PostController>/5
        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromBody] UpdatePost post)
        {
            Post? updatedPost = _postService.UpdatePost(post, out string message);
            return (updatedPost is null) ? BadRequest(message) : Ok(message);
        }

        // DELETE api/<PostController>/5
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(PostIdDTO post)
        {
            return _postService.DeletePost(post.Id, out string message) ? Ok(message) : BadRequest(message);
           
        }
    }
}
