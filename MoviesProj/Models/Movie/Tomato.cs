using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Movie
{
    [BsonIgnoreExtraElements]
    public class Tomato
    {
        [BsonElement("viewer")]
        public Viewer? Viewer { get; set; }
        [BsonElement("dvd")]
        public DateTime Dvd { get; set; }
        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [BsonElement("boxOffice")]
        public string? BoxOffice { get; set; }

    }
}
