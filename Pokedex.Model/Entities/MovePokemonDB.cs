namespace Pokedex.Model.Entities
{
    public class MovePokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int MoveId { get; set; }
        public MoveDB Move { get; set; }

    }
}
