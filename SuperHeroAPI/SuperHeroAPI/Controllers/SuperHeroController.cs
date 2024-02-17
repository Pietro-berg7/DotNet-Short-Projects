using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Dtos.SuperHero;
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
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse<SuperHero>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ServiceResponse<List<SuperHero>>>> GetAllHeroes()
    {
        return Ok(await _superHeroService.GetAllSuperHeroes());
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse<SuperHero>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServiceResponse<SuperHero>>> GetSuperHero(int id)
    {
        var response = await _superHeroService.GetSuperHero(id);

        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse<SuperHero>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> AddSuperHero(AddSuperHeroDto newSuperHero)
    {
        return Ok(await _superHeroService.AddSuperHero(newSuperHero));
    }

    [HttpPut]
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse<SuperHero>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> UpdateSuperHero(UpdateSuperHeroDto updatedSuperHero)
    {
        var response = await _superHeroService.UpdateSuperHero(updatedSuperHero);

        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse<SuperHero>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> DeleteSuperHero(int id)
    {
        var response = await _superHeroService.DeleteSuperHero(id);

        if (response.Data is null)
            return NotFound(response);

        return Ok(response);
    }
}
