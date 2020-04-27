using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemetrics.Migrations
{
    public partial class TelemetricsModelsTelegramContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telegrams",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    p1 = table.Column<double>(type: "float", nullable: false),
                    p2 = table.Column<double>(type: "float", nullable: false),
                    p3 = table.Column<double>(type: "float", nullable: false),
                    p4 = table.Column<double>(type: "float", nullable: false),
                    p5 = table.Column<double>(type: "float", nullable: false),
                    t1 = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telegrams", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telegrams");
        }
    }
}
