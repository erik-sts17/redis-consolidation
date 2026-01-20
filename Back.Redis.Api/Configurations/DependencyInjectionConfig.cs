using Back.Redis.Business.Services.V1.Pokemon;
using Back.Redis.Business.Services.V1.Redis;
using Back.Redis.Data.Repositories.V1.Redis;

namespace Back.Redis.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddServices(this IServiceCollection services) 
        {
            //Services
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IRedisService, RedisService>();

            //Repositories
            services.AddScoped<IRedisRepository, RedisRepository>();
            services.AddScoped<IRedisRepository, RedisRepository>();
        }
    }
}
