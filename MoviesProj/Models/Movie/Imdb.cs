using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesProj.Models.Movie
{
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        [BsonElement("id")]
        public int ImdbId { get; set; }
        //public int Id { get; set; } - This was giving an error. Why?

        //[BsonElement("rating")]
        //public double Rating { get; set; }
        //This gives an deserialization error 
        //An error occurred while deserializing the Rating property of class MoviesProj.Models.Imdb: Input string was not in a correct format.
        //[BsonElement("votes")]
        //public int Votes { get; set; }
        //This gives an deserialization error 


    }
}
