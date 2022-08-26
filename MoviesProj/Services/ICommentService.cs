using MoviesProj.Models.Comment;

namespace MoviesProj.Services
{
    public interface ICommentService 
    {
        Task<List<Comment>> Get(int pageNo);
        Task<Comment> Get(string id);
        Task<Comment> Create(Comment comment);
        Task<Comment> Update(string id, Comment comment);
        Task Delete(string id);
    }
}
