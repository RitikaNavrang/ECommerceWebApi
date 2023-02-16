using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApi.Migrations
{
    public partial class ww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_ProductId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_UserId",
                table: "products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_UserId",
                table: "products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_UserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_UserId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductId",
                table: "products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_ProductId",
                table: "products",
                column: "ProductId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
