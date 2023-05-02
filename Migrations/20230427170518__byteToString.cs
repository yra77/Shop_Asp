using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Asp.Migrations
{
    /// <inheritdoc />
    public partial class _byteToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageAccount",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "521a8c45-e3ee-414c-9750-ff4b594523aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a1c7c21-5e00-4560-8314-d40ace5ded6c", "AQAAAAEAACcQAAAAEEQz2+caxB+o3Lv/zP8ANUUzNMiZX4ClceMO+MiZ4hT2g7Mpv0ZCr0VrGFiwKZfLgA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageAccount",
                table: "Logins",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
