using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Model.Migrations
{
    public partial class AlterTableAddColumnIsCreatedByTheUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedByTheUser",
                table: "Pokemons",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreatedByTheUser",
                table: "Pokemons");
        }
    }
}
