using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKD.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTheProductPartsTableToTheDB_CKD04_DatabaseAsMappingBetweenProductsAndParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ProductParts",
                columns: table => new
                {
                    Product_ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Part_TechNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProductParts", x => new { x.Product_ProductCode, x.Part_TechNo });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ProductParts");
        }
    }
}
