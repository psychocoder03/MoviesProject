using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Theater
{
    public class Theater
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("theaterId")]
        public int TheaterId { get; set; }

        [BsonElement("location")]
        public Location? Location { get; set; }
    }
}

