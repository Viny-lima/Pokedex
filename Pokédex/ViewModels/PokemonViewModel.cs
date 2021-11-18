using Pokedex.Models;
using Pokedex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.ViewModels
{
    public class PokemonViewModel 
    {
        Pokemon _pokemon = new Pokemon();
        public Pokemon MyPokemon { get { return _pokemon; } }

        public PokemonViewModel(int IdPokemon)
        {
            _pokemon = ApiRequest.GetPokemon(IdPokemon);
        }

        public void Update(Pokemon pokemonSelected)
        {
            _pokemon = ApiRequest.GetPokemon(pokemonSelected.Id);
        }
    }
}
