using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllSuperHeroes();
}
