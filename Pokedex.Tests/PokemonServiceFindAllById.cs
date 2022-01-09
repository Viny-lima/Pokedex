using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceFindAllById
    {
        [Theory]
        [InlineData(1, 10)]
        [InlineData(5, 7)]
        [InlineData(890, 10)]
        public async void RetornarQuantidadeInformada(int inicio, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = await service.FindAllById(_inicio, _quantidade);

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }

        [Theory]
        [InlineData(25000, 10)]
        [InlineData(57000, 7)]
        public async void RetornarListaVaziaQuandoNaoExistir(int inicio, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act            
            var resultado = await service.FindAllById(_inicio, _quantidade);

            //Assert
            var esperado = 0;
            Assert.Equal(esperado, resultado.Count);
        }        

        [Theory]
        [InlineData(0, 10)]
        [InlineData(100, 110)]
        [InlineData(0, 110)]
        [InlineData(897, 1)]
        public async void UltimoPokemonDeveTerIdIgualQtdMaisInicioMenosUm(int inicio, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = await service.FindAllById(_inicio, _quantidade);

            //Assert
            var esperado = _inicio + _quantidade -1;
            Assert.Equal(esperado, resultado.Last().Id);
        }        

    }
}
