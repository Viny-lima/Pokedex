using Microsoft.EntityFrameworkCore;
using System;
using Pokedex.Model.Service;
using Pokedex.Model.Entities;
using System.Linq;
using Pokedex.Model.DAO;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = new PokemonDB(ApiRequest.GetPokemon(25));

            using(var contexto = new PokedexContext())
            {

            }
        }
    }
}
