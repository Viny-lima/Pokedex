using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Exceptions
{
    public class PokemonTypeNotFoundException : Exception
    {
        public PokemonTypeNotFoundException() { }

        public PokemonTypeNotFoundException(string message) : base(message) { }

        public PokemonTypeNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
