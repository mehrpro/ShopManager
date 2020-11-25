using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Migrations
{
    public partial class _46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AddressBooks_AddressBookId",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "AddressBookId",
                table: "Sellers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AddressBooks_AddressBookId",
                table: "Sellers",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "AddressBookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AddressBooks_AddressBookId",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "AddressBookId",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AddressBooks_AddressBookId",
                table: "Sellers",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "AddressBookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
