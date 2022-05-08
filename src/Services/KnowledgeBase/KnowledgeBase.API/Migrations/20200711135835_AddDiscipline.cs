using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.API.Migrations
{
    public partial class AddDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinish",
                table: "Tests");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExternalId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "FacultyNumber",
                table: "Users",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Tests",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ExecutionStatus",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_DisciplineId",
                table: "Tests",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Discipline_DisciplineId",
                table: "Tests",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Discipline_DisciplineId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Tests_DisciplineId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "FacultyNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ExecutionStatus",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "ExternalId",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "IsFinish",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
