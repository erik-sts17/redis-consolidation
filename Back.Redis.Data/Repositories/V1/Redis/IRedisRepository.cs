namespace Back.Redis.Data.Repositories.V1.Redis
{
    public interface IRedisRepository
    {
        Task SetAsync(string key, string value, TimeSpan? expiry = null);
        Task<string?> GetAsync(string key);
        Task<bool> DeleteAsync(string key);
    }
}