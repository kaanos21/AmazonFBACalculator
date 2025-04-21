using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsaToAuMonthlySales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsaToAuProductId = table.Column<int>(type: "int", nullable: false),
                    SaleMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsaToAuMonthlySales");
        }
    }
}
