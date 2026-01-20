using Back.Redis.Data.Integrations.V2.PokeApi.Models;
using Refit;

namespace Back.Redis.Data.Integrations.V2.PokeApi.Clients
{
    public interface IPokemonClient
    {
        [Get("/{name}")]
        public Task<PokemonResponse> GetByNameOrId(string nameOrId);
    }
}