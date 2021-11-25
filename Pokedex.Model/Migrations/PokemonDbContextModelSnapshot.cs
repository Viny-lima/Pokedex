﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.Model;

namespace Pokedex.Model.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("Pokedex.Model.PokeApi.Ability", b =>
                {
                    b.Property<int>("Id_Ability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PropertiesAbilityId_PropertiesAbility")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Slot")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Ability");

                    b.HasIndex("PokemonId");

                    b.HasIndex("PropertiesAbilityId_PropertiesAbility");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.DreamWorld", b =>
                {
                    b.Property<int>("Id_DreamWorld")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FrontDefault")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_DreamWorld");

                    b.ToTable("DreamWorld");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Moves", b =>
                {
                    b.Property<int>("Id_Moves")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MoveId_PropertiesMove")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Moves");

                    b.HasIndex("MoveId_PropertiesMove");

                    b.HasIndex("PokemonId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.OfficialArtwork", b =>
                {
                    b.Property<int>("Id_OfficialArtwork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FrontDefault")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_OfficialArtwork");

                    b.ToTable("OfficialArtwork");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Other", b =>
                {
                    b.Property<int>("Id_Other")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DreamWorldId_DreamWorld")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OfficialArtworkId_OfficialArtwork")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Other");

                    b.HasIndex("DreamWorldId_DreamWorld");

                    b.HasIndex("OfficialArtworkId_OfficialArtwork");

                    b.ToTable("Other");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.PropertiesAbility", b =>
                {
                    b.Property<int>("Id_PropertiesAbility")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_PropertiesAbility");

                    b.ToTable("PropertiesAbility");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.PropertiesMove", b =>
                {
                    b.Property<int>("Id_PropertiesMove")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id_PropertiesMove");

                    b.ToTable("PropertiesMove");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Sprites", b =>
                {
                    b.Property<int>("Id_Sprites")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FrontDefault")
                        .HasColumnType("TEXT");

                    b.Property<string>("FrontShiny")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OtherId_Other")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Sprites");

                    b.HasIndex("OtherId_Other");

                    b.ToTable("Sprites");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Stats", b =>
                {
                    b.Property<int>("Id_Stats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("EffortState")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PropertiesStateId_PropertiesAbility")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ValueState")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_Stats");

                    b.HasIndex("PokemonId");

                    b.HasIndex("PropertiesStateId_PropertiesAbility");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.TypeElement", b =>
                {
                    b.Property<int>("Id_TypeElement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Slot")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId_PropertiesAbility")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_TypeElement");

                    b.HasIndex("PokemonId");

                    b.HasIndex("TypeId_PropertiesAbility");

                    b.ToTable("TypeElement");
                });

            modelBuilder.Entity("Pokedex.Model.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseExperience")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SpritesId_Sprites")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpritesId_Sprites");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Ability", b =>
                {
                    b.HasOne("Pokedex.Model.Pokemon", null)
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId");

                    b.HasOne("Pokedex.Model.PokeApi.PropertiesAbility", "PropertiesAbility")
                        .WithMany()
                        .HasForeignKey("PropertiesAbilityId_PropertiesAbility");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Moves", b =>
                {
                    b.HasOne("Pokedex.Model.PokeApi.PropertiesMove", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId_PropertiesMove");

                    b.HasOne("Pokedex.Model.Pokemon", null)
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Other", b =>
                {
                    b.HasOne("Pokedex.Model.PokeApi.DreamWorld", "DreamWorld")
                        .WithMany()
                        .HasForeignKey("DreamWorldId_DreamWorld");

                    b.HasOne("Pokedex.Model.PokeApi.OfficialArtwork", "OfficialArtwork")
                        .WithMany()
                        .HasForeignKey("OfficialArtworkId_OfficialArtwork");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Sprites", b =>
                {
                    b.HasOne("Pokedex.Model.PokeApi.Other", "Other")
                        .WithMany()
                        .HasForeignKey("OtherId_Other");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.Stats", b =>
                {
                    b.HasOne("Pokedex.Model.Pokemon", null)
                        .WithMany("StatusBase")
                        .HasForeignKey("PokemonId");

                    b.HasOne("Pokedex.Model.PokeApi.PropertiesAbility", "PropertiesState")
                        .WithMany()
                        .HasForeignKey("PropertiesStateId_PropertiesAbility");
                });

            modelBuilder.Entity("Pokedex.Model.PokeApi.TypeElement", b =>
                {
                    b.HasOne("Pokedex.Model.Pokemon", null)
                        .WithMany("Types")
                        .HasForeignKey("PokemonId");

                    b.HasOne("Pokedex.Model.PokeApi.PropertiesAbility", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId_PropertiesAbility");
                });

            modelBuilder.Entity("Pokedex.Model.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Model.PokeApi.Sprites", "Sprites")
                        .WithMany()
                        .HasForeignKey("SpritesId_Sprites");
                });
#pragma warning restore 612, 618
        }
    }
}
