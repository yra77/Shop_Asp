using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Asp.Migrations
{
    /// <inheritdoc />
    public partial class _addCol_Login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "ec82fd6f-ee45-4a21-acbd-8263d015226a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9310be9c-7506-4cc6-b2c0-f255f3581f39", "AQAAAAEAACcQAAAAEFtTGaU/sgPCqj69Zb62y9Nd/nPTTxYwB8Ahy05Hez7gluSrZlOJh4vzLVe0hrbJag==" });
        }
    }
}
