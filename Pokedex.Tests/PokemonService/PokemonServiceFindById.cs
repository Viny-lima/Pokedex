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
    public class PokemonServiceFindById
    {

        DatabaseFixture _databaseFixture;

        public PokemonServiceFindById(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

        [Fact]
        public void RetornePokemonDoIdInformado()
        {
            //Arrange
            var id = 25;
            var service = new PokemonService();

            //Act
            var pokemon = service.FindById(id).Result;

            //Assert
            var valorEsperado = id;
            var valorObtido = pokemon.Id;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancePokemonNotFoundExceptionQuandoNaoEncontrar()
        {
            //arrange
            var id = 0;
            var service = new PokemonService();

            // act & assert
            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindById(id));
        }
    }
}
