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
            //var p = new PokedexContext();
            //p.Database.Migrate();
            IPokemonService<PokemonDB> service = new PokemonService();

            var pokemon = service.FindPokemonById(215236).Result;

            Console.WriteLine(pokemon);
            //Console.WriteLine(pokemon.Attack);
            //Console.WriteLine(pokemon.Hp);
            //Console.WriteLine(pokemon.Height);

            MostrarPokemons();
            //MostrarTiposDosPokemonsNoDatabase();

        }

        private static void AdicionandoSemDuplicidade()
        {          
            var pokemonDAO = new PokemonDAO();

            for (int i = 100; i < 111; i++)
            {
                var p = new PokemonDB(ApiRequest.GetPokemon(i));
                pokemonDAO.Add(p);
            }
            
        }

        private static void MostrarTiposDosPokemonsNoDatabase()
        {
            var db = new PokemonDAO();

            Console.WriteLine("----------Types-------------");

            foreach (var pokemons in db.FindAll().Result)
            {
                Console.WriteLine(pokemons.Name);
                Console.Write("type:");
                foreach (var type in pokemons.Types)
                {
                    Console.WriteLine(type.Type.Name);
                }
                Console.WriteLine("------------------");
            }
        }
        
        private static void MostrarPokemons()
        {
            var db = new PokemonDAO();

            foreach (var pokemon in db.FindAll().Result)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("id: " + pokemon.Id);
                Console.WriteLine("name: " + pokemon.Name);
                Console.WriteLine("height: " + pokemon.Height);
                Console.WriteLine("weight: " + pokemon.Weight);
                Console.WriteLine("hp: " + pokemon.Hp);
                Console.WriteLine("attack: " + pokemon.Attack);
                Console.WriteLine("special attack: " + pokemon.SpecialAttack);
                Console.WriteLine("defense: " + pokemon.Defense);
                Console.WriteLine("special defense: " + pokemon.SpecialDefense);
                Console.WriteLine("speed: " + pokemon.Speed);
                Console.WriteLine("----------------------------");
            }
        }

    }
}
