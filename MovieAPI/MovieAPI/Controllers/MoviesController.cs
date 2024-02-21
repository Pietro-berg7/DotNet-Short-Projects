using Microsoft.AspNetCore.Mvc;
using MovieAPI.Dtos.Movie;
using MovieAPI.Models;
using MovieAPI.Services.MovieService;

namespace MovieAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController: ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Movie>>>> GetAllMovies()
    {
        if (await _movieService.GetAllMovies() is null)
            return NotFound();

        return Ok(await _movieService.GetAllMovies());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        if (await _movieService.GetMovie(id) is null)
            return NotFound();

        return Ok(await _movieService.GetMovie(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Movie>>> AddMovie(PostMovieDto newMovie)
    {
        return Ok(await _movieService.AddMovie(newMovie));
    }
}
