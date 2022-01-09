using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceSearchAPI

    {
        [Theory]
        [InlineData(25)]
        [InlineData(20)]
        [InlineData(2)]
        [InlineData(0)]

        public void RetorneResultadoDeBuscaPorId(int search)
        {
            //arrange
            var id = search;
            var service = new PokemonService();

            //act
            var pokemon = service.SearchAPI(id);

            //assert
            var valorEsperado = id;
            var valorObtido = pokemon.Id;
            Assert.Equal(valorEsperado,valorObtido);
        }

    }
}
