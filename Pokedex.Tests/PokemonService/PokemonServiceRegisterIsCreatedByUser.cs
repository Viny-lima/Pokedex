using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;
using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.Tests.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{

    [Collection("Database")]
    public class PokemonServiceRegisterIsCreatedByUser
    {
        DatabaseFixture _databaseFixture;

        public PokemonServiceRegisterIsCreatedByUser(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

        [Fact]
        public async void CadastrandoNovoPokemonEleDeTerRegistroNoDatabase()
        {      
            //Arrange            
            /*using(var db = new PokedexContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
            }*/

            var pokemon = new PokemonDB()
            {
                Name = "NomeTest",
                Hp = 100,
                Attack = 100,
                Defense = 100,
                Height = 100,                
                SpecialAttack = 100,
                SpecialDefense = 100,
                Speed = 100,
                BaseExperience = 100,
                IsComplete = true,
                IsCreatedByTheUser = true,
            };

            await pokemon.AddAbility("Ability Test");
            await pokemon.AddMove("Move Test");
            await pokemon.AddType("Type1 Test");
            await pokemon.AddType("Type2 Test");

            await pokemon.SetId();

            //Act
            await new PokemonService().RegisterIsCreatedByUser(pokemon);

            //Assert
            var pokemonObtido = new PokemonService().FindById(pokemon.Id).Result;
            var pokemonEsperado = pokemon;

            Assert.Equal(pokemonEsperado, pokemonObtido);

        }

    }
}
