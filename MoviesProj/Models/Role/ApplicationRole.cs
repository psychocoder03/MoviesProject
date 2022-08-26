using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Role
{
    [BsonIgnoreExtraElements]
    public class ApplicationRole 
    {
        [BsonElement("Name")]
        public string[]? Role { get; set; }

    }
}
