using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MoviesProj.Models.Comment
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the name field is 60 charactes.")]
        [BsonElement("name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required field.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [BsonElement("email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Movie Id is required field.")]
        [BsonRequired]
        [BsonElement("movie_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? MovieId { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

    }
}
