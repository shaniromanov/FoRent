using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_RenterPassword",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserPassword",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_RenterPassword",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "RenterPassword",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RenterPassword",
                table: "Apartment");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Apartment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RenterId",
                table: "Order",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_RenterId",
                table: "Apartment",
                column: "RenterId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_RenterId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_RenterId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Apartment");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "RenterPassword",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RenterPassword",
                table: "Apartment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RenterPassword",
                table: "Order",
                column: "RenterPassword");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserPassword",
                table: "Order",
                column: "UserPassword");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_RenterPassword",
                table: "Apartment",
                column: "RenterPassword");

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
    }
}
