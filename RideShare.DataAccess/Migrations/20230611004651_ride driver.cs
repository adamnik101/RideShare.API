using Microsoft.EntityFrameworkCore.Migrations;

namespace RideShare.DataAccess.Migrations
{
    public partial class ridedriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
