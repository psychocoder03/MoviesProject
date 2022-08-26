using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models.User
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email is required.")]
        [BsonElement("email")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Minimum length for the password field is 8 characters.")]
        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("role")]
        public string[]? Role { get; set; } = { "User" };
    }
}
