using Pokedex.Model.Exceptions;
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
    public class PokemonServiceFindByName
    {
        DatabaseFixture _databaseFixture;

        public PokemonServiceFindByName(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

        [Fact]
        public void RetornePokemonDoIdInformado()
        {
            //Arrange
            var name = "pikachu";
            var service = new PokemonService();

            //Act
            var pokemon = service.FindByName(name).Result;

            //Assert
            var valorEsperado = name;
            var valorObtido = pokemon.Name;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancePokemonNotFoundExceptionQuandoNaoEncontrar()
        {
            //arrange
            var name = "";
            var service = new PokemonService();

            // act & assert
            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindByName(name));
        }
    }
}
