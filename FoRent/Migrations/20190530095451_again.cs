using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Renter");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Renter");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Apartment");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Renter",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Renter",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Renter",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Renter",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Renter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Renter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Apartment",
                nullable: true);
        }
    }
}
