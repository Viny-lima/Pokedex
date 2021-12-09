using Microsoft.EntityFrameworkCore;
using System;
using Pokedex.Model.Service;
using Pokedex.Model.Entities;
using Pokedex.Model.DAO;
using System.Collections.Generic;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemonDAO = new PokemonDAO();

            IList<PokemonDB> ListaPokemons = pokemonDAO.FindAll().Result;

            foreach (var p in ListaPokemons)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.SpritesFrontDefault + "\n");
            }
        }

        private static void AdicionandoSemDuplicidade()
        {          
            using(var contexto = new PokedexContext())
            {
                contexto.Database.Migrate();
            }

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
