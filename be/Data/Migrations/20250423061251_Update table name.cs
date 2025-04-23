using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Examination_AspNetUsers_User_id",
                table: "AspNetUsers_Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Examination_Examinations_Exam_id",
                table: "AspNetUsers_Examination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers_Examination",
                table: "AspNetUsers_Examination");

            migrationBuilder.RenameTable(
                name: "AspNetUsers_Examination",
                newName: "AspNetUsers_Examinations");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Examination_Exam_id",
                table: "AspNetUsers_Examinations",
                newName: "IX_AspNetUsers_Examinations_Exam_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers_Examinations",
                table: "AspNetUsers_Examinations",
                columns: new[] { "User_id", "Exam_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Examinations_AspNetUsers_User_id",
                table: "AspNetUsers_Examinations",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Examinations_Examinations_Exam_id",
                table: "AspNetUsers_Examinations",
                column: "Exam_id",
                principalTable: "Examinations",
                principalColumn: "Exam_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Examinations_AspNetUsers_User_id",
                table: "AspNetUsers_Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Examinations_Examinations_Exam_id",
                table: "AspNetUsers_Examinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers_Examinations",
                table: "AspNetUsers_Examinations");

            migrationBuilder.RenameTable(
                name: "AspNetUsers_Examinations",
                newName: "AspNetUsers_Examination");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Examinations_Exam_id",
                table: "AspNetUsers_Examination",
                newName: "IX_AspNetUsers_Examination_Exam_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers_Examination",
                table: "AspNetUsers_Examination",
                columns: new[] { "User_id", "Exam_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Examination_AspNetUsers_User_id",
                table: "AspNetUsers_Examination",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Examination_Examinations_Exam_id",
                table: "AspNetUsers_Examination",
                column: "Exam_id",
                principalTable: "Examinations",
                principalColumn: "Exam_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
