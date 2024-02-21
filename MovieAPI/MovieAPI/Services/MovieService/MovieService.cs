using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.Data;
using MovieAPI.Dtos.Movie;
using MovieAPI.Models;

namespace MovieAPI.Services.MovieService;

public class MovieService: IMovieService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public MovieService(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies()
    {
        var serviceResponse = new ServiceResponse<List<GetMovieDto>>();

        try
        {
            var dbMovies = await _context.Movies.ToListAsync();

            if (dbMovies.IsNullOrEmpty())
                throw new Exception($"No movies were found.");

            serviceResponse.Data = dbMovies.Select(m => _mapper.Map<GetMovieDto>(m)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetMovieDto>> GetMovie(int id)
    {
        var serviceResponse = new ServiceResponse<GetMovieDto>();

        try
        {
            var dbMovie = await _context.Movies.FindAsync(id);

            if (dbMovie is null)
                throw new Exception($"Movie with id {id} not found.");

            serviceResponse.Data = _mapper.Map<GetMovieDto>(dbMovie);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
