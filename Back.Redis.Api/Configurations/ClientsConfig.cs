using Back.Redis.Data.Integrations.V2.PokeApi.Clients;
using Refit;

namespace Back.Redis.Api.Configurations
{
    public static class ClientsConfig
    {
        public static void AddClients(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddRefitClient<IPokemonClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(GetV2PokemonUrl(configuration) + "pokemon"));
        }

        private static string GetV2PokemonUrl (IConfiguration configuration) =>
            configuration["Clients:Pokemon:Url"]! + "/api/v2/";
    }
}