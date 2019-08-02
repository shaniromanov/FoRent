using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Apartment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BedRoom = table.Column<string>(nullable: true),
                    DiningRoom = table.Column<string>(nullable: true),
                    Ketchen = table.Column<string>(nullable: true),
                    LivingRoom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApartmentId",
                table: "Order",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrdersId",
                table: "Order",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ImageId",
                table: "Apartment",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Apartment_ApartmentId",
                table: "Order",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_OrdersId",
                table: "Order",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Image_ImageId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Apartment_ApartmentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_OrdersId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Order_ApartmentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrdersId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_ImageId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Apartment");
        }
    }
}
