namespace Pokedex.Model.Entities
{
    public class TypePokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int TypeId { get; set; }
        public TypeDB Type { get; set; }
    }
}
