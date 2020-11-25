using Microsoft.EntityFrameworkCore.Migrations;

namespace SPS.Migrations
{
    public partial class uo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Units",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Sellers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "PercentageIncomes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Commodities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreHouses_CommodityId",
                table: "StoreHouses",
                column: "CommodityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouses_CommodityPrices_CommodityId",
                table: "StoreHouses",
                column: "CommodityId",
                principalTable: "CommodityPrices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouses_CommodityPrices_CommodityId",
                table: "StoreHouses");

            migrationBuilder.DropIndex(
                name: "IX_StoreHouses_CommodityId",
                table: "StoreHouses");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Units",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "PercentageIncomes",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Commodities",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
