//using MoviesProj.Models.Movie;

//namespace MoviesProj.Services.FakeServices
//{
//    public class MovieServiceFake :IMovieService
//    {
//        private readonly List<Movie> _movie;
//        public MovieServiceFake()
//        {
//            _movie = new List<Movie>
//            {
//                new Movie()
//                {
//                    Id = "573a1390f29313caabcd4135",
//                    Plot = "Three men hammer on an anvil",
//                    NumComments = 0
//                },
//                new Movie()
//                {
//                    Id = "573a1390f29313caabcd4135",
//                    Runtime =1,
//                    NumComments = 2,
             
//                },
//                new Movie()
//                {
//                    Id = "573a1390f29313caabcd4135",
//                    Tomato = new Tomato()
//                    {
//                        Viewer = new Viewer()
//                        {
//                            Rating = 3,
//                            NumReviews = 184,
//                            Meter = 32
//                        },
//                        LastUpdated = DateTime.Now,
//                    },
//                    NumComments = 4
//                }

//            };
//        }

//        public Movie Create(Movie comment)
//        {
//            throw new NotImplementedException();
//        }

//        public void DecreaseNumComments(string id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(string id)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Movie> Get()
//        {
//            throw new NotImplementedException();
//        }

//        public Movie Get(string id)
//        {
//            throw new NotImplementedException();
//        }

//        public void IncreaseNumComments(string id)
//        {
//            throw new NotImplementedException();
//        }

//        public Movie Update(string id, Movie comment)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}


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
