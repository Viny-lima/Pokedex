using Pokedex.Model.Entities;
using Pokedex.Model.Interfaces;
using Pokedex.Model.PokeApi;
using System.Collections;
using System.Collections.Generic;

namespace Pokedex.Model.Service
{
    public static class  ControllerDbContext 
    {
        public static PokemonDB CreatePokemonDb(PokemonAPI pokemonAPI)
        {
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

            return pokemonDB;
        }

    }
}
