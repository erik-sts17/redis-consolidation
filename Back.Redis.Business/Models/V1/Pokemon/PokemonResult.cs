namespace Back.Redis.Business.Models.V1.Pokemon
{
    public class PokemonResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}