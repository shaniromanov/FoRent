using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartment_LocationId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "Location",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Location",
                newName: "x");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Location",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApartmentAmenities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_LocationId",
                table: "Apartment",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartment_LocationId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "Location",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "Location",
                newName: "Lat");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Location",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ApartmentAmenities",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_LocationId",
                table: "Apartment",
                column: "LocationId");
        }
    }
}
