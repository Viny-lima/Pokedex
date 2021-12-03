﻿using Pokedex.Model.DAO;
using Pokedex.Model.PokeApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    public interface IConvertDatabaseApi
    {
        DAO.PokemonDB ConvertPokemon(PokeApi.PokemonAPI pokemonAPI);
    }
}
