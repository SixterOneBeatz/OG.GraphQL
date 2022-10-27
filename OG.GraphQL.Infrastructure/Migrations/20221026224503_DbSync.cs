using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OG.GraphQL.Infrastructure.Migrations
{
    public partial class DbSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursePerson",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePerson", x => new { x.CourseId, x.PersonId });
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Administrator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Person",
                        column: x => x.InstructorID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CourseID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Person",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "OnlineCourse",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourse", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_OnlineCourse_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "OnsiteCourse",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Days = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnsiteCourse", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_OnsiteCourse_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_StudentGrade_Course",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Student",
                        column: x => x.StudentID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_PersonID",
                table: "CourseInstructor",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_CourseID",
                table: "StudentGrade",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_StudentID",
                table: "StudentGrade",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
