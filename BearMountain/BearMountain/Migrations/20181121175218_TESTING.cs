using Microsoft.EntityFrameworkCore.Migrations;

namespace BearMountain.Migrations
{
    public partial class TESTING : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "ID", "BasketID", "CheckedOut", "ProductID", "Quantity", "UserBasketID" },
                values: new object[] { 1, 1, false, 110, 2, null });

            migrationBuilder.InsertData(
                table: "UserBasket",
                columns: new[] { "ID", "UserID" },
                values: new object[] { 1, "jbc@bearmountain.com" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductID",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems");

            migrationBuilder.DeleteData(
                table: "BasketItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserBasket",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
