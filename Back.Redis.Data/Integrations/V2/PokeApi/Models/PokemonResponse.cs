namespace Back.Redis.Data.Integrations.V2.PokeApi.Models
{
    public class PokemonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public TypeDetail[] Types { get; set; } = [];
        public Sprites Sprites { get; set; } = new();
    }
}
