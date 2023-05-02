using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Asp.Migrations
{
    /// <inheritdoc />
    public partial class _changeLoginTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AspNetUsers_Id",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Logins",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Logins");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Logins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "abc415c5-e65a-458b-8164-a53a99b5c4c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a8a4e7d-ceac-4bd0-a6e5-e17dde145b66", "AQAAAAEAACcQAAAAEKW3TNp9zY9DG2wOyKYShwe7Zvcy/v4ILtirRc8tzhT/pIedYTMDb99E0tRvucNDrA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AspNetUsers_Id",
                table: "Logins",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
