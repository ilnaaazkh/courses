using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courses.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorship_Authors_AuthorsId",
                table: "Authorship");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorship_Courses_CoursesId",
                table: "Authorship");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "Authorship",
                newName: "CoursesAuthorshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorship_CoursesId",
                table: "Authorship",
                newName: "IX_Authorship_CoursesAuthorshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorship_AspNetUsers_AuthorsId",
                table: "Authorship",
                column: "AuthorsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorship_Courses_CoursesAuthorshipId",
                table: "Authorship",
                column: "CoursesAuthorshipId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorship_AspNetUsers_AuthorsId",
                table: "Authorship");

            migrationBuilder.DropForeignKey(
                name: "FK_Authorship_Courses_CoursesAuthorshipId",
                table: "Authorship");

            migrationBuilder.RenameColumn(
                name: "CoursesAuthorshipId",
                table: "Authorship",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_Authorship_CoursesAuthorshipId",
                table: "Authorship",
                newName: "IX_Authorship_CoursesId");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Authorship_Authors_AuthorsId",
                table: "Authorship",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorship_Courses_CoursesId",
                table: "Authorship",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
