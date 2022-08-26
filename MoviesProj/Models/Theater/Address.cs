using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Theater
{
    public class Address
    {
        [BsonElement("street1")]
        public string? Street1 { get; set; }

        [BsonElement("street2")]
        public string? Street2 { get; set; }

        [BsonElement("city")]
        public string? City { get; set; }

        [BsonElement("state")]
        public string? State { get; set; }

        [BsonElement("zipcode")]
        public string? ZipCode { get; set; }
    }
}
