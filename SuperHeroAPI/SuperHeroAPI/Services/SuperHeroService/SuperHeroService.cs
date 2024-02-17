using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public SuperHeroService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllSuperHeroes()
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
        var dbSuperHeroes = await _context.SuperHeroes.ToListAsync();

        serviceResponse.Data = dbSuperHeroes.Select(s => _mapper.Map<GetSuperHeroDto>(s)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSuperHeroDto>> GetSuperHero(int id)
    {
        var serviceResponse = new ServiceResponse<GetSuperHeroDto>();

        try
        {
            var dbSuperHero = await _context.SuperHeroes.FindAsync(id);

            if (dbSuperHero is null)
                throw new Exception($"Super hero with id {id} not found.");

            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(dbSuperHero);
        }
        catch(Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
