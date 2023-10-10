using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.data.Migrations
{
    public partial class Kindergarten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileToDatabase",
                table: "FileToDatabase");

            migrationBuilder.RenameTable(
                name: "FileToDatabase",
                newName: "FileToDatabases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileToDatabases",
                table: "FileToDatabases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KinderGartens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildrenCount = table.Column<int>(type: "int", nullable: false),
                    KinderGartenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinderGartens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KinderGartens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileToDatabases",
                table: "FileToDatabases");

            migrationBuilder.RenameTable(
                name: "FileToDatabases",
                newName: "FileToDatabase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileToDatabase",
                table: "FileToDatabase",
                column: "Id");
        }
    }
}
