using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Movie
{
    public class Viewer
    {
        [BsonElement("rating")]
        public double Rating { get; set; }
        [BsonElement("numReviews")]
        public int NumReviews { get; set; }
        [BsonElement("meter")]
        public int Meter { get; set; }
    }
}
