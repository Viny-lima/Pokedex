using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonServiceHelperSearchAPI

    {
        [Theory]
        [InlineData(25)]
        [InlineData(20)]
        [InlineData(2)]

        public void RetorneResultadoDeBuscaPorId(int search)
        {
            //arrange
            var id = search;

            //act
            var pokemon = PokemonServiceHelper.SearchAPI(id);

            //assert
            var valorEsperado = id;
            var valorObtido = pokemon.Id;
            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
