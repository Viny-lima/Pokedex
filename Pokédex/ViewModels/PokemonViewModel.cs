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
        private Pokemon _pokemon = new Pokemon();
        public Pokemon MyPokemon { get { return _pokemon; } }

        public PokemonViewModel()
        {
            _pokemon = ApiRequest.GetPokemon(1);
        }

        public void Update(AddressPokemon pokemonSelected)
        {            
            _pokemon = ApiRequest.Get<Pokemon>(pokemonSelected.Url);
        }
    }
}
