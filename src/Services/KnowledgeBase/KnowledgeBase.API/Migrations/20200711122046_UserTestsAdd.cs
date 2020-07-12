using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.API.Migrations
{
    public partial class UserTestsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_Tests_TestId",
                table: "UserTest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_Users_UserId",
                table: "UserTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest");

            migrationBuilder.RenameTable(
                name: "UserTest",
                newName: "UserTests");

            migrationBuilder.RenameIndex(
                name: "IX_UserTest_TestId",
                table: "UserTests",
                newName: "IX_UserTests_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTests",
                table: "UserTests",
                columns: new[] { "UserId", "TestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_Tests_TestId",
                table: "UserTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_Users_UserId",
                table: "UserTests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_Tests_TestId",
                table: "UserTests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_Users_UserId",
                table: "UserTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTests",
                table: "UserTests");

            migrationBuilder.RenameTable(
                name: "UserTests",
                newName: "UserTest");

            migrationBuilder.RenameIndex(
                name: "IX_UserTests_TestId",
                table: "UserTest",
                newName: "IX_UserTest_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest",
                columns: new[] { "UserId", "TestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_Tests_TestId",
                table: "UserTest",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_Users_UserId",
                table: "UserTest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
