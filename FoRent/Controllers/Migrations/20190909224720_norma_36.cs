using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class norma_36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPaymentId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderPaymentId",
                table: "Order",
                column: "OrderPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderPayments_OrderPaymentId",
                table: "Order",
                column: "OrderPaymentId",
                principalTable: "OrderPayments",
                principalColumn: "OrderPaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderPayments_OrderPaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderPaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderPaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");
        }
    }
}
