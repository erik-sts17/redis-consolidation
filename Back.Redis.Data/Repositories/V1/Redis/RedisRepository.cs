using StackExchange.Redis;

namespace Back.Redis.Data.Repositories.V1.Redis
{
    public class RedisRepository(IConnectionMultiplexer redis) : IRedisRepository
    {
        private readonly IDatabase _db = redis.GetDatabase();

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            await _db.StringSetAsync(key, value, expiry);
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            return await _db.KeyDeleteAsync(key);
        }
    }
}