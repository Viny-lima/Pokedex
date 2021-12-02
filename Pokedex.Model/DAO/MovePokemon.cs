namespace Pokedex.Model.DAO
{
    public class MovePokemon
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int MoveId { get; set; }
        public Move Move { get; set; }

    }
}
