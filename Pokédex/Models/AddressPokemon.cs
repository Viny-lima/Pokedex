using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Pokedex.Models
{
    public class AddressPokemon 
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
        private Uri _url;
        public Uri Url
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
