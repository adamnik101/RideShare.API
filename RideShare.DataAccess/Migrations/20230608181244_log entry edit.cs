using Microsoft.EntityFrameworkCore.Migrations;

namespace RideShare.DataAccess.Migrations
{
    public partial class logentryedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "LogEntries");

            migrationBuilder.AddColumn<string>(
                name: "Actor",
                table: "LogEntries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actor",
                table: "LogEntries");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "LogEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
