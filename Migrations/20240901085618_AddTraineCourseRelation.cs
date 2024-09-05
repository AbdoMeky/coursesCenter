using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coursesCenter.Migrations
{
    /// <inheritdoc />
    public partial class AddTraineCourseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraineCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TraineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineCourses", x => new { x.TraineId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TraineCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineCourses_Traines_TraineId",
                        column: x => x.TraineId,
                        principalTable: "Traines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineCourses_CourseId",
                table: "TraineCourses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineCourses");
        }
    }
}
