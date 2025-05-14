using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HortaManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArduinoDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArduinoDevice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HortaReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsIrrigationActive = table.Column<bool>(type: "bit", nullable: false),
                    SoilHumidity = table.Column<int>(type: "int", nullable: false),
                    ArduinoDeviceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HortaReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HortaReport_ArduinoDevice_ArduinoDeviceId",
                        column: x => x.ArduinoDeviceId,
                        principalTable: "ArduinoDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoDevice_Code",
                table: "ArduinoDevice",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HortaReport_ArduinoDeviceId",
                table: "HortaReport",
                column: "ArduinoDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HortaReport");

            migrationBuilder.DropTable(
                name: "ArduinoDevice");
        }
    }
}
