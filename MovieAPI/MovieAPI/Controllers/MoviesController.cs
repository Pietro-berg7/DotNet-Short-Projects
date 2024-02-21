using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController: ControllerBase
{
    private readonly MovieContext _dbContext;

    public MoviesController(MovieContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        if(_dbContext.Movies is null)
            return NotFound();

        return await _dbContext.Movies.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        if (_dbContext.Movies is null)
            return NotFound();

        var movie = await _dbContext.Movies.FindAsync(id);

        if (movie is null)
            return NotFound();

        return movie;
    }
}
