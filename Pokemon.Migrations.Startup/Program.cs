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

            MostrarPokemons();

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

            foreach (var pokemons in db.FindAll().Result)
            {
                foreach (var type in pokemons.Types)
                {
                    Console.Write(type.Type.Name + " / ");
                }
                Console.WriteLine("");
            }
        }
        
        private static void MostrarPokemons()
        {
            var db = new PokemonDAO();

            foreach (var pokemon in db.FindAll().Result)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(pokemon.Id);
                Console.WriteLine(pokemon.Name);
                Console.WriteLine(pokemon.Height);
                Console.WriteLine(pokemon.Weight);
                Console.WriteLine(pokemon.Hp);
                Console.WriteLine(pokemon.Attack);
                Console.WriteLine(pokemon.SpecialAttack);
                Console.WriteLine(pokemon.Defense);
                Console.WriteLine(pokemon.SpecialDefense);
                Console.WriteLine(pokemon.Speed);
                Console.WriteLine("---------------------------");
            }
        }

    }
}
