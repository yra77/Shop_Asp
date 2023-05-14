using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Asp.Migrations
{
    /// <inheritdoc />
    public partial class _loginPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9c7bed06-b33a-498c-8566-850cfc62bfcb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc59b717-0e4e-4c46-93a1-fe0af8a0c6e4", "AQAAAAEAACcQAAAAEBZz3uR44nR/q0YFa2npELGFg4L+jq/9J+IfC7CNNBH/YUnGFkhsI5nEeRH60S6Tug==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Logins");

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
    }
}
