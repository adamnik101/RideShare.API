using Microsoft.EntityFrameworkCore.Migrations;

namespace RideShare.DataAccess.Migrations
{
    public partial class carregv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstRegistration",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstRegistration",
                table: "Cars");
        }
    }
}
