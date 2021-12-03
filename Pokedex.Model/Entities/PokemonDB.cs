using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Pokedex.Model.Entities
{

    public class PokemonDB
    {
        public int Id { get; set; }

        public int Hp { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SpecialAttack { get; set; }

        public int SpecialDefense { get; set; }

        public int Speed { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int BaseExperience { get; set; }

        public string SpritesFrontDefault { get; set; }

        public string SpritesOfficialArtwork { get; set; }

        public IList<AbilityPokemonDB> Abilities { get; internal set; }

        public IList<MovePokemonDB> Moves { get; internal set; }

        public IList<TypePokemonDB> Types { get; internal set; }

        public PokemonDB()
        {
            this.Abilities = new List<AbilityPokemonDB>();
            this.Moves = new List<MovePokemonDB>();
            this.Types = new List<TypePokemonDB>();
        }

        public void AddAbility(AbilityDB ability)
        {
            this.Abilities.Add(new AbilityPokemonDB() { Ability = ability });
        }

        public void AddMove(MoveDB move)
        {
            this.Moves.Add(new MovePokemonDB() { Move = move });
        }

        public void AddType(TypeDB type)
        {
            this.Types.Add(new TypePokemonDB() { Type = type });
        }

    }
}