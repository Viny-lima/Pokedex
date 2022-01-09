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
    public class PokemonServiceFindByName
    {
        [Fact]
        public async void RetornePokemonDoIdInformado()
        {
            //Arrange
            var name = "pikachu";
            var service = new PokemonService();

            //Act
            var pokemon = await service.FindByName(name);

            //Assert
            var valorEsperado = name;
            var valorObtido = pokemon.Name;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public async void LancePokemonNotFoundExceptionQuandoNaoEncontrar()
        {
            //arrange
            var name = "";
            var service = new PokemonService();

            // act & assert
            await Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindByName(name));
        }
    }
}
