using Microsoft.EntityFrameworkCore;

namespace Pokedex.Model
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<PokemonDb> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataPokemon.db");
        }             
    }
    
}
