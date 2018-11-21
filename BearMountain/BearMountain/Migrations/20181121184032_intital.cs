using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BearMountain.Migrations
{
    public partial class intital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserBasket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBasket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserBasketID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_UserBasket_UserBasketID",
                        column: x => x.UserBasketID,
                        principalTable: "UserBasket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 101, "The Arc'teryx Atom LT Insulated hoodie featuring Coreloft™ insulation and air permeable side panels functions as an outer layer or as a mid layer depending on the conditions.", "arcteryxJacket.jpg", "Arc'teryx Atom LT Insulated Hoodie", 259m, "137913" },
                    { 102, "A lightweight, roomy design for 3-season backpacking, The North Face Furnace 20 sleeping bag is insulated with water-resistant ProDown, which repels water and dries faster than traditional down.", "northFaceBag.jpg", "The North Face Furnace 20 Sleeping Bag", 189m, "117155" },
                    { 103, "Your home away from home shouldn't skimp on the essentials. The 3-season REI Co-op Half Dome 2 Plus backpacking tent provides you and a partner with plenty of room to stretch out and stay comfortable.", "reiTent.jpg", "REI Co-op Half Dome 2 Plus Tent", 229m, "128692" },
                    { 104, "For a long week on the trail or a gear - intensive weekend where extra volume is vital, the Osprey Aether AG 70 pack enhances mobility and comfort with the Anti - Gravity harness and suspended - mesh back.", "ospreyPack.jpg", "Osprey Aether AG 70 Pack ", 310m, "111284" },
                    { 105, "Weighing in at a sleek 45 lbs., the Delta 14 Kayak with rudder from Delta Kayaks delivers speed and stability and offers tons of gear storage for weekend trips and extended tours.", "deltaKayak.jpg", "Delta Kayaks Delta 14 Kayak", 1995m, "867763" },
                    { 106, "The pinnacle of ultralight, aggressive all-terrain performance, MSR Lightning Ascent snowshoes offer tough, reliable decking for exploring mountainous winter wonderlands.", "msrSnowShoes.jpg", "MSR Lightning Ascent Snowshoes", 299m, "120297" },
                    { 107, "Looking for a capable all-rounder for days on the mountain? The GHOST Kato FS 7.7 27.5 mountain bike offers full-suspension fun on a hydroformed aluminum frame.", "ghostBike.jpg", "GHOST Kato FS 7.7 27.5 Bike", 2029m, "125922" },
                    { 108, "The Black Diamond Trail Back trekking poles offer a reliable, easily adjustable, 3-section design for daily hikes and multiday adventures.", "blackMountainPoles.jpg", "Black Diamond Trail Back Trekking Poles - Pair", 79m, "895931" },
                    { 109, "The serious capacity on this Hydro Flask Wide-Mouth 40 oz. vacuum water bottle is perfect for all-day hydration (including ice cubes) or finishing your hike with hot soup.", "hydroFlask.jpg", "Hydro Flask Wide-Mouth Vacuum Water Bottle - 40 fl. oz.", 42m, "100106" },
                    { 110, "With cushioning for the perfect amount of support and a smooth fit with no slipping, bunching, or blisters, the Darn Tough Hiker Boot Sock Cushion socks have earned a place in the hearts of hikers.", "socks.jpg", "Darn Tough Hiker Boot Sock Cushion Socks", 24m, "887221" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_UserBasketID",
                table: "BasketItems",
                column: "UserBasketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserBasket");
        }
    }
}
