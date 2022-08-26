using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Theater
{
    public class Geo
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("coordinates")]
        public double[]? Coordinates { get; set; }
    }
}
