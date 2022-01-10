using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests.Startup
{

    [CollectionDefinition("Database")]
    public class Collection : ICollectionFixture<DatabaseFixture>
    {
    }
}
