using Pokedex.Model.DAO;
using Pokedex.Model.Interfaces;
using Pokedex.Model.PokeApi;

namespace Pokedex.Model.Service
{
    class CovertPoke : IConvertDatabaseApi
    {
        public DAO.Pokemon ConvertPokemon(PokeApi.Pokemon pokemonAPI)
        {
            var pokemon = new DAO.Pokemon();

            pokemon.Id = pokemonAPI.Id;
            pokemon.Hp = pokemonAPI.StatusBase[0].ValueState;
            pokemon.Attack = pokemonAPI.StatusBase[1].ValueState;
            pokemon.SpritesFrontDefault = pokemonAPI.Sprites.FrontDefault;
            pokemon.SpritesOfficialArtwork = pokemonAPI.Sprites.Other.OfficialArtwork.FrontDefault;
            pokemon.Defense = pokemonAPI.StatusBase[2].ValueState;
            pokemon.SpecialAttack = pokemonAPI.StatusBase[3].ValueState;
            pokemon.SpecialDefense = pokemonAPI.StatusBase[4].ValueState;
            pokemon.Speed = pokemonAPI.StatusBase[5].ValueState;
            pokemon.Name = pokemonAPI.Name;
            pokemon.Height = pokemonAPI.Height;
            pokemon.Weight = pokemonAPI.Weight;
            pokemon.BaseExperience = pokemonAPI.BaseExperience;


            return pokemon;
        }
    }
}
