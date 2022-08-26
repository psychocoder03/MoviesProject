using MoviesProj.Models.Movie;

namespace MoviesProj.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> Get();
        Task<Movie> Get(string id);
        Task<Movie> Create(Movie comment);
        Task<Movie> Update(string id, Movie comment);
        Task Delete(string id);
        Task IncreaseNumComments(string id);
        Task DecreaseNumComments(string id);
        bool CheckIfLangCollectionExists(string language);
        Task<bool> CheckIfMovieLangExists(string language);
        Task CreateFillLangCollection(string language);
        Task<List<Movie>> GetLangCollection(string language);
        Task<List<Movie>> GetLangMoviesDirect(string language);
        Task<List<Movie>> GetMoviesLongestRuntime(int numOfMovies);

    }
}
