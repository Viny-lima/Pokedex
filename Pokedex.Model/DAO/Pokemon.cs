using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Pokedex.Model.DAO
{

    public class Pokemon
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

        public IList<AbilityPokemon> Abilities { get; internal set; }

        public IList<MovePokemon> Moves { get; internal set; }

        public IList<TypeElementPokemon> Types { get; internal set; }

        public Pokemon()
        {
            this.Abilities = new List<AbilityPokemon>();
            this.Moves = new List<MovePokemon>();
            this.Types = new List<TypeElementPokemon>();
        }

        public void AddAbility(Ability ability)
        {
            this.Abilities.Add(new AbilityPokemon() { Ability = ability });
        }

        public void AddMove(Move move)
        {
            this.Moves.Add(new MovePokemon() { Move = move });
        }

        public void AddType(TypeElement type)
        {
            this.Types.Add(new TypeElementPokemon() { Type = type });
        }

    }
}