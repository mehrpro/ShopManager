using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Migrations
{
    public partial class IndexStoreUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IndexNumber",
                table: "IndexStores",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IndexNumber",
                table: "IndexStores",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
