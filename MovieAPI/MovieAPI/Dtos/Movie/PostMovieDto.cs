﻿namespace MovieAPI.Dtos.Movie;

public class PostMovieDto
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
}
