using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.AlterColumn<int>(
                name: "AmenitiesId",
                table: "Apartment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.AlterColumn<int>(
                name: "AmenitiesId",
                table: "Apartment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                unique: true,
                filter: "[AmenitiesId] IS NOT NULL");
        }
    }
}
