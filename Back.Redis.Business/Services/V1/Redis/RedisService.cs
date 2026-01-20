using Back.Redis.Data.Repositories.V1.Redis;
using System.Text.Json;

namespace Back.Redis.Business.Services.V1.Redis
{
    public class RedisService(IRedisRepository redisRepository) : IRedisService
    {
        private readonly IRedisRepository _redisRepository = redisRepository;
        public async Task<T?> GetDataAsync<T>(string cacheKey) where T : class    
        {
            var cache = await _redisRepository.GetAsync(cacheKey);
            if (cache != null)
                return JsonSerializer.Deserialize<T>(cache);

            return null;
        }

        public async Task SetDataCache(string cacheKey, object result, TimeSpan? expiry) 
        {
            await _redisRepository.SetAsync(cacheKey, JsonSerializer.Serialize(result), expiry ?? TimeSpan.FromDays(1));
        }
    }
}