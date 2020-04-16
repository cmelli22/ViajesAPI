using Microsoft.EntityFrameworkCore.Migrations;

namespace ViajesAPI.Migrations
{
    public partial class SeAgregpProductaMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "product",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product",
                table: "Messages");
        }
    }
}
