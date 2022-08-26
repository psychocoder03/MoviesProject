using LoggerService;
using MongoDB.Driver;
using MoviesProj.Models;
using MoviesProj.Models.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MoviesProj.Services
{
    //internal sealed class AuthenticationService
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private User _user;
        public AuthenticationService(ILoggerManager logger, IConfiguration configuration, IMongoClient mongoClient, IMovieDatabaseSettings settings)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userCollection = database.GetCollection<User>(settings.UserCollectionName);
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<bool> userExists(string email)
        {
            return await _userCollection.Find(user => user.Email == email).AnyAsync();
        }
        public async Task<User> RegisterUser(User user)
        {
            //var result = await _userManager.CreateAsync(user, user.Password);
            //if (result.Succeeded)
            // await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            //return result;
            user.Password = GetHashedPassword(user.Password);
            await _userCollection.InsertOneAsync(user);
            //return _comment.Find(sp => sp.Id == comment.Id).FirstOrDefault();
            return user;
        }
        public async Task<bool> ValidateUser(UserForAuthentication userForAuth)
        {
            if (!await _userCollection.Find(user => user.Email == userForAuth.Email).AnyAsync())
            {
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. No such email exists.");
                return false;
            }
            var inputPassword = GetHashedPassword(userForAuth.Password);
            _user = await _userCollection.Find(user => user.Email == userForAuth.Email).FirstOrDefaultAsync();
            var result = (_user != null && _user.Password == inputPassword);
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong email or password.");
            return result;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes("dontwriteoverhere");//Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, _user.Email)
            };
            ProjectionDefinition<User,User> projection = Builders<User>.Projection.Include("Role").Exclude("Id");
            var userRoles = await _userCollection.Find(user => user.Email == _user.Email).Project(projection).FirstOrDefaultAsync(); // await _userManager.GetRolesAsync(_user);
            string[] roles = userRoles.Role;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private string GetHashedPassword(string input)
        {
            SHA256 sha256 = SHA256.Create();
            var salt = _configuration.GetSection("Salt");
            var saltValue = salt["value"];
            byte[] bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(input+saltValue));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();

        }
    }
}
