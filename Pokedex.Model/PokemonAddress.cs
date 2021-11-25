using Newtonsoft.Json;
using System;

namespace Pokedex.Model
{
    public class PokemonAddress 
    {
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
                string id = Url.ToString(); //https://pokeapi.co/api/v2/pokemon/1/

                id = id.Substring(0, id.Length - 1); //https://pokeapi.co/api/v2/pokemon/1
                id = id.Substring(id.LastIndexOf("/")); //1

                string UrlImagem = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";

                return UrlImagem;
            }
        }
    }
}
