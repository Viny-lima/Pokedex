using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.PokeApi;

namespace Pokedex.Model.Entities
{

    public class PokemonDB : IEntity
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

        //Pokemon Criado com base em um elemento da API
        public PokemonDB(PokemonAPI pokemonAPI)
        {
            this.Abilities = new List<AbilityPokemonDB>();
            this.Moves = new List<MovePokemonDB>();
            this.Types = new List<TypePokemonDB>();

            var pokemonDB = new Entities.PokemonDB();
            pokemonDB.Id = pokemonAPI.Id;
            pokemonDB.Hp = pokemonAPI.StatusBase[0].ValueState;
            pokemonDB.Attack = pokemonAPI.StatusBase[1].ValueState;
            pokemonDB.SpritesFrontDefault = pokemonAPI.Sprites.FrontDefault;
            pokemonDB.SpritesOfficialArtwork = pokemonAPI.Sprites.Other.OfficialArtwork.FrontDefault;
            pokemonDB.Defense = pokemonAPI.StatusBase[2].ValueState;
            pokemonDB.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            pokemonDB.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            pokemonDB.Speed = pokemonAPI.StatusBase[5].ValueState;
            pokemonDB.Name = pokemonAPI.Name;
            pokemonDB.Height = pokemonAPI.Height;
            pokemonDB.Weight = pokemonAPI.Weight;
            pokemonDB.BaseExperience = pokemonAPI.BaseExperience;

            //Adicionando Abilities
            for (int i = 0; i < pokemonAPI.Abilities.Count; i++)
            {
                var abilityAPI = pokemonAPI.Abilities[i];
                var abilityDatabase = new Entities.AbilityDB()
                {
                    Name = abilityAPI.PropertiesAbility.Name
                };

                pokemonDB.AddAbility(abilityDatabase);
            }

            //Adicionando Moves
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                var moveAPI = pokemonAPI.Moves[i];
                var moveDB = new Entities.MoveDB()
                {
                    Name = moveAPI.Move.Name
                };

                pokemonDB.AddMove(moveDB);
            }

            //Adicionando Types
            for (int i = 0; i < pokemonAPI.Types.Count; i++)
            {
                var typeAPI = pokemonAPI.Types[i];
                var typrDB = new Entities.TypeDB()
                {
                    Name = typeAPI.Type.Name
                };

                pokemonDB.AddType(typrDB);
            }
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