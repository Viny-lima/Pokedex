using Microsoft.EntityFrameworkCore;
using System;
using Pokedex.Model.Service;
using Pokedex.Model.Entities;
using Pokedex.Model.DAO;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemonDAO = new PokemonDAO();

            var p = pokemonDAO.FindById(1).Result;

            Console.WriteLine(p.Types[0].Type.Name);

        }

        private static void AdicionandoSemDuplicidade()
        {          
            var pokemonDAO = new PokemonDAO();

            for (int i = 1; i < 10; i++)
            {
                var p = new PokemonDB(ApiRequest.GetPokemon(i));
                pokemonDAO.Add(p);
            }
            
        }

        private static void MostrarTiposDosPokemonsNoDatabase()
        {
            var db = new PokemonDAO();

            foreach (var pokemons in db.FindAll().Result)
            {
                foreach (var type in pokemons.Types)
                {
                    Console.Write(type.Type.Name + " / ");
                }
                Console.WriteLine("");
            }
        }

    }
}
