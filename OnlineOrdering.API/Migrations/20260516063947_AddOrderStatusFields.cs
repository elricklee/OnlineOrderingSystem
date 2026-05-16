using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineOrdering.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderStatusFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmedAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveringAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonName",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPersonPhone",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedMinutes",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreparingAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadyAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DiningTables",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ConfirmedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveringAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryPersonPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EstimatedMinutes",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PreparingAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReadyAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DiningTables");
        }
    }
}
