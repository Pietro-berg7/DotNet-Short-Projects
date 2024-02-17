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

    public SuperHeroService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetSuperHeroDto>>> AddSuperHero(AddSuperHeroDto newSuperHero)
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
        var dbSuperHero = _mapper.Map<SuperHero>(newSuperHero);

        _context.SuperHeroes.Add(dbSuperHero);
        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.SuperHeroes
            .Select(s => _mapper.Map<GetSuperHeroDto>(s))
            .ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSuperHeroDto>>> DeleteSuperHero(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();

        try
        {
            var dbSuperHero = await _context.SuperHeroes
                .FirstOrDefaultAsync(s => s.Id == id);

            if (dbSuperHero is null)
                throw new Exception($"Super hero with id {id} not found.");

            _context.SuperHeroes.Remove(dbSuperHero);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.SuperHeroes
                .Select(c => _mapper.Map<GetSuperHeroDto>(c)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
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
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSuperHeroDto>> UpdateSuperHero(UpdateSuperHeroDto updatedSuperHero)
    {
        var serviceResponse = new ServiceResponse<GetSuperHeroDto>();

        try
        {
            var dbSuperHero = await _context.SuperHeroes
                .FirstOrDefaultAsync(s => s.Id == updatedSuperHero.Id);

            if (dbSuperHero is null)
                throw new Exception($"Super hero with id {updatedSuperHero.Id} not found.");

            _mapper.Map(updatedSuperHero, dbSuperHero);

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(dbSuperHero);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
