using Microsoft.EntityFrameworkCore.Migrations;

namespace eshop.Migrations.MySQL
{
    public partial class MySQL_1_0_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Confirmed",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GuardingDog_ProductID",
                table: "GuardingDog",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_GuardingDog_UserID",
                table: "GuardingDog",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_GuardingDog_Products_ProductID",
                table: "GuardingDog",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuardingDog_Users_UserID",
                table: "GuardingDog",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuardingDog_Products_ProductID",
                table: "GuardingDog");

            migrationBuilder.DropForeignKey(
                name: "FK_GuardingDog_Users_UserID",
                table: "GuardingDog");

            migrationBuilder.DropIndex(
                name: "IX_GuardingDog_ProductID",
                table: "GuardingDog");

            migrationBuilder.DropIndex(
                name: "IX_GuardingDog_UserID",
                table: "GuardingDog");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Order");
        }
    }
}
