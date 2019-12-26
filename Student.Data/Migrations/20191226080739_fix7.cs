using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class fix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ortalama",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Sozlu1",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Sozlu2",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Yazili1",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Yazili2",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Yazili3",
                table: "LessonUserMap");

            migrationBuilder.AddColumn<decimal>(
                name: "Average",
                table: "LessonUserMap",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Exam1",
                table: "LessonUserMap",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Exam2",
                table: "LessonUserMap",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Exam3",
                table: "LessonUserMap",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VerbalExam1",
                table: "LessonUserMap",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VerbalExam2",
                table: "LessonUserMap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Average",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Exam1",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Exam2",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "Exam3",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "VerbalExam1",
                table: "LessonUserMap");

            migrationBuilder.DropColumn(
                name: "VerbalExam2",
                table: "LessonUserMap");

            migrationBuilder.AddColumn<decimal>(
                name: "Ortalama",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sozlu1",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sozlu2",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Yazili1",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Yazili2",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Yazili3",
                table: "LessonUserMap",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
