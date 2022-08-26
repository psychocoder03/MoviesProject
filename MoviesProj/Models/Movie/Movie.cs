using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Movie
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("plot")]
        public string? Plot { get; set; }
        [BsonElement("genres")]
        public string[]? Genres { get; set; }
        [BsonElement("runtime")]
        public int RunTime { get; set; }
        [BsonElement("cast")]
        public string[]? Cast { get; set; }
        [BsonElement("num_mflix_comments")]
        public int NumComments { get; set; }
        [BsonElement("poster")]
        public string? Poster { get; set; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("fullplot")]
        public string? FullPlot { get; set; }
        [BsonElement("countries")]
        public string[]? Countries { get; set; }
        [BsonElement("languages")]
        public string[]? Languages { get; set; }
        [BsonElement("released")]
        public DateTime Released { get; set; }
        [BsonElement("directors")]
        public string[]? Directors { get; set; }
        [BsonElement("rated")]
        public string? Rated { get; set; }
        [BsonElement("awards")]
        public Award? Award { get; set; }
        [BsonElement("lastupdated")]
        public string? LastUpdated { get; set; }
        //[BsonElement("year")]
        //public int Year { get; set; } 
        //This gives an deserialization error 
        [BsonElement("imdb")]
        public Imdb? Imdb { get; set; }
        [BsonElement("type")]
        public string? Type { get; set; }
        [BsonElement("tomatoes")]
        public Tomato? Tomato { get; set; }
        [BsonElement("metacritic")]
        public int MetaCritic { get; set; }
        [BsonElement("writers")]
        public string[]? Writers { get; set; }
    }
}
