using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;
using static Pokedex.Model.Service.UrlConstants;

namespace Pokedex.Model.Entities
{

    public class PokemonDB : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SpecialAttack { get; set; }

        public int SpecialDefense { get; set; }

        public int Speed { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int BaseExperience { get; set; }

        public string SpritesFrontDefault { get; set; }

        private string _spriteOfficialArtwork;

        public string SpritesOfficialArtwork
        {
            get
            {
                if (string.IsNullOrEmpty(_spriteOfficialArtwork))
                {
                    return "../Assets/Components/DEFAULT_POKEMON.png";
                }

                return _spriteOfficialArtwork;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _spriteOfficialArtwork = "../Assets/Components/DEFAULT_POKEMON.png";
                }
                else
                {
                    _spriteOfficialArtwork = value;
                }                           
            }
        }

        public IList<AbilityPokemonDB> Abilities { get; internal set; }

        public IList<MovePokemonDB> Moves { get; internal set; }

        public IList<TypePokemonDB> Types { get; internal set; }

        public PokemonDB() 
        {
            this.Abilities = new List<AbilityPokemonDB>();
            this.Moves = new List<MovePokemonDB>();
            this.Types = new List<TypePokemonDB>();
        }

        public PokemonDB(int id, string name)
        {
            this.Abilities = new List<AbilityPokemonDB>();
            this.Moves = new List<MovePokemonDB>();
            this.Types = new List<TypePokemonDB>();

            this.Id = id;
            this.Name = name;
            this.SpritesOfficialArtwork = $"{SpriteUrl}{ArtworkEndpoint}{this.Id}{SpriteExtension}";
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
            this.SpritesFrontDefault = $"{SpriteUrl}{this.Id}{SpriteExtension}";
            this.SpritesOfficialArtwork = $"{SpriteUrl}{ArtworkEndpoint}{this.Id}{SpriteExtension}";
            this.Defense = pokemonAPI.StatusBase[2].ValueState;
            this.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            this.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            this.Speed = pokemonAPI.StatusBase[5].ValueState;
            this.Name = pokemonAPI.Name;
            this.Height = pokemonAPI.Height;
            this.Weight = pokemonAPI.Weight;
            this.BaseExperience = pokemonAPI.BaseExperience;

            pokemonAPI.Types.ForEach(t => AddType(t.NamesType.Name));
            pokemonAPI.Moves.ForEach(m => AddMove(m.Move.Name));
            pokemonAPI.Abilities.ForEach(a => AddAbility(a.PropertiesAbility.Name));
        }

        public Task AddType(string typeName)
        {
            var db = new TypeDAO();
            var typeDB = db.FindByName(typeName).Result;

            if (typeDB != null)
            {
                if (!db.PokemonHasType(typeName, this.Id).Result)
                {
                    Types.Add(new TypePokemonDB() { TypeId = typeDB.Id });
                }
            }
            else
            {
                var typeToBeAdded = new TypeDB() { Name = typeName }; 
                Types.Add(new TypePokemonDB() { PokemonId = this.Id, Type = typeToBeAdded });
            }

            return Task.CompletedTask;
        }

        public Task AddMove(string moveName)
        {
            var db = new MoveDAO();
            var moveDB = new MoveDB() { Name = moveName };

            if (db.Exists(moveDB))
            {
                moveDB = db.FindAll().Result.FirstOrDefault(p => p.Name == moveDB.Name);

                Moves.Add(new MovePokemonDB() { MoveId = moveDB.Id });
            }
            else
            {
                Moves.Add(new MovePokemonDB() { Move = moveDB });
            }

            return Task.CompletedTask;
        }        

        public Task AddAbility(string abilityName)
        {
            var db = new AbilityDAO();
            var abilityDB = new AbilityDB() { Name = abilityName};

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