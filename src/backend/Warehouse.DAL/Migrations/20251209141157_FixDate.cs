using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangedTime",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 9, 14, 11, 56, 942, DateTimeKind.Utc).AddTicks(5828),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangedTime",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 12, 9, 14, 11, 56, 942, DateTimeKind.Utc).AddTicks(5828));
        }
    }
}
