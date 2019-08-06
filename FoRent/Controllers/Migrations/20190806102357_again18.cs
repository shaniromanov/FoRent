using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Apartment_ApartmentId",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_ApartmentId",
                table: "Availability");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Availability");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Availability",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Availability",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Availability",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ApartmentId",
                table: "Availability",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Apartment_ApartmentId",
                table: "Availability",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
