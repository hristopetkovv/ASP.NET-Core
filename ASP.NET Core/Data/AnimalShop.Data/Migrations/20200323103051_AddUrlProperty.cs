using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShop.Data.Migrations
{
    public partial class AddUrlProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "PetAdvices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "PetAdvices");
        }
    }
}
