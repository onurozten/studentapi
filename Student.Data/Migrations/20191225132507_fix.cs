using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassUserMap");

            migrationBuilder.CreateTable(
                name: "LessonUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    LessonId = table.Column<int>(nullable: false),
                    Yazili1 = table.Column<decimal>(nullable: true),
                    Yazili2 = table.Column<decimal>(nullable: true),
                    Yazili3 = table.Column<decimal>(nullable: true),
                    Sozlu1 = table.Column<decimal>(nullable: true),
                    Sozlu2 = table.Column<decimal>(nullable: true),
                    Ortalama = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonUserMap_Class_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonUserMap_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMap_LessonId",
                table: "LessonUserMap",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMap_UserId",
                table: "LessonUserMap",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonUserMap");

            migrationBuilder.CreateTable(
                name: "ClassUserMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Sozlu1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sozlu2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Yazili1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Yazili2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Yazili3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUserMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassUserMap_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassUserMap_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassUserMap_ClassId",
                table: "ClassUserMap",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUserMap_UserId",
                table: "ClassUserMap",
                column: "UserId");
        }
    }
}
