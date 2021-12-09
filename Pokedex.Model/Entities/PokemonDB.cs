using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
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

            this.Id = pokemonAPI.Id;
            this.Hp = pokemonAPI.StatusBase[0].ValueState;
            this.Attack = pokemonAPI.StatusBase[1].ValueState;
            this.SpritesFrontDefault = pokemonAPI.Sprites.FrontDefault;
            this.SpritesOfficialArtwork = pokemonAPI.Sprites.Other.OfficialArtwork.FrontDefault;
            this.Defense = pokemonAPI.StatusBase[2].ValueState;
            this.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            this.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            this.Speed = pokemonAPI.StatusBase[5].ValueState;
            this.Name = pokemonAPI.Name;
            this.Height = pokemonAPI.Height;
            this.Weight = pokemonAPI.Weight;
            this.BaseExperience = pokemonAPI.BaseExperience;

            AddTypes(pokemonAPI);
            AddMoves(pokemonAPI);
            AddAbilities(pokemonAPI);
        }  

        private async void AddTypes(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Types.Count; i++)
            {
                await ToCheckAndAdd(i);
            }      
            
            Task ToCheckAndAdd(int i)       
            {
                var db = new TypeDAO();
                var typeDB = new TypeDB() { Name = pokemonAPI.Types[i].Type.Name };                                              

                if (db.Exists(typeDB))
                {
                    typeDB = db.FindAll().Result.FirstOrDefault(p => p.Name == typeDB.Name);

                    Types.Add(new TypePokemonDB() { TypeId = typeDB.Id });
                }
                else
                {
                    Types.Add(new TypePokemonDB() { Type = typeDB });
                }

                return Task.CompletedTask;
            }
        }

        private async void AddMoves(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                await ToCheckAndAdd(i);
            }

            Task ToCheckAndAdd(int i)
            {
                var db = new MoveDAO();
                var moveDB = new MoveDB() { Name = pokemonAPI.Moves[i].Move.Name };

                if (db.Exists(moveDB))
                {
                    moveDB = db.FindAll().Result.FirstOrDefault(p => p.Name == moveDB.Name);

                    Moves.Add(new MovePokemonDB() { MoveId = moveDB.Id});
                }
                else
                {
                    Moves.Add(new MovePokemonDB() { Move = moveDB });
                }

                return Task.CompletedTask;
            }
        }

        private async void AddAbilities(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                await ToCheckAndAdd(i);
            }

            Task ToCheckAndAdd(int i)
            {
                var db = new AbilityDAO();
                var abilityDB = new AbilityDB() { Name = pokemonAPI.Moves[i].Move.Name };

                if (db.Exists(abilityDB))
                {
                    abilityDB = db.FindAll().Result.FirstOrDefault(p => p.Name == abilityDB.Name);
                    Abilities.Add(new AbilityPokemonDB() { AbilityId = abilityDB.Id });
                }
                else
                {
                    Abilities.Add(new AbilityPokemonDB() { Ability = abilityDB });
                }

                return Task.CompletedTask;
            }
        }

    }
}