namespace MoviesProj.Models
{
    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
        public string? UserCollectionName { get; set; }
        public string? CommentCollectionName { get; set; }
        public string? MovieCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }

    }
}
