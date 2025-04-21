using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fff",
                table: "UsaToAuProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fff",
                table: "UsaToAuProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
