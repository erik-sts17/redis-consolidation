using StackExchange.Redis;

namespace Back.Redis.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddRedis(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
                        ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
        }
    }
}
