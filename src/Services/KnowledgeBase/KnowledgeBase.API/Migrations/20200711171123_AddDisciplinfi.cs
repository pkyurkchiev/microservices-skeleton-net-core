using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.API.Migrations
{
    public partial class AddDisciplinfi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Discipline_DisciplineId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline");

            migrationBuilder.RenameTable(
                name: "Discipline",
                newName: "Disciplines");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutionStatus",
                table: "Tests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineId",
                table: "Tests",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Questions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DisciplineId",
                table: "Questions",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Disciplines_DisciplineId",
                table: "Questions",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Disciplines_DisciplineId",
                table: "Tests",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Disciplines_DisciplineId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Disciplines_DisciplineId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DisciplineId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "Discipline");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutionStatus",
                table: "Tests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Discipline_DisciplineId",
                table: "Tests",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
