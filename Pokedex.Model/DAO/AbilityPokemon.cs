namespace Pokedex.Model.DAO
{
    public class AbilityPokemon
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
