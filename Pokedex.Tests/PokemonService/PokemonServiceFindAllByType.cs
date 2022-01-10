using Pokedex.Model.Enums;
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
    public class PokemonServiceFindAllByType
    {
        DatabaseFixture _databaseFixture;

        public PokemonServiceFindAllByType(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

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
        public void DadoNomeDoTipoDeveRetornarUmaListaContendoPokemonDaqueleTipo(TypeNames nome, string nomePokemon)
        {
            //Arrange
            var service = new PokemonService();
            var _nome = nome;
            var _nomePokemon = nomePokemon;

            //Act
            var resultado = service.FindAllByType(_nome , 1, 10).Result;

            //Assert
            Assert.True(resultado.Any(p => p.Name == _nomePokemon));
        }

        [Theory]
        [InlineData(10, -1)]
        [InlineData(0, -1)]
        [InlineData(-10, 10)]
        public void LançaExcecaoQuandoPeloMenosUmDosValoresPassadosForemMenoresQueUm(int inicio, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await service.FindAllByType(TypeNames.normal, _inicio, _quantidade));
        }
    }
}
