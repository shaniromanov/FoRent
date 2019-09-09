using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "review",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Checkin",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cleanliness",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mm",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);
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
                name: "Mm",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "review",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
