using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsaToAuMonthlySales");

            migrationBuilder.AddColumn<string>(
                name: "Analysis",
                table: "UsaToAuProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Surcharge",
                table: "UsaToAuProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "fff",
                table: "UsaToAuProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analysis",
                table: "UsaToAuProduct");

            migrationBuilder.DropColumn(
                name: "Surcharge",
                table: "UsaToAuProduct");

            migrationBuilder.DropColumn(
                name: "fff",
                table: "UsaToAuProduct");

            migrationBuilder.CreateTable(
                name: "UsaToAuMonthlySales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsaToAuProductId = table.Column<int>(type: "int", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false),
                    SaleMonth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsaToAuMonthlySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsaToAuMonthlySales_UsaToAuProduct_UsaToAuProductId",
                        column: x => x.UsaToAuProductId,
                        principalTable: "UsaToAuProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsaToAuMonthlySales_UsaToAuProductId",
                table: "UsaToAuMonthlySales",
                column: "UsaToAuProductId");
        }
    }
}
