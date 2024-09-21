using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicles.Database.Migrations
{
    /// <inheritdoc />
    public partial class FieldOfUse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FieldOfUseId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.InsertData(
                table: "FieldOfUse",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Normal" },
                    { 2L, "Taxi" },
                    { 3L, "Freight transport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_FieldOfUseId",
                table: "Vehicle",
                column: "FieldOfUseId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfUse_Name",
                table: "FieldOfUse",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_FieldOfUse_FieldOfUseId",
                table: "Vehicle",
                column: "FieldOfUseId",
                principalTable: "FieldOfUse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_FieldOfUse_FieldOfUseId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "FieldOfUse");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_FieldOfUseId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FieldOfUseId",
                table: "Vehicle");
        }
    }
}
