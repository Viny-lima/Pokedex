using Pokedex.Model.Exceptions;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceFindById
    {
        [Fact]
        public async void RetornePokemonDoIdInformado()
        {
            //Arrange
            var id = 25;
            var service = new PokemonService();

            //Act
            var pokemon = await service.FindById(id);

            //Assert
            var valorEsperado = id;
            var valorObtido = pokemon.Id;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public async void LancePokemonNotFoundExceptionQuandoNaoEncontrar()
        {
            //arrange
            var id = 0;
            var service = new PokemonService();

            // act & assert
            await Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindById(id));
        }
    }
}
