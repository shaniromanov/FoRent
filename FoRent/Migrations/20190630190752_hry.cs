using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class hry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_User_RenterId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_RenterId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "RenterId",
                table: "Order",
                newName: "RenterPassword");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_UserPassword");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RenterId",
                table: "Order",
                newName: "IX_Order_RenterPassword");

            migrationBuilder.RenameColumn(
                name: "RenterId",
                table: "Apartment",
                newName: "RenterPassword");

            migrationBuilder.RenameIndex(
                name: "IX_Apartment_RenterId",
                table: "Apartment",
                newName: "IX_Apartment_RenterPassword");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_User_RenterPassword",
                table: "Apartment",
                column: "RenterPassword",
                principalTable: "User",
                principalColumn: "Password",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_RenterPassword",
                table: "Order",
                column: "RenterPassword",
                principalTable: "User",
                principalColumn: "Password",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserPassword",
                table: "Order",
                column: "UserPassword",
                principalTable: "User",
                principalColumn: "Password",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_User_RenterPassword",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_RenterPassword",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserPassword",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RenterPassword",
                table: "Order",
                newName: "RenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserPassword",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RenterPassword",
                table: "Order",
                newName: "IX_Order_RenterId");

            migrationBuilder.RenameColumn(
                name: "RenterPassword",
                table: "Apartment",
                newName: "RenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartment_RenterPassword",
                table: "Apartment",
                newName: "IX_Apartment_RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_User_RenterId",
                table: "Apartment",
                column: "RenterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_RenterId",
                table: "Order",
                column: "RenterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
