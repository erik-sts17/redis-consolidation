using AutoMapper;
using Back.Redis.Business.Models.V1.Pokemon;
using Back.Redis.Data.Integrations.V2.PokeApi.Models;

namespace Back.Redis.Business.Mappings
{
    public class PokemonMappingProfile : Profile
    {
        public PokemonMappingProfile()
        {
            CreateMap<PokemonResponse, PokemonResult>();
        }
    }
}