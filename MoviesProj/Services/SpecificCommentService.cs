using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Models.Comment;
using MoviesProj.Models.Movie;

namespace MoviesProj.Services
{
    public class SpecificCommentService : ISpecificCommentService
    {
        private readonly IMongoCollection<Comment> _comment;
        private readonly IMongoCollection<Movie> _movie;

        public SpecificCommentService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _comment = database.GetCollection<Comment>(settings.CommentCollectionName);
            _movie = database.GetCollection<Movie>(settings.MovieCollectionName);
        }
        public async Task<List<Comment>> GetEmailComment(string email)
        {
            ProjectionDefinition<Comment, Comment> projection = Builders<Comment>.Projection.Include("Text").Include("MovieId").Exclude("_id");
            return await _comment.Find(comment => comment.Email == email).Project(projection).ToListAsync() ;
        }
        public async Task<List<Comment>> GetMovieCommentById(string movieId)
        {
            ProjectionDefinition<Comment, Comment> projection = Builders<Comment>.Projection.Include("Text").Include("MovieId").Exclude("_id");
            return await _comment.Find(comment => comment.MovieId == movieId).Project(projection).ToListAsync();
        }
        public async Task<List<Comment>> GetMovieCommentByName(string movieName)
        {
            var movieByName = await _movie.Find(movie => movie.Title == movieName).FirstOrDefaultAsync();
            ProjectionDefinition<Comment, Comment> projection = Builders<Comment>.Projection.Include("Text").Include("MovieId").Exclude("_id");
            return await _comment.Find(comment => comment.Id == movieByName.Id).Project(projection).ToListAsync();
        }







        //var skip = 1;
        //var limit = 100;
        //ProjectionDefinition<Student, Student> projection = Builders<Student>.Projection.Include(student => student.Name).Exclude("_id");
        //var options = new FindOptions
        //{
        //    MaxTime = TimeSpan.FromSeconds(3)
        //};
        //    return _students.Find(student => student.Courses!.Contains(courseName),options).Project(projection).Limit(limit).Skip(skip).SortByDescending(student => student.Name).ToList();
        ////https://stackoverflow.com/questions/49533659/mongodb-projection-in-c-sharp


        ////var filter = Builders<Student>.Filter.Empty;
        ////return _students.Find(student => student.Courses!.Contains(courseName)).Limit(2).ToList();
    }
}
