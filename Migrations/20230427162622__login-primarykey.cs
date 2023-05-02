using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Asp.Migrations
{
    /// <inheritdoc />
    public partial class _loginprimarykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "da7ba133-87f9-4755-8ecc-c007e0aae10e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39ebd577-756c-4f86-b58e-1cad35c77e20", "AQAAAAEAACcQAAAAEGjhHBtuZnktXwxuuukHYnFVgbpe8qb2+ZsVdDQprtK4a8nOtDyBH2PRJCFRBfEXnQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "dc30aff3-4bba-402c-af0f-8f7da034d8de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a2d7811-3040-4588-ab33-316759820018", "AQAAAAEAACcQAAAAEAulfnpY99s8vW/mWcLd1nhVGlo+SMdSU1UnMyyQ+/Gt5t9Dlnef2ci892Xo6sD0TA==" });
        }
    }
}
