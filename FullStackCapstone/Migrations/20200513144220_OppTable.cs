using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackCapstone.Migrations
{
    public partial class OppTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2ab3bac-e9c7-482d-86bb-74a0981b2113", "AQAAAAEAACcQAAAAEJGaEJHnCe2zDCwGbR7H7kOiP3SK5AHckQ710iGJurfx+eqofa3ElUnGLh/3TB/sQQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af6570a1-bedc-4c2b-8ace-4c47227c6387", "AQAAAAEAACcQAAAAEGe/c+4eNuprihPxfHfF7Wupp1/B34IU0AFdFlKFhe/W0GOyzvjqTJSvrwkrGDORfg==" });
        }
    }
}
