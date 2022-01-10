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
    public class ApiRequestGetPokemonListByType
    {

        [Theory]
        [InlineData("normal", 130)]
        [InlineData("fighting", 78)]
        [InlineData("flying", 135)]
        [InlineData("dragon", 78)]
        public void DadoNomeDoTipoDeveRetornarUmaListaComPokemonsDaqueleTipo(string nome, int quantidade)
        {
            //Arrange
            var _nome = nome;
            var _quantidade = quantidade;

            //Act
            var resultado = ApiRequest.GetPokemonsListByType(_nome);

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }
        
        [Theory]
        [InlineData("normal", "vigoroth")]
        [InlineData("fighting", "pangoro")]
        [InlineData("flying", "pelipper")]
        [InlineData("dragon", "kommo-o")]
        public void DadoNomeDoTipoDeveRetornarUmaListaContendoPokemonDaqueleTipo(string nome, string nomePokemon)
        {
            //Arrange
            var _nome = nome;
            var _nomePokemon = nomePokemon;

            //Act
            var resultado = ApiRequest.GetPokemonsListByType(_nome);

            //Assert
            Assert.True(resultado.Any(p => p.Name == _nomePokemon));
        }


    }
}
