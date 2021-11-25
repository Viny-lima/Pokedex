using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Model.Migrations
{
    public partial class InitialPokemonDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hp = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    SpecialAttackense = table.Column<int>(nullable: false),
                    SpecialDefense = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    BaseExperience = table.Column<int>(nullable: false),
                    AbilitiesSlotOne = table.Column<string>(nullable: true),
                    AbilitiesSlotTwo = table.Column<string>(nullable: true),
                    SpritesFrontDefault = table.Column<string>(nullable: true),
                    SpritesOfficialArtwork = table.Column<string>(nullable: true),
                    TypeOne = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
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
                name: "Moves",
                columns: table => new
                {
                    Id_Moves = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoveId_PropertiesMove = table.Column<int>(nullable: true),
                    PokemonDbId = table.Column<int>(nullable: true)
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
                        name: "FK_Moves_Pokemons_PokemonDbId",
                        column: x => x.PokemonDbId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MoveId_PropertiesMove",
                table: "Moves",
                column: "MoveId_PropertiesMove");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonDbId",
                table: "Moves",
                column: "PokemonDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "PropertiesMove");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
