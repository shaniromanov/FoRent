using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoRent.Migrations
{
    public partial class norma_38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderPayments_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "OrderPayments",
                principalColumn: "OrderPaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderPayments_PaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderPaymentId",
                table: "Order",
                nullable: true);

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
    }
}
