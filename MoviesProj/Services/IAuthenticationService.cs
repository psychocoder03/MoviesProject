using MoviesProj.Models.User;

namespace MoviesProj.Services
{
    public interface IAuthenticationService
    {
        Task<User> RegisterUser(User user);
        Task<bool> userExists(string email);
        Task<bool> ValidateUser(UserForAuthentication userForAuth);
        Task<string> CreateToken();
    }
}
