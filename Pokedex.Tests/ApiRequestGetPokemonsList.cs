using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class ApiRequestGetPokemonsList
    {

        [Theory]
        [InlineData(1, 10)]
        [InlineData(5, 7)]
        [InlineData(890, 10)]
        public void RetornarQuantidadeInformada(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }

        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10001, 7)]
        public void RetornarListaVaziaQuandoNaoExistirNaApi(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = 0;
            Assert.Equal(esperado, resultado.Count);
        }

        [Theory]
        [InlineData(1, -100)]
        [InlineData(100, -1000)]
        public void RetornarQtdApiMenosQtdInformadaQuandoQuantidadeForNegativa(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;
            var totalDePokemonsDaApi = ApiRequest.GetPokemonCount();

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = totalDePokemonsDaApi + _quantidade;
            Assert.Equal(esperado, resultado.Count);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(100, 110)]
        [InlineData(0, 110)]
        [InlineData(897, 1)]
        public void UltimoPokemonDeveTerIdIgualQtdMaisInicio(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = _inicio + _quantidade;
            Assert.Equal(esperado, resultado.Last().Id);
        }

        [Theory]
        [InlineData(898, 1)]
        [InlineData(1000, 100)]
        [InlineData(1117, 1)]
        public void SeMaiorQue897IdDoPokemonDeveSerMaiorDezMilMaisQtd(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var variacaoAPartirDe898 = inicio - 898;
            var esperado = 10000 + _quantidade + variacaoAPartirDe898;
            Assert.Equal(esperado, resultado.Last().Id);
        }


    }
}
