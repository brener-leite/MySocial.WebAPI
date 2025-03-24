using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySocial.Application.Features.Post.Commands.CreatePost;
using MySocial.Application.Features.Post.Queries.GetAllPosts;
using MySocial.Application.Features.Post.Queries.GetPostById;
using MySocial.Application.Features.Post.Queries.GetPostsByUserId;

namespace MySocial.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostById([FromQuery] GetPostByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetPostsByUserId([FromQuery] GetPostsByUserIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var post = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPostById), post);
        }
    }
}