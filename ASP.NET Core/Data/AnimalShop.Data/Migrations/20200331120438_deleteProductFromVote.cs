using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShop.Data.Migrations
{
    public partial class deleteProductFromVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Products_ProductId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ProductId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Votes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Votes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProductId",
                table: "Votes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Products_ProductId",
                table: "Votes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
