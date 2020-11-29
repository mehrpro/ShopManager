using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Migrations
{
    public partial class CreateIndexStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndexStores",
                columns: table => new
                {
                    IndexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexNumber = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IndexName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IndexDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexStores", x => x.IndexId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexStores");
        }
    }
}
