using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineOrdering.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentOccupiedSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DinerCount",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentOccupiedSeats",
                table: "DiningTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DinerCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CurrentOccupiedSeats",
                table: "DiningTables");
        }
    }
}
