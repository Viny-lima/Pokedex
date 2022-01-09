using Pokedex.Model.Enums;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceFindAllByType
    {
        [Theory]
        [InlineData(TypeNames.normal, 130)]
        [InlineData(TypeNames.fighting, 78)]
        [InlineData(TypeNames.flying, 135)]
        [InlineData(TypeNames.dragon, 78)]
        public void DadoNomeDoTipoDeveRetornarUmaListaComPokemonsDaqueleTipo(TypeNames nome, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _nome = nome;
            var _quantidade = quantidade;

            //Act
            var resultado = service.FindAllByType(_nome, 1, _quantidade).Result;

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }

        [Theory]
        [InlineData(TypeNames.normal, "rattata")]
        [InlineData(TypeNames.fighting, "tyrogue")]
        [InlineData(TypeNames.flying, "pidgey")]
        [InlineData(TypeNames.dragon, "dratini")]
        public async void DadoNomeDoTipoDeveRetornarUmaListaContendoPokemonDaqueleTipo(TypeNames nome, string nomePokemon)
        {
            //Arrange
            var service = new PokemonService();
            var _nome = nome;
            var _nomePokemon = nomePokemon;

            //Act
            var resultado = await service.FindAllByType(_nome , 1, 10);

            //Assert
            Assert.True(resultado.Any(p => p.Name == _nomePokemon));
        }
    }
}
