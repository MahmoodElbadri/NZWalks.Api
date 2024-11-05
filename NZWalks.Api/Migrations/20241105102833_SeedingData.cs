using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("314366dc-8188-463b-8f37-7c465af76eb7"), "Easy" },
                    { new Guid("3717e509-2b32-47e8-b187-1235c40744e7"), "Medium" },
                    { new Guid("7b307fdd-80e6-4870-a9ea-1a819eae5e28"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("6b020edb-1b87-4a27-8743-c5a307a035dd"), "NYC", "New York", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("73b907f0-a057-4c57-b145-f7c29edd1d82"), "WLG", "Wellington", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("bb8b3f0c-b34d-4e19-af9c-1c33cf1db948"), "TRG", "Tauranga", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c8731068-e9cf-425b-90cc-059857cf04b8"), "AKL", "Auckland", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("dd7c7952-fbb3-4f1f-9edb-c4a8f64954f6"), "CHC", "Christchurch", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f696b472-b2d2-4664-ab7c-d8e49a5992a7"), "NSN", "Nelson", "https://images.pexels.com/photos/2121121/pexels-photo-2121121.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("314366dc-8188-463b-8f37-7c465af76eb7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3717e509-2b32-47e8-b187-1235c40744e7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7b307fdd-80e6-4870-a9ea-1a819eae5e28"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6b020edb-1b87-4a27-8743-c5a307a035dd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("73b907f0-a057-4c57-b145-f7c29edd1d82"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bb8b3f0c-b34d-4e19-af9c-1c33cf1db948"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c8731068-e9cf-425b-90cc-059857cf04b8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dd7c7952-fbb3-4f1f-9edb-c4a8f64954f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f696b472-b2d2-4664-ab7c-d8e49a5992a7"));
        }
    }
}
