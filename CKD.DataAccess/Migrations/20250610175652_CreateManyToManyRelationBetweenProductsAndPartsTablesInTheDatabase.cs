using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKD.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateManyToManyRelationBetweenProductsAndPartsTablesInTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TBL_ProductParts_Part_TechNo",
                table: "TBL_ProductParts",
                column: "Part_TechNo");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductParts_TBL_Parts_Part_TechNo",
                table: "TBL_ProductParts",
                column: "Part_TechNo",
                principalTable: "TBL_Parts",
                principalColumn: "TechNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ProductParts_TBL_Products_Product_ProductCode",
                table: "TBL_ProductParts",
                column: "Product_ProductCode",
                principalTable: "TBL_Products",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductParts_TBL_Parts_Part_TechNo",
                table: "TBL_ProductParts");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ProductParts_TBL_Products_Product_ProductCode",
                table: "TBL_ProductParts");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ProductParts_Part_TechNo",
                table: "TBL_ProductParts");
        }
    }
}
