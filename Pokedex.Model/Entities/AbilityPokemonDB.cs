namespace Pokedex.Model.Entities
{
    public class AbilityPokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int AbilityId { get; set; }
        public AbilityDB Ability { get; set; }
    }
}
