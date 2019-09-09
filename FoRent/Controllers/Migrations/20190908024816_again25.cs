using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class again25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Location_LocationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Policy_PolicyId",
                table: "Apartment");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                principalTable: "ApartmentAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Location_LocationId",
                table: "Apartment",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Policy_PolicyId",
                table: "Apartment",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Location_LocationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Policy_PolicyId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                table: "Apartment",
                column: "AmenitiesId",
                principalTable: "ApartmentAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Location_LocationId",
                table: "Apartment",
                column: "LocationId",
                principalTable: "Location",
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
    }
}
