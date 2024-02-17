using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SuperHeroController: ControllerBase
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<SuperHero>>>> GetAllHeroes()
    {        
        return Ok(await _superHeroService.GetAllSuperHeroes());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ServiceResponse<SuperHero>>> GetSuperHero(int id)
    {
        return Ok(await _superHeroService.GetSuperHero(id));
    }
}
