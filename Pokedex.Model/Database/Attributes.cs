using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Database
{
    public class Attributes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PokemonID { get; set; }

        public PokemonDb Pokemon { get; set; }
    }
}
