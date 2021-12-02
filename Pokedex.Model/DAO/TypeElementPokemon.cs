namespace Pokedex.Model.DAO
{
    public class TypeElementPokemon
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int TypeId { get; set; }
        public TypeElement Type { get; set; }
    }
}
