using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllSuperHeroes();
    Task<ServiceResponse<GetSuperHeroDto>> GetSuperHero(int id);
    Task<ServiceResponse<List<GetSuperHeroDto>>> AddSuperHero(AddSuperHeroDto newSuperHero);
    Task<ServiceResponse<GetSuperHeroDto>> UpdateSuperHero(UpdateSuperHeroDto updatedSuperHero);
    Task<ServiceResponse<List<GetSuperHeroDto>>> DeleteSuperHero(int id);
}
