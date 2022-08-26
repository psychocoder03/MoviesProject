using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Models.Comment;

namespace MoviesProj.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMongoCollection<Comment> _comment;

        public CommentService(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _comment = database.GetCollection<Comment>(settings.CommentCollectionName);
        }
        public async Task<List<Comment>> Get(int pageNo)
        {
            var commentPerPage = 100;
            return await _comment.Find(comment => true).Skip((pageNo - 1)* commentPerPage).Limit(commentPerPage).ToListAsync() ;
        }
        public async Task<Comment> Get(string id)
        {
            return await _comment.Find(comment => comment.Id == id).FirstOrDefaultAsync() ;
        }
        public async Task<Comment> Create(Comment comment)
        {
             await _comment.InsertOneAsync(comment);
            //return _comment.Find(sp => sp.Id == comment.Id).FirstOrDefault();
            return comment;
        }
        public async Task<Comment> Update(string id, Comment comment)
        {
            _comment.ReplaceOne(comment => comment.Id == id, comment);
            return await _comment.Find(sp => sp.Id == id).FirstOrDefaultAsync();

        }
        public async Task Delete(string id)
        {
            await _comment.DeleteOneAsync(comment => comment.Id == id);
        }
    }
}
