using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class Capital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkedinAt",
                table: "Pets",
                newName: "checkedInAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "checkedInAt",
                table: "Pets",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checkedInAt",
                table: "Pets",
                newName: "checkedinAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "checkedinAt",
                table: "Pets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
