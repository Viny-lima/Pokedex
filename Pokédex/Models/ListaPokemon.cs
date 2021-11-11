using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class ListaPokemon
    {

        [JsonProperty("count")]
        public long? TamanhoDaLista { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previus")]
        public Uri Previous { get; set; }

        [JsonProperty("results")]
        public List<Pokemon> Lista { get; set; }
    }
}
