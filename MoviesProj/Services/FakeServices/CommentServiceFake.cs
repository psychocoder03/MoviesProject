//using MoviesProj.Models.Comment;

//namespace MoviesProj.Services.FakeServices
//{
//    public class CommentServiceFake : ICommentService
//    {
//        private readonly List<Comment> _comment;

//        public CommentServiceFake()
//        {
//            _comment = new List<Comment>()
//            {
//                new Comment()
//                {
//                    Id = "5a9427648b0beebeb6957a21",
//                    Name = "Jaqen H ghar",
//                    Email = "tom_wlaschiha@gameofthron.es",
//                    MovieId = "573a1390f29313caabcd516c",
//                    Text = "Minima odit officiis minima nam. Aspernatur id reprehenderit eius inventore amet laudantium. Eos unde enim recusandae fugit sint.",
//                    Date = DateTime.UtcNow
//                },
//                new Comment()
//                {
//                    Id = "5a9427648b0beebeb6957a22",
//                    Name = "Taylor Scott",
//                    Email = "taylor_scott@fakegmail.com",
//                    MovieId = "573a1390f29313caabcd4eaf",
//                    Text = "Iure laboriosam quo et necessitatibus sed. Id iure delectus soluta. Quaerat officiis maiores commodi earum. Autem odio labore debitis optio libero.",
//                    Date = DateTime.UtcNow
//                },
//                new Comment()
//                {
//                    Id = "5a9427648b0beebeb6957a38",
//                    Name = "Yara Greyjoy",
//                    Email = "gemma_whelan@gameofthron.es",
//                    MovieId = "573a1390f29313caabcd587d",
//                    Text = "Nobis incidunt ea tempore cupiditate sint. Itaque beatae hic ut quis.",
//                    Date = DateTime.UtcNow
//                }
//            };
//        }
//        public Task<List<Comment>> Get()
//        {
//            return Task.FromResult(_comment);
//        }
//        public Comment Get(string id)
//        {
//            return _comment.Where(comment => comment.Id == id).FirstOrDefault();
//        }
//        public Comment Create(Comment comment)
//        {
//            _comment.Add(comment);
//            return _comment.Where(existingComment => existingComment.Id == comment.Id).FirstOrDefault();
//        }
//        public Comment Update(string id, Comment comment)
//        {
//            _comment.Remove(_comment.First(sp => sp.Id == id));
//            _comment.Add(comment);
//            return _comment.Where(comment => comment.Id == id).FirstOrDefault();
//        }
//        public void Delete(string id)
//        {
//            var existingComment = _comment.First(sp => sp.Id == id);
//            _comment.Remove(existingComment);

//        }
//    }
//}
