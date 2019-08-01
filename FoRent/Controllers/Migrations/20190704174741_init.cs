using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accessibility = table.Column<bool>(nullable: false),
                    AirConditioning = table.Column<bool>(nullable: false),
                    Balcony = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HotWater = table.Column<bool>(nullable: false),
                    NumOfPersons = table.Column<int>(nullable: false),
                    NumOfRooms = table.Column<double>(nullable: false),
                    Parking = table.Column<bool>(nullable: false),
                    Plata = table.Column<bool>(nullable: false),
                    Wifi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAmenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cancellations = table.Column<string>(nullable: true),
                    Checkin = table.Column<string>(nullable: true),
                    Checkout = table.Column<string>(nullable: true),
                    Creditcardsaccepted = table.Column<string>(nullable: true),
                    Extrabeds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmenitiesId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    PolicyId = table.Column<int>(nullable: true),
                    PriceAdult = table.Column<decimal>(nullable: false),
                    PriceChild = table.Column<decimal>(nullable: false),
                    RenterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_ApartmentAmenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "ApartmentAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_User_RenterId",
                        column: x => x.RenterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    QuantityAdult = table.Column<int>(nullable: false),
                    QuantityChild = table.Column<int>(nullable: false),
                    RenterId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_RenterId",
                        column: x => x.RenterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(nullable: true),
                    review = table.Column<string>(nullable: true),
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
                name: "IX_Apartment_LocationId",
                table: "Apartment",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_PolicyId",
                table: "Apartment",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_RenterId",
                table: "Apartment",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RenterId",
                table: "Order",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "ApartmentAmenities");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
