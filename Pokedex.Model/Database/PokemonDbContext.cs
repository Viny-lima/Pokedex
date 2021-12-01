using Microsoft.EntityFrameworkCore;

namespace Pokedex.Model.Database
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<PokemonDb> Pokemons { get; set; }
        public DbSet<MovesDb> Moves { get; set; }
        public DbSet<AbilitiesDb> Abilities { get; set;}
        public DbSet<TypesDb>  Types { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataPokemon.db");
        }
        
    }
    
}
