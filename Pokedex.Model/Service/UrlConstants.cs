using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Service
{
    static class UrlConstants
    {
        public static string BaseUrl = "https://pokeapi.co/api/v2/";
        public static string SpriteUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";
        public static string PokemonEndpoint = "pokemon/";
        public static string TypeEndpoint = "type/";
        public static string ArtworkEndpoint = "other/official-artwork/";
        public static string SpriteExtension = ".png";
    }
}
