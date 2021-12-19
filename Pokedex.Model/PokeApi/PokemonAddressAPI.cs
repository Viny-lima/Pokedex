using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Pokedex.Model.PokeApi
{
    public class PokemonAddressAPI 
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        private string _name;
        public string NamePokemon
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        [JsonProperty("url")]
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }

        public string SpriteUrl
        {
            get
            {
                string UrlImagem = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";

                return UrlImagem;
            }
        }

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
