using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "Apartment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Apartment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Apartment_ApartmentId",
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
                name: "IX_Pictures_ApartmentId",
                table: "Pictures",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                principalTable: "ApartmentAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Policy_PolicyId",
                table: "Apartment",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Policy_PolicyId",
                table: "Apartment");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Apartment");

            
        }
    }
}
