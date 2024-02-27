using Microsoft.AspNetCore.Mvc;
using MovieAPI.Dtos.Movie;
using MovieAPI.Models;

namespace MovieAPI.Services.MovieService;

public interface IMovieService
{
    Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies();
    Task<ServiceResponse<GetMovieDto>> GetMovie(int id);
    Task<ServiceResponse<List<GetMovieDto>>> AddMovie(PostMovieDto newMovie);
    Task<ServiceResponse<GetMovieDto>> UpdateMovie(PutMovieDto updatedMovie);
    Task<ServiceResponse<List<GetMovieDto>>> DeleteMovie(int id);
}
