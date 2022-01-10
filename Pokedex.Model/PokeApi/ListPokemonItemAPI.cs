using Newtonsoft.Json;
using Pokedex.Model.Service;
using System.Runtime.Serialization;

namespace Pokedex.Model.PokeApi
{
    public class ListPokemonItemAPI 
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [OnDeserialized]
        private void SetIdOnDeserialized(StreamingContext context)
        {
            string id = Url.ToString(); //ex: https://pokeapi.co/api/v2/pokemon/1/

            id = id.Substring(0, id.Length - 1); //ex: https://pokeapi.co/api/v2/pokemon/1
            id = id.Substring(id.LastIndexOf("/") + 1); //ex: 1

            this.Id = int.Parse(id);
        }
    }
}
