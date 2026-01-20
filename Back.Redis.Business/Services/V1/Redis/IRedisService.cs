namespace Back.Redis.Business.Services.V1.Redis
{
    public interface IRedisService
    {
        public Task<T?> GetDataAsync<T>(string cacheKey) where T : class;
        Task SetDataCache(string cacheKey, object result, TimeSpan? expiry);
    }
}
