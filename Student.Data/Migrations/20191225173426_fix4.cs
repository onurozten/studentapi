using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId",
                table: "LessonUserMap");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUserMap_AspNetUsers_UserId",
                table: "LessonUserMap",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
