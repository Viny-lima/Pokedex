﻿using Pokedex.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model
{
    class CovertPoke : IConvertDatabaseApi
    {
        public PokemonDb ConvertPokemon(Pokemon pokemonAPI)
        {
            var pokemon = new PokemonDb();

            pokemon.Id = pokemonAPI.Id;
            pokemon.Hp = pokemonAPI.StatusBase[0].ValueState;
            pokemon.Attack = pokemonAPI.StatusBase[1].ValueState;
            pokemon.SpritesFrontDefault = pokemonAPI.Sprites.FrontDefault;
            pokemon.SpritesOfficialArtwork = pokemonAPI.Sprites.Other.OfficialArtwork.FrontDefault;

            pokemon.Moves = pokemonAPI.Moves;

            return pokemon;
        }
    }
}
