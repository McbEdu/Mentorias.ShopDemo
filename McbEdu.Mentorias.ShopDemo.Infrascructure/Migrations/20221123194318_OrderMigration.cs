using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    RequestedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerIdentifier",
                        column: x => x.CustomerIdentifier,
                        principalTable: "Customers",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitaryValue = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderIdentifier",
                        column: x => x.OrderIdentifier,
                        principalTable: "Orders",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductIdentifier",
                        column: x => x.ProductIdentifier,
                        principalTable: "Products",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderIdentifier",
                table: "Items",
                column: "OrderIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductIdentifier",
                table: "Items",
                column: "ProductIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerIdentifier",
                table: "Orders",
                column: "CustomerIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
