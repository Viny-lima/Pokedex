using Microsoft.EntityFrameworkCore;
using System;
using Pokedex.Model.Service;
using Pokedex.Model.Entities;
using Pokedex.Model.DAO;
using Pokedex.Model.Connection;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new PokedexContext();

            p.Database.EnsureDeleted();
            p.Database.Migrate();         

            
            var a = new AbilityDB() { Id = 1 ,Name = "o"};
            var b = new AbilityDB() { Id = 1 ,Name = "o"};
            

            if(Equals(a, b))
            {
                Console.WriteLine("São iguais o teste ta bugado!");
            }
            else
            {
                Console.WriteLine("Tu ta fazendo errado !");
            }
            

        }

        private static void AdicionandoSemDuplicidade()
        {
            using (var contexto = new PokedexContext())
            {
                contexto.Database.Migrate();
            }

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
                if (pokemon.Types != null)
                {
                    foreach (var pk in pokemon.Types)
                    {
                        Console.WriteLine("type: " + pk.Type.Name);
                    }
                }
                Console.WriteLine("----------------------------");
            }
        }

    }
}