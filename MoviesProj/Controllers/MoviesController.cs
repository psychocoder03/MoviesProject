using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesProj.Models.Movie;
using MoviesProj.Services;

namespace MoviesProj.Controllers
{
    //[AutoValidateAntiforgeryToken]
    [Route("api/movies")]
    [ApiController]
    [Authorize]
    public class MoviesContoller : Controller
    {
        private readonly IMovieService movieService;

        public MoviesContoller(IMovieService movieService)
        {
            this.movieService = movieService;
        }


        // GET: MoviesController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await movieService.Get());
        }


        // GET: MoviesController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(string id)
        {
            var movie = await movieService.Get(id);
            if (movie == null)
                return NotFound($"Movie with Id {id} not found.");
            return Ok(movie);
        }

        // POST: MoviesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Movie movie)
        {
            if (movie.Id == null)
            {
                return BadRequest("Movie Id cannot be null.");
            }
            if (movie.NumComments != 0)
                return BadRequest("Number of Comments must be initialized at 0.");
            return Ok(await movieService.Create(movie));
            //return CreatedAtAction(nameof(Index), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(string id, Movie movie)
        {
            if (movie.Id != id)
            {
                return BadRequest("Movie Id cannot be different.");
            }
            var existingMovie = await movieService.Get(id);
            if (existingMovie == null)
                return NotFound($"Movie with Id {id} not found.");

            if (existingMovie.NumComments != movie.NumComments)
                return BadRequest("Number of Comments field cannot be edited.");

            return Ok(await movieService.Update(id, movie));
            //return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            if (await movieService.Get(id) == null)
                return NotFound($"Movie with Id {id} not found");
            await movieService.Delete(id);
            return Ok($"Movie with Id {id} deleted");
        }


        [Route("api/movieCustomLang")]
        // GET: MoviesController
        [HttpGet]
        public async Task<ActionResult> LangSpecMovie(string language)
        {
            if (!movieService.CheckIfLangCollectionExists(language))
            {
                if (await movieService.CheckIfMovieLangExists(language))
                    return NotFound($"No movies exist for the langauge {language}");
                await movieService.CreateFillLangCollection(language);
            }
            var langSpecMovies = movieService.GetLangCollection(language);
            return Ok(langSpecMovies);
        }


        [Route("api/movieCustomLangDirect")]
        // GET: MoviesController
        [HttpGet]
        public async Task<ActionResult> LangSpecMovieDirect(string language)
        {
            var langSpecMovies = await movieService.GetLangMoviesDirect(language);
            if (langSpecMovies == null)
                return NotFound($"No movies exist for the langauge {language}");
            return Ok(langSpecMovies);
        }


        [Route("api/movieLongestRuntime")]
        // GET: MoviesController
        [HttpGet]
        public async Task<ActionResult> MovieLongestRuntime(int numOfMovies)
        {
            return Ok(await movieService.GetMoviesLongestRuntime(numOfMovies));
        }


    }
}
