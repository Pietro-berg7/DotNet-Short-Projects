using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SuperHeroService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllSuperHeroes()
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
        var dbSuperHeroes = await _context.SuperHeroes.ToListAsync();

        serviceResponse.Data = dbSuperHeroes.Select(s => _mapper.Map<GetSuperHeroDto>(s)).ToList();
        return serviceResponse;
    }
}
