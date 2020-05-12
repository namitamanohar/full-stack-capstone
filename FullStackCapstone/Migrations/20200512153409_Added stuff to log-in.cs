using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackCapstone.Migrations
{
    public partial class Addedstufftologin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Opportunity",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eac14cef-f519-4bfe-aebe-341e1ccea115", "AQAAAAEAACcQAAAAEM6ezF5PWPFc5J/72nci6Q/LlsYgFdtST9GI/SPIn3apxujV7KWiGtCYOme8UTsSSw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Opportunity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1804c298-d5c8-4f1c-afb5-bb999c59de28", "AQAAAAEAACcQAAAAEMyQ3uwXhohCxZ8f0AzbRiTTESAEEtOTCV8Zb67poQhukfMI6/2cA+9xTHaFQCYBOQ==" });
        }
    }
}
