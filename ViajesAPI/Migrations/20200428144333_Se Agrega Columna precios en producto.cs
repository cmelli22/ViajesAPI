using Microsoft.EntityFrameworkCore.Migrations;

namespace ViajesAPI.Migrations
{
    public partial class SeAgregaColumnapreciosenproducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "products");
        }
    }
}
