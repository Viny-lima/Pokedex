using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Model.Migrations
{
    public partial class AlterTableColumnSpriteAndIsComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Hp = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    SpecialAttack = table.Column<int>(nullable: false),
                    SpecialDefense = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    BaseExperience = table.Column<int>(nullable: false),
                    Sprite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbilityPokemonDB",
                columns: table => new
                {
                    PokemonId = table.Column<int>(nullable: false),
                    AbilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityPokemonDB", x => new { x.AbilityId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_AbilityPokemonDB_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityPokemonDB_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovePokemonDB",
                columns: table => new
                {
                    PokemonId = table.Column<int>(nullable: false),
                    MoveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovePokemonDB", x => new { x.MoveId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_MovePokemonDB_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovePokemonDB_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypePokemonDB",
                columns: table => new
                {
                    PokemonId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePokemonDB", x => new { x.TypeId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_TypePokemonDB_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypePokemonDB_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityPokemonDB_PokemonId",
                table: "AbilityPokemonDB",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovePokemonDB_PokemonId",
                table: "MovePokemonDB",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePokemonDB_PokemonId",
                table: "TypePokemonDB",
                column: "PokemonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityPokemonDB");

            migrationBuilder.DropTable(
                name: "MovePokemonDB");

            migrationBuilder.DropTable(
                name: "TypePokemonDB");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
