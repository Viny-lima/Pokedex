using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    public interface IPokemonDAO
    {

        void AddPokemon(PokemonDB pokemonDB);
        void RemovePokemon(PokemonDB pokemonDB);
        void UpdatePokemon(PokemonDB pokemonDB);    
                       
    }
}
