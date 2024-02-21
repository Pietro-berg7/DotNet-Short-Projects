using MovieAPI.Dtos.Movie;
using MovieAPI.Models;

namespace MovieAPI.Services.MovieService;

public interface IMovieService
{
    Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies();
    Task<ServiceResponse<GetMovieDto>> GetMovie(int id);
}
