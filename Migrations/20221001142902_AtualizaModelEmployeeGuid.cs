using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_de_Ponto_CTEDS.Migrations
{
    public partial class AtualizaModelEmployeeGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clocks_employees_EmployeeId",
                table: "clocks");

            migrationBuilder.DropIndex(
                name: "IX_clocks_EmployeeId",
                table: "clocks");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "employees",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "clocks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clocks_EmployeeId1",
                table: "clocks",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_clocks_employees_EmployeeId1",
                table: "clocks",
                column: "EmployeeId1",
                principalTable: "employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clocks_employees_EmployeeId1",
                table: "clocks");

            migrationBuilder.DropIndex(
                name: "IX_clocks_EmployeeId1",
                table: "clocks");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "clocks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "employees",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_clocks_EmployeeId",
                table: "clocks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_clocks_employees_EmployeeId",
                table: "clocks",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
