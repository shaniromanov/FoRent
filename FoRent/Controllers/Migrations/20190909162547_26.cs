using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                unique: true,
                filter: "[AmenitiesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment",
                column: "PolicyId",
                unique: true,
                filter: "[PolicyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(nullable: true),
                    Checkin = table.Column<int>(nullable: false),
                    Cleanliness = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Mm = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    review = table.Column<int>(nullable: false),
                    stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");
        }
    }
}
