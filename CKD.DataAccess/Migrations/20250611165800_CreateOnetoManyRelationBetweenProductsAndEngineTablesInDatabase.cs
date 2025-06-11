using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKD.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateOnetoManyRelationBetweenProductsAndEngineTablesInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineTypeDesc",
                table: "TBL_Products");

            migrationBuilder.AddColumn<int>(
                name: "EngineType_Id",
                table: "TBL_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Products_EngineType_Id",
                table: "TBL_Products",
                column: "EngineType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Products_TBL_EngineTypes_EngineType_Id",
                table: "TBL_Products",
                column: "EngineType_Id",
                principalTable: "TBL_EngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Products_TBL_EngineTypes_EngineType_Id",
                table: "TBL_Products");

            migrationBuilder.DropIndex(
                name: "IX_TBL_Products_EngineType_Id",
                table: "TBL_Products");

            migrationBuilder.DropColumn(
                name: "EngineType_Id",
                table: "TBL_Products");

            migrationBuilder.AddColumn<string>(
                name: "EngineTypeDesc",
                table: "TBL_Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
