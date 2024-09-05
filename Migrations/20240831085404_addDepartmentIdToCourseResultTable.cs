using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coursesCenter.Migrations
{
    /// <inheritdoc />
    public partial class addDepartmentIdToCourseResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CourseResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartrmentId",
                table: "CourseResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_DepartrmentId",
                table: "CourseResults",
                column: "DepartrmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Departments_DepartrmentId",
                table: "CourseResults",
                column: "DepartrmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Departments_DepartrmentId",
                table: "CourseResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseResults_DepartrmentId",
                table: "CourseResults");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CourseResults");

            migrationBuilder.DropColumn(
                name: "DepartrmentId",
                table: "CourseResults");
        }
    }
}
