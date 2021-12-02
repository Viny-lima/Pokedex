using Pokedex.Model.DAO;
using Pokedex.Model.Interfaces;
using Pokedex.Model.PokeApi;
using System.Collections;
using System.Collections.Generic;

namespace Pokedex.Model.Service
{
    public static class  CovertModelDatabase 
    {
        public static void AddPokemonDatabase(PokeApi.Pokemon pokemonAPI)
        {
            var pokemonDatabase = new DAO.Pokemon();
            pokemonDatabase.Id = pokemonAPI.Id;
            pokemonDatabase.Hp = pokemonAPI.StatusBase[0].ValueState;
            pokemonDatabase.Attack = pokemonAPI.StatusBase[1].ValueState;
            pokemonDatabase.SpritesFrontDefault = pokemonAPI.Sprites.FrontDefault;
            pokemonDatabase.SpritesOfficialArtwork = pokemonAPI.Sprites.Other.OfficialArtwork.FrontDefault;
            pokemonDatabase.Defense = pokemonAPI.StatusBase[2].ValueState;
            pokemonDatabase.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            pokemonDatabase.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            pokemonDatabase.Speed = pokemonAPI.StatusBase[5].ValueState;
            pokemonDatabase.Name = pokemonAPI.Name;
            pokemonDatabase.Height = pokemonAPI.Height;
            pokemonDatabase.Weight = pokemonAPI.Weight;
            pokemonDatabase.BaseExperience = pokemonAPI.BaseExperience;

            //Adicionando Abilities
            for (int i = 0; i < pokemonAPI.Abilities.Count; i++)
            {
                var abilityAPI = pokemonAPI.Abilities[i];
                var abilityDatabase = new DAO.Ability()
                {
                    Name = abilityAPI.PropertiesAbility.Name          
                };

                pokemonDatabase.AddAbility(abilityDatabase);
            }

            //Adicionando Moves
            for (int i = 0; i < pokemonAPI.Moves.Count; i++)
            {
                var moveAPI = pokemonAPI.Moves[i];
                var moveDB = new DAO.Move()
                {
                    Name = moveAPI.Move.Name
                };

                pokemonDatabase.AddMove(moveDB);
            }

            //Adicionando Types
            for (int i = 0; i < pokemonAPI.Types.Count; i++)
            {
                var typeAPI = pokemonAPI.Types[i];
                var typrDB = new DAO.TypeElement()
                {
                    Name = typeAPI.Type.Name
                };

                pokemonDatabase.AddType(typrDB);
            }

            using (var contexto = new PokemonDbContext())
            {
                contexto.Pokemons.Add(pokemonDatabase);                
                contexto.SaveChanges();
            }
            
        }
    }
}
