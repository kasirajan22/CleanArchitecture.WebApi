using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class usersession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(4010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(1850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 7, 10, 43, 54, 972, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(1320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 7, 10, 43, 54, 972, DateTimeKind.Local).AddTicks(2240));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserSessions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 7, 10, 43, 54, 972, DateTimeKind.Local).AddTicks(2790),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 7, 10, 43, 54, 972, DateTimeKind.Local).AddTicks(2240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 7, 11, 19, 55, 938, DateTimeKind.Local).AddTicks(1320));
        }
    }
}
