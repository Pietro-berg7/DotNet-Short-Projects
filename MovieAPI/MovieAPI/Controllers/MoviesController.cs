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
        var response = await _movieService.AddMovie(newMovie);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<Movie>>>> UpdateMovie(PutMovieDto updatedMovie)
    {
        var response = await _movieService.UpdateMovie(updatedMovie);

        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<List<Movie>>>> DeleteMovie(int id)
    {
        var response = await _movieService.DeleteMovie(id);

        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }
}
