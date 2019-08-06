using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again13 : Migration
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

            migrationBuilder.CreateTable(
                name: "ApartmentAvailability",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAvailability", x => new { x.AvailabilityId, x.ApartmentId });
                    table.ForeignKey(
                        name: "FK_ApartmentAvailability_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentAvailability_Availability_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAvailability_ApartmentId",
                table: "ApartmentAvailability",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentAvailability");

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
