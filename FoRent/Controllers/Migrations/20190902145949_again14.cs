using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Checkin",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cleanliness",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checkin",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Cleanliness",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reviews");
        }
    }
}
