using AutoMapper;
using Back.Redis.Business.Models.V1.Pokemon;
using Back.Redis.Business.Services.V1.Redis;
using Back.Redis.Data.Integrations.V2.PokeApi.Clients;

namespace Back.Redis.Business.Services.V1.Pokemon
{
    public class PokemonService(IPokemonClient pokemonClient, IRedisService redisService, IMapper mapper) : IPokemonService
    {
        private readonly IPokemonClient _pokemonClient = pokemonClient;
        private readonly IRedisService _redisService = redisService;
        private readonly IMapper _mapper = mapper;
        private const string CACHE_KEY = "PokeApi";

        public async Task<PokemonResult?> GetByNameOrId(string nameOrId)
        {
            var cacheKey = $"{CACHE_KEY}.NameOrId.{nameOrId}";
            var cache = await _redisService.GetDataAsync<PokemonResult>(cacheKey);

            if (cache != null)
                return cache;

            var result = _mapper.Map<PokemonResult>(await _pokemonClient.GetByNameOrId(nameOrId));
            await _redisService.SetDataCache(cacheKey, result, TimeSpan.FromDays(1));
            return result;
        }
    }
}