using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models.User
{
    public record UserForAuthentication
    {
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "User name is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}
