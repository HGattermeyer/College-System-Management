using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace College_System_Management.Migrations
{
    public partial class Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject");
        }
    }
}
