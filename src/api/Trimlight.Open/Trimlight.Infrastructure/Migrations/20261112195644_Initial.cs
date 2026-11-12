using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trimlight.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "custom_effect",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    custom_effect_mode = table.Column<byte>(type: "smallint", nullable: true),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    TrimlightEffectId = table.Column<int>(type: "integer", nullable: false),
                    speed = table.Column<byte>(type: "smallint", nullable: false),
                    brightness = table.Column<byte>(type: "smallint", nullable: false),
                    pixel_length = table.Column<int>(type: "integer", nullable: false),
                    reverse = table.Column<bool>(type: "boolean", nullable: false),
                    created_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_custom_effect", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    device_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    is_on = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    switch_state = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    connectivity_state = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    color_order = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    created_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pixel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    custom_effect_id = table.Column<int>(type: "integer", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    red = table.Column<byte>(type: "smallint", nullable: false),
                    blue = table.Column<byte>(type: "smallint", nullable: false),
                    green = table.Column<byte>(type: "smallint", nullable: false),
                    disabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pixel", x => x.id);
                    table.ForeignKey(
                        name: "fk_pixel_custom_effect",
                        column: x => x.custom_effect_id,
                        principalTable: "custom_effect",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "device_effect",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    custom_effect_id = table.Column<int>(type: "integer", nullable: true),
                    built_in_effect_id = table.Column<int>(type: "integer", nullable: true),
                    created_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_effect", x => x.id);
                    table.ForeignKey(
                        name: "FK_device_effect_custom_effect_custom_effect_id",
                        column: x => x.custom_effect_id,
                        principalTable: "custom_effect",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_device_device_effect",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pixel_port",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    start = table.Column<int>(type: "integer", nullable: false),
                    end = table.Column<int>(type: "integer", nullable: false),
                    trimlight_port_id = table.Column<int>(type: "integer", nullable: false),
                    created_at_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pixel_port", x => x.id);
                    table.ForeignKey(
                        name: "fk_device_pixel_port",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_device_effect_custom_effect_id",
                table: "device_effect",
                column: "custom_effect_id");

            migrationBuilder.CreateIndex(
                name: "uq_idx_device_effect_device_id",
                table: "device_effect",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pixel_custom_effect_id",
                table: "pixel",
                column: "custom_effect_id");

            migrationBuilder.CreateIndex(
                name: "IX_pixel_port_device_id",
                table: "pixel_port",
                column: "device_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_effect");

            migrationBuilder.DropTable(
                name: "pixel");

            migrationBuilder.DropTable(
                name: "pixel_port");

            migrationBuilder.DropTable(
                name: "custom_effect");

            migrationBuilder.DropTable(
                name: "device");
        }
    }
}
