using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Theater
{
    public class Location
    {
        [BsonElement("address")]
        public Address? Address { get; set; }

        [BsonElement("geo")]
        public Geo? Geo { get; set; }
    }
}
