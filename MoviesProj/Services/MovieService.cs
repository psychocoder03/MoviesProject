using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Models.Movie;

namespace MoviesProj.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<Movie> _movie;
        private readonly IMongoDatabase _database;

        public MovieService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(settings.DatabaseName);
            _movie = _database.GetCollection<Movie>(settings.MovieCollectionName);
        }
        public async Task<List<Movie>> Get()
        {

            return await _movie.Find(movie => true).ToListAsync();
        }
        public async Task<Movie> Get(string id)
        {
            //await ApiCall.ProcessRepositories("movies/573a1390f29313caabcd4135");

            //var responseString = ApiCall.GetApi("https://data.police.uk/api/forces/leicestershire/people");
            //Console.WriteLine(responseString);

            return await _movie.Find(movie => movie.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Movie> Create(Movie movie)
        {
            await _movie.InsertOneAsync(movie);
            //return _movie.Find(sp => sp.Id == movie.Id).FirstOrDefault();
            return movie;
        }
        public async Task<Movie> Update(string id, Movie movie)
        {
            await _movie.ReplaceOneAsync(movie => movie.Id == id, movie);
            return await _movie.Find(sp => sp.Id == id).FirstOrDefaultAsync();

        }
        public async Task Delete(string id)
        {
            await _movie.DeleteOneAsync(movie => movie.Id == id);
        }
        public async Task IncreaseNumComments(string id)
        {
            var update = Builders<Movie>.Update.Inc("NumComments", 1);
            await _movie.UpdateOneAsync(movie => movie.Id == id,update);
        }
        public async Task DecreaseNumComments(string id)
        {
            var update = Builders<Movie>.Update.Inc("NumComments", -1);
            await _movie.UpdateOneAsync(movie => movie.Id == id, update);
        }
        public bool CheckIfLangCollectionExists(string language)
        {
            bool collectionExists = _database.ListCollectionNames().ToList().Contains(language);
            return collectionExists;
        }
        public async Task<bool> CheckIfMovieLangExists(string language)
        {
            var movieLang = await _movie.Find(movie => movie.Languages.Contains(language)).FirstOrDefaultAsync();
            if (movieLang == null)
                return false;
            else
                return true;
        }
        public async Task CreateFillLangCollection(string language)
        {
            await _database.CreateCollectionAsync(language);
            var _language = _database.GetCollection<Movie>(language);
            ProjectionDefinition<Movie, Movie> projection = Builders<Movie>.Projection.Include("Title").Include("Languages").Include("Rated").Exclude("_id");
            await _language.InsertManyAsync(_movie.Find(movie => movie.Languages.Contains(language)).Project(projection).ToList());
        }
        public async Task<List<Movie>> GetLangCollection (string language)
        {
            var _movies = _database.GetCollection<Movie>(language);
            return await _movies.Find(movie => true).ToListAsync();

        }
        public async Task<List<Movie>> GetLangMoviesDirect(string language)
        {
            ProjectionDefinition<Movie, Movie> projection = Builders<Movie>.Projection.Include("Title").Include("Languages").Include("Rated").Exclude("_id");
            return await _movie.Find(movie => movie.Languages.Contains(language)).Project(projection).ToListAsync();
        }
        public async Task<List<Movie>> GetMoviesLongestRuntime(int numOfMovies)
        {
            ProjectionDefinition<Movie, Movie> projection = Builders<Movie>.Projection.Include("Title").Include("RunTime").Exclude("_id");
            return await _movie.Find(movie => true).SortByDescending(movie => movie.RunTime).Limit(numOfMovies).Project(projection).ToListAsync();
        }
    }
}
