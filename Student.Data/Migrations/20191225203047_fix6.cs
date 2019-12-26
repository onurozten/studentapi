using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId1",
                table: "LessonUserMap");

            migrationBuilder.DropIndex(
                name: "IX_LessonUserMap_UserId1",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "LessonUserMap");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LessonUserMap",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMap_UserId",
                table: "LessonUserMap",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId",
                table: "LessonUserMap",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId",
                table: "LessonUserMap");

            migrationBuilder.DropIndex(
                name: "IX_LessonUserMap_UserId",
                table: "LessonUserMap");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LessonUserMap",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "LessonUserMap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMap_UserId1",
                table: "LessonUserMap",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId1",
                table: "LessonUserMap",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
