using Back.Redis.Business.Mappings;

namespace Back.Redis.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddMappings(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(PokemonMappingProfile));
        }
    }
}
