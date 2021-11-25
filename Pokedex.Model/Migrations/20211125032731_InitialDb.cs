using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Model.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DreamWorld",
                columns: table => new
                {
                    Id_DreamWorld = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontDefault = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamWorld", x => x.Id_DreamWorld);
                });

            migrationBuilder.CreateTable(
                name: "OfficialArtwork",
                columns: table => new
                {
                    Id_OfficialArtwork = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontDefault = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialArtwork", x => x.Id_OfficialArtwork);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesAbility",
                columns: table => new
                {
                    Id_PropertiesAbility = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesAbility", x => x.Id_PropertiesAbility);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesMove",
                columns: table => new
                {
                    Id_PropertiesMove = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesMove", x => x.Id_PropertiesMove);
                });

            migrationBuilder.CreateTable(
                name: "Other",
                columns: table => new
                {
                    Id_Other = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DreamWorldId_DreamWorld = table.Column<int>(nullable: true),
                    OfficialArtworkId_OfficialArtwork = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Other", x => x.Id_Other);
                    table.ForeignKey(
                        name: "FK_Other_DreamWorld_DreamWorldId_DreamWorld",
                        column: x => x.DreamWorldId_DreamWorld,
                        principalTable: "DreamWorld",
                        principalColumn: "Id_DreamWorld",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Other_OfficialArtwork_OfficialArtworkId_OfficialArtwork",
                        column: x => x.OfficialArtworkId_OfficialArtwork,
                        principalTable: "OfficialArtwork",
                        principalColumn: "Id_OfficialArtwork",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id_Sprites = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontDefault = table.Column<string>(nullable: true),
                    FrontShiny = table.Column<string>(nullable: true),
                    OtherId_Other = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id_Sprites);
                    table.ForeignKey(
                        name: "FK_Sprites_Other_OtherId_Other",
                        column: x => x.OtherId_Other,
                        principalTable: "Other",
                        principalColumn: "Id_Other",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    BaseExperience = table.Column<int>(nullable: false),
                    SpritesId_Sprites = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Sprites_SpritesId_Sprites",
                        column: x => x.SpritesId_Sprites,
                        principalTable: "Sprites",
                        principalColumn: "Id_Sprites",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id_Ability = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertiesAbilityId_PropertiesAbility = table.Column<int>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false),
                    Slot = table.Column<long>(nullable: false),
                    PokemonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id_Ability);
                    table.ForeignKey(
                        name: "FK_Ability_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ability_PropertiesAbility_PropertiesAbilityId_PropertiesAbility",
                        column: x => x.PropertiesAbilityId_PropertiesAbility,
                        principalTable: "PropertiesAbility",
                        principalColumn: "Id_PropertiesAbility",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id_Moves = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoveId_PropertiesMove = table.Column<int>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id_Moves);
                    table.ForeignKey(
                        name: "FK_Moves_PropertiesMove_MoveId_PropertiesMove",
                        column: x => x.MoveId_PropertiesMove,
                        principalTable: "PropertiesMove",
                        principalColumn: "Id_PropertiesMove",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id_Stats = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValueState = table.Column<long>(nullable: false),
                    EffortState = table.Column<long>(nullable: false),
                    PropertiesStateId_PropertiesAbility = table.Column<int>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id_Stats);
                    table.ForeignKey(
                        name: "FK_Stats_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_PropertiesAbility_PropertiesStateId_PropertiesAbility",
                        column: x => x.PropertiesStateId_PropertiesAbility,
                        principalTable: "PropertiesAbility",
                        principalColumn: "Id_PropertiesAbility",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeElement",
                columns: table => new
                {
                    Id_TypeElement = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Slot = table.Column<long>(nullable: false),
                    TypeId_PropertiesAbility = table.Column<int>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeElement", x => x.Id_TypeElement);
                    table.ForeignKey(
                        name: "FK_TypeElement_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeElement_PropertiesAbility_TypeId_PropertiesAbility",
                        column: x => x.TypeId_PropertiesAbility,
                        principalTable: "PropertiesAbility",
                        principalColumn: "Id_PropertiesAbility",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_PokemonId",
                table: "Ability",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_PropertiesAbilityId_PropertiesAbility",
                table: "Ability",
                column: "PropertiesAbilityId_PropertiesAbility");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MoveId_PropertiesMove",
                table: "Moves",
                column: "MoveId_PropertiesMove");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonId",
                table: "Moves",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Other_DreamWorldId_DreamWorld",
                table: "Other",
                column: "DreamWorldId_DreamWorld");

            migrationBuilder.CreateIndex(
                name: "IX_Other_OfficialArtworkId_OfficialArtwork",
                table: "Other",
                column: "OfficialArtworkId_OfficialArtwork");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_SpritesId_Sprites",
                table: "Pokemons",
                column: "SpritesId_Sprites");

            migrationBuilder.CreateIndex(
                name: "IX_Sprites_OtherId_Other",
                table: "Sprites",
                column: "OtherId_Other");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PokemonId",
                table: "Stats",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PropertiesStateId_PropertiesAbility",
                table: "Stats",
                column: "PropertiesStateId_PropertiesAbility");

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_PokemonId",
                table: "TypeElement",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_TypeId_PropertiesAbility",
                table: "TypeElement",
                column: "TypeId_PropertiesAbility");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "TypeElement");

            migrationBuilder.DropTable(
                name: "PropertiesMove");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "PropertiesAbility");

            migrationBuilder.DropTable(
                name: "Sprites");

            migrationBuilder.DropTable(
                name: "Other");

            migrationBuilder.DropTable(
                name: "DreamWorld");

            migrationBuilder.DropTable(
                name: "OfficialArtwork");
        }
    }
}
