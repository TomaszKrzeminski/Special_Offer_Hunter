using Microsoft.EntityFrameworkCore.Migrations;

namespace Special_Offer_Hunter.Data.Migrations
{
    public partial class Entity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Shopping_Cart_DayId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Shopping_Cart_WeekId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Shopping_Cart_DayId",
                table: "Product",
                column: "Shopping_Cart_DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shopping_Cart_Day_Shopping_Cart_DayId",
                table: "Product",
                column: "Shopping_Cart_DayId",
                principalTable: "Shopping_Cart_Day",
                principalColumn: "Shopping_Cart_DayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shopping_Cart_Day_Shopping_Cart_DayId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Shopping_Cart_DayId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Shopping_Cart_DayId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Shopping_Cart_WeekId",
                table: "Product");
        }
    }
}
