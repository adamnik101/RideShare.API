using Microsoft.EntityFrameworkCore.Migrations;

namespace RideShare.DataAccess.Migrations
{
    public partial class addrides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cities_EndCityId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Cities_StartCityId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Users_DriverId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_RideRequests_Ride_RideId",
                table: "RideRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ride",
                table: "Ride");

            migrationBuilder.RenameTable(
                name: "Ride",
                newName: "Rides");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_StartCityId",
                table: "Rides",
                newName: "IX_Rides_StartCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_EndCityId",
                table: "Rides",
                newName: "IX_Rides_EndCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_DriverId",
                table: "Rides",
                newName: "IX_Rides_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Ride_CarId",
                table: "Rides",
                newName: "IX_Rides_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RideRequests_Rides_RideId",
                table: "RideRequests",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cities_EndCityId",
                table: "Rides",
                column: "EndCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cities_StartCityId",
                table: "Rides",
                column: "StartCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RideRequests_Rides_RideId",
                table: "RideRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cities_EndCityId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cities_StartCityId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Users_DriverId",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "Ride");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_StartCityId",
                table: "Ride",
                newName: "IX_Ride_StartCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_EndCityId",
                table: "Ride",
                newName: "IX_Ride_EndCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_DriverId",
                table: "Ride",
                newName: "IX_Ride_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarId",
                table: "Ride",
                newName: "IX_Ride_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ride",
                table: "Ride",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cars_CarId",
                table: "Ride",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cities_EndCityId",
                table: "Ride",
                column: "EndCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Cities_StartCityId",
                table: "Ride",
                column: "StartCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Users_DriverId",
                table: "Ride",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RideRequests_Ride_RideId",
                table: "RideRequests",
                column: "RideId",
                principalTable: "Ride",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
