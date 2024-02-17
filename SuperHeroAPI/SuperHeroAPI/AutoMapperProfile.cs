using AutoMapper;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SuperHero, GetSuperHeroDto>();
        CreateMap<AddSuperHeroDto, SuperHero>();
        CreateMap<UpdateSuperHeroDto, SuperHero>();
    }
}
