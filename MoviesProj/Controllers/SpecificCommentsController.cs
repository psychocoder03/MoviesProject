using Microsoft.AspNetCore.Mvc;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    [AutoValidateAntiforgeryToken]
    [ApiController]
    public class SpecificCommentsController : Controller
    {
        private readonly ISpecificCommentService specificCommentService;
        public SpecificCommentsController(ISpecificCommentService specificCommentService)
        {
            this.specificCommentService = specificCommentService;
        }
        [Route("api/emailCustomComments")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> EmailSpecComment(string email)
        {
            var emailSpecComment = await specificCommentService.GetEmailComment(email);
            if (emailSpecComment == null)
                return NotFound("No Comment exists for the given Email");
            return Ok(emailSpecComment);
        }
        [Route("api/movieCustomCommentsId")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> MovieSpecCommentId(string movieId)
        {
            var movieSpecComment = await specificCommentService.GetMovieCommentById(movieId);
            if (movieSpecComment == null)
                return NotFound("No Comment exists for the given Movie.");
            return Ok(movieSpecComment);
        }
        [Route("api/movieCustomCommentsName")]
        // GET: SpecCommentsController
        [HttpGet]
        public async Task<ActionResult> MovieSpecCommentName(string movieName)
        {
            var movieSpecComment = await specificCommentService.GetMovieCommentByName(movieName);
            if (movieSpecComment == null)
                return NotFound("No Comment exists for the given Movie.");
            return Ok(movieSpecComment);
        }
    }
}
