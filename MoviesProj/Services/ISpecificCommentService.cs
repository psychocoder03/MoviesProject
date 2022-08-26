using MoviesProj.Models.Comment;

namespace MoviesProj.Services
{
    public interface ISpecificCommentService
    {
        Task<List<Comment>> GetEmailComment(string email);
        Task<List<Comment>> GetMovieCommentById(string movieId);
        Task<List<Comment>> GetMovieCommentByName(string movieName);
    }
}
