using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.Tests.Startup;
using Xunit;

namespace Pokedex.Tests
{

    [Collection("Database")]
    public class PokemonServiceHelperSetId
    {
        DatabaseFixture _databaseFixture;

        public PokemonServiceHelperSetId(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

        [Fact]
        public async void RealizeAlteracaoNoId()
        {
            //Arrange

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

            //Act
            await pokemon.SetId();

            //Assert
            Assert.True(pokemon.Id >= 100001);

        }
    }
}
