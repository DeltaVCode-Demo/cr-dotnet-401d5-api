using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class SeedSomeHotelsAndHotelRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10001, "Downtown Cedar Rapids" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10011, "Ped Mall, Iowa City" });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "Price" },
                values: new object[,]
                {
                    { 10001, 101, 99m },
                    { 10001, 102, 99m },
                    { 10001, 103, 99m },
                    { 10001, 104, 99m },
                    { 10001, 201, 299m },
                    { 10001, 202, 299m },
                    { 10011, 11, 199m },
                    { 10011, 12, 199m },
                    { 10011, 21, 199m },
                    { 10011, 22, 199m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 101 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 102 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 103 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 104 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 201 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10001, 202 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10011, 11 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10011, 12 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10011, 21 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 10011, 22 });

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10011);
        }
    }
}
