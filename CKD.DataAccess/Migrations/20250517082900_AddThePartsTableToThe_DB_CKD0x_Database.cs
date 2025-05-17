using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKD.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddThePartsTableToThe_DB_CKD0x_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Parts",
                columns: table => new
                {
                    TechNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    FarsiName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsSet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Parts", x => x.TechNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Parts");
        }
    }
}
