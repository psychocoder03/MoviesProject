using Microsoft.AspNetCore.Mvc;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiVersion("2.0")]
    [Route("api/comments")]
    [ApiController]
    public class CommentsV2Controller : Controller
    {
        private readonly ICommentService commentService;

        public CommentsV2Controller(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: CommentsController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(string id)
        {
            var comment = await commentService.Get(id);
            if (comment == null)
                return NotFound($"Comment with Id {id} not found.");
            return Ok(comment);
        }
    }
}
