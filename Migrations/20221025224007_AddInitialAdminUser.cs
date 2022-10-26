using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_de_Ponto_CTEDS.Migrations
{
    public partial class AddInitialAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Cpf", "IsAdmin", "Name", "Password" },
                values: new object[] { 1, "0000", true, "Admin", "$2a$11$nehUzrh.tkxudXMUcGpK2ueGv0WGlHwHdBnnG709sk6eivE4.I0he" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
