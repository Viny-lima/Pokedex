﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;

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

        public PokemonDB(int id, string name)
        {
            this.Abilities = new List<AbilityPokemonDB>();
            this.Moves = new List<MovePokemonDB>();
            this.Types = new List<TypePokemonDB>();

            this.Id = id;
            this.Name = name;
            this.SpritesOfficialArtwork = $"{UrlConstants.SpriteUrl}{UrlConstants.ArtworkEndpoint}{this.Id}{UrlConstants.SpriteExtension}";
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
            this.SpritesFrontDefault = $"{UrlConstants.SpriteUrl}{this.Id}{UrlConstants.SpriteExtension}";
            this.SpritesOfficialArtwork = $"{UrlConstants.SpriteUrl}{UrlConstants.ArtworkEndpoint}{this.Id}{UrlConstants.SpriteExtension}";
            this.Defense = pokemonAPI.StatusBase[2].ValueState;
            this.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            this.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            this.Speed = pokemonAPI.StatusBase[5].ValueState;
            this.Name = pokemonAPI.Name;
            this.Height = pokemonAPI.Height;
            this.Weight = pokemonAPI.Weight;
            this.BaseExperience = pokemonAPI.BaseExperience;

            AddTypesAPI(pokemonAPI);
            AddMovesAPI(pokemonAPI);
            AddAbilitiesAPI(pokemonAPI);
        }  

        private async void AddTypesAPI(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Types.Count; i++)
            {
                await AddType(pokemonAPI.Types[i].Type.Name);
            }      
        }       

        private async void AddMovesAPI(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                await AddMove(pokemonAPI.Moves[i].Move.Name);
            }            
        }

        private async void AddAbilitiesAPI(PokemonAPI pokemonAPI)
        {
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                await AddAbility(pokemonAPI.Moves[i].Move.Name);
            }
        }

        public Task AddType(string typeName)
        {
            var db = new TypeDAO();
            var typeDB = new TypeDB() { Name = typeName };

            if (db.Exists(typeDB))
            {
                typeDB = db.FindAll().Result.FirstOrDefault(p => p.Name == typeDB.Name);

                Types.Add(new TypePokemonDB() { PokemonId = this.Id, TypeId = typeDB.Id });
            }
            else
            {
                Types.Add(new TypePokemonDB() { PokemonId = this.Id, Type = typeDB });
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