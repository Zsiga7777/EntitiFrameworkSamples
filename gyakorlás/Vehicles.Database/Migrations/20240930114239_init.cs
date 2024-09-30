using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    PostalCode = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.PostalCode);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfUse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfUse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FoundationYear = table.Column<long>(type: "bigint", nullable: false),
                    Ceo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Street_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "PostalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    ChassisType = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManufacturerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TAJ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StreetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencePlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NumberOfDoors = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    Power = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    ModelId = table.Column<long>(type: "bigint", nullable: false),
                    FieldOfUseId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_FieldOfUse_FieldOfUseId",
                        column: x => x.FieldOfUseId,
                        principalTable: "FieldOfUse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1L, "ffffff", "White" },
                    { 2L, "000000", "Black" }
                });

            migrationBuilder.InsertData(
                table: "FieldOfUse",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Normal" },
                    { 2L, "Taxi" },
                    { 3L, "Freight transport" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Car" },
                    { 2L, "Truck" },
                    { 3L, "Bus" },
                    { 4L, "Motorcycle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_Name_Code",
                table: "Color",
                columns: new[] { "Name", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfUse_Name",
                table: "FieldOfUse",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model_ManufacturerId",
                table: "Model",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ModelName",
                table: "Model",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owner_StreetId",
                table: "Owner",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_TAJ",
                table: "Owner",
                column: "TAJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Street_CityId",
                table: "Street",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Name",
                table: "Type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ColorId",
                table: "Vehicle",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FieldOfUseId",
                table: "Vehicle",
                column: "FieldOfUseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicencePlate",
                table: "Vehicle",
                column: "LicencePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OwnerId",
                table: "Vehicle",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "FieldOfUse");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
