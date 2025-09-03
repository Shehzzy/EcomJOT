using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_JOT.Migrations
{
    /// <inheritdoc />
    public partial class secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatID",
                table: "Products",
                column: "CatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatID",
                table: "Products",
                column: "CatID",
                principalTable: "Categories",
                principalColumn: "CatID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatID",
                table: "Products");
        }
    }
}
