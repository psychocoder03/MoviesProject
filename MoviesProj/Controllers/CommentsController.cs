using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models.Comment;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [Authorize(Roles = "Manager")]
    //[AutoValidateAntiforgeryToken]
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMovieService movieService;

        public CommentsController(ICommentService commentService,IMovieService movieService)
        {
            this.commentService = commentService;
            this.movieService = movieService;
        }

        // GET: CommentsController
        [HttpGet]
        public async Task<ActionResult> Index(int pageNo = 1)
        {
            return Ok(await commentService.Get(pageNo));
        }

        [ApiExplorerSettings(GroupName = "v1")]
        [ApiVersion("1.0", Deprecated = true)]
        // GET: CommentsController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(string id)
        {
            var comment = await commentService.Get(id);
            if (comment == null)
                return NotFound($"Comment with Id {id} not found.");
            return Ok(comment);
        }

        // POST: CommentsController/Create
        [HttpPost]
        //[]
        public async Task<ActionResult> Create(Comment comment)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await movieService.Get(comment.MovieId) == null)
                return BadRequest("No movie exists for specified Movie Id.");
            await movieService.IncreaseNumComments(comment.MovieId);
            return Ok(await commentService.Create(comment));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(string id,[FromBody] Comment comment)
        {
            if (comment.Id != id)
                return BadRequest("Comment Id cannot be different.");
            var existingComment = await commentService.Get(id);
            if(existingComment == null)
                return NotFound($"Comment with Id {id} not found.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (comment.MovieId != existingComment.MovieId)
                return BadRequest("You cannot change Movie Id.");

            return  Ok(await commentService.Update(id, comment));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var commentToBeDeleted = await commentService.Get(id);
            if (commentToBeDeleted == null)
                return NotFound($"Comment with Id {id} not found");
            await commentService.Delete(id);
            await movieService.DecreaseNumComments(commentToBeDeleted.MovieId);
            return Ok($"Comment with Id {id} deleted");
        }
    }
}
