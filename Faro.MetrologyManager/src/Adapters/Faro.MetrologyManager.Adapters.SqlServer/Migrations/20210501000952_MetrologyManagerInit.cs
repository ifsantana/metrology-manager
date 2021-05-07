using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Faro.MetrologyManager.Adapters.SqlServer.Migrations
{
    public partial class MetrologyManagerInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MetrologyManager");

            migrationBuilder.CreateTable(
                name: "NOMINAL_POINT",
                schema: "MetrologyManager",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    X = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    Y = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    Z = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    ROW_VERSION = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOMINAL_POINT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACTUAL_POINT",
                schema: "MetrologyManager",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMINAL_POINT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    X = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    Y = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    Z = table.Column<decimal>(type: "decimal(38,16)", precision: 38, scale: 16, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    ROW_VERSION = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTUAL_POINT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACTUAL_POINT_NOMINAL_POINT_NOMINAL_POINT_ID",
                        column: x => x.NOMINAL_POINT_ID,
                        principalSchema: "MetrologyManager",
                        principalTable: "NOMINAL_POINT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTUAL_POINT_NOMINAL_POINT",
                schema: "MetrologyManager",
                table: "ACTUAL_POINT",
                column: "NOMINAL_POINT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTUAL_POINT",
                schema: "MetrologyManager");

            migrationBuilder.DropTable(
                name: "NOMINAL_POINT",
                schema: "MetrologyManager");
        }
    }
}
