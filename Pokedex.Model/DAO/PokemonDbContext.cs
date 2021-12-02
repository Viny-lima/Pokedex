using Microsoft.EntityFrameworkCore;

namespace Pokedex.Model.DAO
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Ability> Abilities { get; set;}
        public DbSet<TypeElement>  Types { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataPokemon.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Criação das chaves compostas das tabelas join

            modelBuilder
                .Entity<AbilityPokemon>()
                .HasKey(p => new { p.AbilityId, p.PokemonId });

            modelBuilder
                .Entity<MovePokemon>()
                .HasKey(p => new { p.MoveId, p.PokemonId });            

            modelBuilder
                .Entity<TypeElementPokemon>()
                .HasKey(p => new { p.TypeId, p.PokemonId});


            base.OnModelCreating(modelBuilder);
        }

    }
    
}
