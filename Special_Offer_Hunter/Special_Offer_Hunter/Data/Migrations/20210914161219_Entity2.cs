using Microsoft.EntityFrameworkCore.Migrations;

namespace Special_Offer_Hunter.Data.Migrations
{
    public partial class Entity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopping_Cart");

            migrationBuilder.AddColumn<int>(
                name: "ProductCodeId",
                table: "Product_Code",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Shopping_Cart_Day",
                columns: table => new
                {
                    Shopping_Cart_DayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Cart_Day", x => x.Shopping_Cart_DayId);
                    table.ForeignKey(
                        name: "FK_Shopping_Cart_Day_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Cart_Week",
                columns: table => new
                {
                    Shopping_Cart_WeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Cart_Week", x => x.Shopping_Cart_WeekId);
                    table.ForeignKey(
                        name: "FK_Shopping_Cart_Week_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code_ProductCodeId",
                table: "Product_Code",
                column: "ProductCodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Cart_Day_ApplicationUserId",
                table: "Shopping_Cart_Day",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Cart_Week_ApplicationUserId",
                table: "Shopping_Cart_Week",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Code_Product_ProductCodeId",
                table: "Product_Code",
                column: "ProductCodeId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Code_Product_ProductCodeId",
                table: "Product_Code");

            migrationBuilder.DropTable(
                name: "Shopping_Cart_Day");

            migrationBuilder.DropTable(
                name: "Shopping_Cart_Week");

            migrationBuilder.DropIndex(
                name: "IX_Product_Code_ProductCodeId",
                table: "Product_Code");

            migrationBuilder.DropColumn(
                name: "ProductCodeId",
                table: "Product_Code");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Shopping_Cart",
                columns: table => new
                {
                    Shopping_CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Cart", x => x.Shopping_CartId);
                });
        }
    }
}
