using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackCapstone.Migrations
{
    public partial class viewModelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4877d9b6-ba31-46a5-9c66-f83b9111736c", "AQAAAAEAACcQAAAAEE6ElxTxoOr8UmeSWLw5V5xZeDpAHjIjbwFf5H1S/teXJD7RCR5TAT8jU/qZWfW4hQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2ab3bac-e9c7-482d-86bb-74a0981b2113", "AQAAAAEAACcQAAAAEJGaEJHnCe2zDCwGbR7H7kOiP3SK5AHckQ710iGJurfx+eqofa3ElUnGLh/3TB/sQQ==" });
        }
    }
}
