using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsaToAuProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FbaFee = table.Column<double>(type: "float", nullable: false),
                    FbaSalesFee = table.Column<double>(type: "float", nullable: false),
                    ShipmentPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UsaPrice = table.Column<double>(type: "float", nullable: false),
                    AuPrice = table.Column<double>(type: "float", nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsaToAuProduct", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsaToAuProduct");
        }
    }
}
