using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McbEdu.Mentorias.ShopDemo.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    BirthDate = table.Column<string>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    OrderTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CustomerIdentifier = table.Column<Guid>(type: "VARCHAR", maxLength: 36, nullable: false),
                    CustomerName = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    CustomerSurname = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    CustomerEmail = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    CustomerBirthdate = table.Column<string>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    UnitaryValue = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ProductIdentifier = table.Column<Guid>(type: "VARCHAR", nullable: false),
                    ProductCode = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    ProductDescription = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    OrderIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderIdentifier",
                        column: x => x.OrderIdentifier,
                        principalTable: "Orders",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Identifier",
                table: "Customers",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Identifier",
                table: "OrderItem",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderIdentifier",
                table: "OrderItem",
                column: "OrderIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Code",
                table: "Orders",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Identifier",
                table: "Orders",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Identifier",
                table: "Products",
                column: "Identifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
