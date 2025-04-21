using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EarnAud",
                table: "UsaToAuProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EarnUsd",
                table: "UsaToAuProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "Roi",
                table: "UsaToAuProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarnAud",
                table: "UsaToAuProduct");

            migrationBuilder.DropColumn(
                name: "EarnUsd",
                table: "UsaToAuProduct");

            migrationBuilder.DropColumn(
                name: "Roi",
                table: "UsaToAuProduct");
        }
    }
}
