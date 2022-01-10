using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;
using System;
using Xunit;

namespace Pokedex.Tests
{
    public class ApiRequestGetPokemon
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RetornaNullQuandoNotFoundString(String search)
        {
            //Arrange
            String idOrName = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(idOrName);

            //Assert
            var resultadoObtido = pokemonAPI;

            Assert.Null(resultadoObtido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9000000)]
        [InlineData(-100)]
        public void RetornaNullQuandoNotFoundInt(int search)
        {
            //Arrange
            var id = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(id);

            //Assert
            var resultadoObtido = pokemonAPI;

            Assert.Null(resultadoObtido);
        }



        [Theory]
        [InlineData("pikachu")]
        public void RetornaResultadoDeBuscaName(string search)
        {
            //Arrange
            var name = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(name);

            //Assert
            var resultadoEsperado = search;
            var resultadoObtido = pokemonAPI.Name;

            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(100)]
        [InlineData(10001)]
        public void RetornaResultadoDeBuscaId(int search)
        {
            //Arrange
            var id = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(id);

            //Assert
            var resultadoEsperado = search;
            var resultadoObtido = pokemonAPI.Id;

            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

    }
}
