using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Tests.Startup
{
    public class DatabaseFixture : IDisposable
    {
        PokedexContext context;
        public DatabaseFixture()
        {
            context = new PokedexContext();
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
