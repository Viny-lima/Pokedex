using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Service;

namespace Pokedex.Migrations.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var contexto = new Model.DAO.PokemonDbContext())
            {
                contexto.Database.Migrate();
            }

            



        }
    }
}
