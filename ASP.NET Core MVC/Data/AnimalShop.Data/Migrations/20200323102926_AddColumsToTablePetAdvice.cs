using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShop.Data.Migrations
{
    public partial class AddColumsToTablePetAdvice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PetAdvices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PetAdvices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PetAdvices");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PetAdvices");
        }
    }
}
