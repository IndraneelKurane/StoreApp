using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.DalSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationRow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LocationRowId = table.Column<int>(type: "int", nullable: false),
                    RackNo = table.Column<int>(type: "int", nullable: false),
                    StartedUsingOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationRow_LocationRowId",
                        column: x => x.LocationRowId,
                        principalTable: "LocationRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartyId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ItemTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    ItemId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillItem_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliverySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillItemId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverySchedule_BillItem_BillItemId",
                        column: x => x.BillItemId,
                        principalTable: "BillItem",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LocationRow",
                columns: new[] { "Id", "InUse", "Name" },
                values: new object[,]
                {
                    { 1, true, "First" },
                    { 2, false, "Second" },
                    { 3, false, "Third" },
                    { 4, false, "Fourth" },
                    { 5, false, "Fifth" }
                });

            migrationBuilder.InsertData(
                table: "Party",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "john@gamil.com", "John Doe", "123-456-7890" },
                    { 2, "456 Oak St", "jane@gmail.com", "Jane Smith", "987-654-3210" },
                    { 3, "789 Pine St", "acme@hmail.com", "Acme Corp", "555-123-4567" },
                    { 4, "321 Maple St", "global@gmail.com", "Global Industries", "444-987-6543" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kilogram" },
                    { 2, "Gram" },
                    { 3, "Liter" },
                    { 4, "Milliliter" },
                    { 5, "Piece" }
                });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "Id", "BillDate", "BillNumber", "ItemTotal", "NetAmount", "PartyId" },
                values: new object[] { 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 60.0m, 60.0m, 3 });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "Id", "BillDate", "BillNumber", "Discount", "ItemTotal", "NetAmount", "PartyId" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 222, 10.0m, 30.0m, 130.0m, 2 },
                    { 3, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 333, 20.0m, 180.0m, 160.0m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "LocationRowId", "RackNo", "StartedUsingOn" },
                values: new object[,]
                {
                    { 1, "First Floor", 4, 1, new DateTime(2025, 8, 19, 17, 9, 38, 816, DateTimeKind.Local).AddTicks(5810) },
                    { 2, "Second Floor", 3, 1, new DateTime(2025, 8, 19, 17, 9, 38, 816, DateTimeKind.Local).AddTicks(5821) },
                    { 3, "Third Floor", 2, 1, new DateTime(2025, 8, 19, 17, 9, 38, 816, DateTimeKind.Local).AddTicks(5829) },
                    { 4, "Fourth Floor", 5, 1, new DateTime(2025, 8, 19, 17, 9, 38, 816, DateTimeKind.Local).AddTicks(5835) },
                    { 5, "Fifth Floor", 1, 1, new DateTime(2025, 8, 19, 17, 9, 38, 816, DateTimeKind.Local).AddTicks(5842) }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Amount", "LocationId", "Name", "Price", "Quantity", "UnitId" },
                values: new object[,]
                {
                    { 1, 0m, 5, "Apple", 0.5m, 0m, 3 },
                    { 2, 0m, 3, "Banana", 0.3m, 0m, 5 },
                    { 3, 0m, 2, "Orange Juice", 1.5m, 0m, 4 },
                    { 4, 0m, 1, "Milk", 0.8m, 0m, 1 },
                    { 5, 0m, 4, "Bread", 1.0m, 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "Id", "Amount", "BillId", "ItemId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 40m, 2, 1, 10.0m, 4m },
                    { 2, 100m, 2, 2, 20.0m, 5m },
                    { 3, 60m, 1, 3, 30.0m, 2m },
                    { 4, 80m, 3, 4, 40.0m, 2m },
                    { 5, 100m, 3, 5, 50.0m, 2m }
                });

            migrationBuilder.InsertData(
                table: "DeliverySchedule",
                columns: new[] { "Id", "BillItemId", "DeliveryDate", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m },
                    { 2, 2, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m },
                    { 3, 2, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 4, 3, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 5, 4, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 6, 5, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PartyId",
                table: "Bill",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_BillId",
                table: "BillItem",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_ItemId",
                table: "BillItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverySchedule_BillItemId",
                table: "DeliverySchedule",
                column: "BillItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_LocationId",
                table: "Item",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UnitId",
                table: "Item",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationRowId",
                table: "Location",
                column: "LocationRowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliverySchedule");

            migrationBuilder.DropTable(
                name: "BillItem");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "LocationRow");
        }
    }
}
