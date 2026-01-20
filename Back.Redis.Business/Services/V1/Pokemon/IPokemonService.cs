using Back.Redis.Business.Models.V1.Pokemon;

namespace Back.Redis.Business.Services.V1.Pokemon
{
    public interface IPokemonService
    {
        public Task<PokemonResult?> GetByNameOrId(string nameOrId);
    }
}