using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKD.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTheProductsTableToThe_DB_CKD0x_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductVersion = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EngineTypeDesc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateByUserEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Products", x => x.ProductCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Products");
        }
    }
}
