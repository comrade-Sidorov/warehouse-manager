using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Warehouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangedTime",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 26, 6, 42, 45, 515, DateTimeKind.Utc).AddTicks(6708),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 12, 9, 14, 43, 44, 997, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.CreateTable(
                name: "AdmissionDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2025, 12, 26, 6, 42, 45, 522, DateTimeKind.Utc).AddTicks(4453))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionResources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceId = table.Column<long>(type: "bigint", nullable: false),
                    MeasureId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionDocuments");

            migrationBuilder.DropTable(
                name: "AdmissionResources");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangedTime",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 9, 14, 43, 44, 997, DateTimeKind.Utc).AddTicks(9616),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 12, 26, 6, 42, 45, 515, DateTimeKind.Utc).AddTicks(6708));
        }
    }
}
