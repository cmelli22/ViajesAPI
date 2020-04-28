using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViajesAPI.Migrations
{
    public partial class Seagregotablaproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "Messages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_productId",
                table: "Messages",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_products_productId",
                table: "Messages",
                column: "productId",
                principalTable: "products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_products_productId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropIndex(
                name: "IX_Messages_productId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "product",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
