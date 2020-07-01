using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.API.Migrations
{
    public partial class TestFinishFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedOn",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinish",
                table: "Tests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedOn",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsFinish",
                table: "Tests");
        }
    }
}
