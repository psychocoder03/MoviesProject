namespace MoviesProj.Models
{
    public interface IMovieDatabaseSettings
    {
        string? UserCollectionName { get; set; }
        string? CommentCollectionName { get; set; }
        string? MovieCollectionName { get; set; }
        string? ConnectionString { get; set; }
        string? DatabaseName { get; set; }
    }
}
