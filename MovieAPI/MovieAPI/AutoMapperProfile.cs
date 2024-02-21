using AutoMapper;
using MovieAPI.Dtos.Movie;
using MovieAPI.Models;

namespace MovieAPI;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Movie, GetMovieDto>();
        CreateMap<PostMovieDto, Movie>();
    }
}
