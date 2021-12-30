using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException() { }

        public PokemonNotFoundException(string message) : base(message) { }

        public PokemonNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
