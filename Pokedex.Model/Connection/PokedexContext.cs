using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Entities;

namespace Pokedex.Model.Connection
{
    public class PokedexContext : DbContext
    {
        public DbSet<PokemonDB> Pokemons { get; set; }
        public DbSet<MoveDB> Moves { get; set; }
        public DbSet<AbilityDB> Abilities { get; set;}
        public DbSet<TypeDB>  Types { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataPokemon.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Criação das chaves compostas das tabelas join

            modelBuilder
                .Entity<AbilityPokemonDB>()
                .HasKey(p => new { p.AbilityId, p.PokemonId });

            modelBuilder
                .Entity<MovePokemonDB>()
                .HasKey(p => new { p.MoveId, p.PokemonId });            

            modelBuilder
                .Entity<TypePokemonDB>()
                .HasKey(p => new { p.TypeId, p.PokemonId});
                                


            base.OnModelCreating(modelBuilder);
        }

    }
    
}
