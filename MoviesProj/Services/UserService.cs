//using Microsoft.IdentityModel.Tokens;
//using MongoDB.Driver;
//using MoviesProj.Models;
//using MoviesProj.Models.User;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace MoviesProj.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IMongoCollection<User> _user;
//        private readonly string key;

//        public UserService(IMovieDatabaseSettings settings, IMongoClient mongoClient, IConfiguration configuration)
//        {
//            var database = mongoClient.GetDatabase(settings.DatabaseName);
//            _user = database.GetCollection<User>(settings.UserCollectionName);
//           //configuration.GetSection("Jwt").ToString();
//        }

//        public async Task<string?> Authenticate(string email, string password)
//        {
//            Console.WriteLine(email);
//            Console.WriteLine(password);
//            var user = await _user.Find(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
//            Console.WriteLine(user);
//            if (user == null)
//                return null;
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var tokenKey = Encoding.ASCII.GetBytes("somekeyinhereforyou");
//            var tokenDescriptor = new SecurityTokenDescriptor()
//            {
//                Subject = new ClaimsIdentity(
//                    new Claim[]
//                    {
//                        new Claim(ClaimTypes.Email, email)
//                    }),
//                Expires = DateTime.UtcNow.AddHours(1),
//                SigningCredentials = new SigningCredentials(
//                    new SymmetricSecurityKey(tokenKey),
//                    SecurityAlgorithms.HmacSha256Signature
//                    )
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        public async Task<List<User>> Get(int pageNo)
//        {
//            var commentPerPage = 100;
//            return await _user.Find(user => true).Skip((pageNo - 1) * commentPerPage).Limit(commentPerPage).ToListAsync();
//        }
//        public async Task<User> Get(string id)
//        {
//            return await _user.Find(user => user.Id == id).FirstOrDefaultAsync();
//        }
//        public async Task<User> Create(User user)
//        {
//            await _user.InsertOneAsync(user);
//            //return _comment.Find(sp => sp.Id == comment.Id).FirstOrDefault();
//            return user;
//        }

//        //public async Task<Comment> Update(string id, Comment comment)
//        //{
//        //    _comment.ReplaceOne(comment => comment.Id == id, comment);
//        //    return await _comment.Find(sp => sp.Id == id).FirstOrDefaultAsync();

//        //}
//        //public async Task Delete(string id)
//        //{
//        //    await _comment.DeleteOneAsync(comment => comment.Id == id);
//        //}
//    }
//}
