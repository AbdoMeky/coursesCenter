using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coursesCenter.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationBetweenUserApplicationAndInstructorAndTraine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Traines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Traines_ApplicationUserId",
                table: "Traines",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ApplicationUserId",
                table: "Instructors",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserId",
                table: "Instructors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traines_AspNetUsers_ApplicationUserId",
                table: "Traines",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Traines_AspNetUsers_ApplicationUserId",
                table: "Traines");

            migrationBuilder.DropIndex(
                name: "IX_Traines_ApplicationUserId",
                table: "Traines");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ApplicationUserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Traines");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Instructors");
        }
    }
}
