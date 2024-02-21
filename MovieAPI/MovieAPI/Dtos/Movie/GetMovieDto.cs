namespace MovieAPI.Dtos.Movie;

public class GetMovieDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
}
