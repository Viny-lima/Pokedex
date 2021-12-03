using Microsoft.EntityFrameworkCore;
using System;
using Pokedex.Model.Service;
using Pokedex.Model.DAO;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = ControllerDbContext.CreatePokemonDb(ApiRequest.GetPokemon(25));

            using(var contexto = new PokedexContext())
            {
                contexto.Pokemons.Add(p);
                contexto.SaveChanges();
            }
        }
    }
}
