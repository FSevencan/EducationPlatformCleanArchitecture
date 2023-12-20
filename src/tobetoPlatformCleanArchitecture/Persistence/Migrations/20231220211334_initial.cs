using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalTime = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    QuestionCount = table.Column<int>(type: "int", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducerCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducerCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_ProducerCompanies_ProducerCompanyId",
                        column: x => x.ProducerCompanyId,
                        principalTable: "ProducerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionAbouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducerCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDuration = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionAbouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionAbouts_ProducerCompanies_ProducerCompanyId",
                        column: x => x.ProducerCompanyId,
                        principalTable: "ProducerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionAbouts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionCourses_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionInstructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionInstructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionInstructors_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionInstructors_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClassRooms_ClassRooms_ClassRoomId1",
                        column: x => x.ClassRoomId1,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassRooms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSections_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSkills_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSurveys_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSurveys_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Admin", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Read", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Write", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Add", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Update", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Delete", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Admin", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Read", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Write", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Add", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Update", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Delete", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Admin", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Read", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Write", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Add", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Update", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationEducations.Delete", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Admin", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Read", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Write", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Add", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Update", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Certificates.Delete", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Admin", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Read", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Write", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Add", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Update", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ClassRooms.Delete", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Admin", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Read", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Write", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Add", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Update", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Courses.Delete", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Admin", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Read", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Write", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Add", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Update", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Exams.Delete", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Admin", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Read", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Write", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Add", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Update", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Instructors.Delete", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Admin", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Read", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Write", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Add", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Update", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Delete", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Admin", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Read", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Write", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Add", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Update", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lessons.Delete", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Admin", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Read", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Write", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Add", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Update", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProducerCompanies.Delete", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Admin", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Read", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Write", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Add", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Update", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sections.Delete", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Admin", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Read", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Write", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Add", null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Update", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionAbouts.Delete", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Admin", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Read", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Write", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Add", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Update", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionCourses.Delete", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Admin", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Read", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Write", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Add", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Update", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SectionInstructors.Delete", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Admin", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Read", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Write", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Add", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Update", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skills.Delete", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Admin", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Read", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Write", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Add", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Update", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Delete", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Admin", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Read", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Write", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Add", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Update", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentClassRooms.Delete", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Admin", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Read", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Write", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Add", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Update", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSections.Delete", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Admin", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Read", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Write", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Add", null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Update", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSkills.Delete", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Admin", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Read", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Write", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Add", null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Update", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "StudentSurveys.Delete", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Admin", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Read", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Write", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Add", null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Update", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Surveys.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status", "UpdatedDate" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.com", "Admin", "NArchitecture", new byte[] { 26, 149, 150, 124, 144, 44, 127, 194, 150, 134, 201, 32, 61, 92, 99, 215, 16, 244, 122, 137, 241, 197, 14, 72, 34, 170, 207, 252, 233, 16, 253, 121, 232, 80, 9, 130, 106, 108, 85, 110, 225, 101, 42, 37, 60, 114, 169, 241, 113, 138, 27, 74, 98, 210, 72, 198, 106, 35, 148, 59, 93, 14, 191, 90 }, new byte[] { 198, 149, 206, 34, 228, 94, 157, 172, 172, 109, 164, 31, 147, 60, 18, 94, 55, 226, 194, 155, 222, 138, 235, 56, 104, 145, 159, 169, 146, 162, 243, 235, 105, 55, 188, 184, 159, 248, 90, 219, 10, 177, 143, 121, 254, 63, 65, 87, 167, 182, 200, 212, 90, 33, 0, 157, 254, 224, 30, 24, 238, 4, 119, 166, 51, 180, 25, 247, 211, 95, 23, 73, 131, 204, 44, 239, 65, 96, 97, 181, 202, 136, 236, 227, 67, 110, 214, 17, 254, 178, 197, 122, 224, 53, 78, 121, 147, 81, 22, 214, 34, 80, 77, 13, 55, 180, 159, 239, 55, 175, 216, 113, 212, 77, 120, 250, 26, 40, 80, 254, 86, 0, 163, 243, 198, 126, 218, 135 }, true, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_StudentId",
                table: "Certificates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LanguageId",
                table: "Lessons",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ProducerCompanyId",
                table: "Lessons",
                column: "ProducerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionAbouts_ProducerCompanyId",
                table: "SectionAbouts",
                column: "ProducerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionAbouts_SectionId",
                table: "SectionAbouts",
                column: "SectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionCourses_CourseId",
                table: "SectionCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionCourses_SectionId",
                table: "SectionCourses",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionInstructors_InstructorId",
                table: "SectionInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionInstructors_SectionId",
                table: "SectionInstructors",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CategoryId",
                table: "Sections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRooms_ClassRoomId1",
                table: "StudentClassRooms",
                column: "ClassRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRooms_StudentId",
                table: "StudentClassRooms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSections_SectionId",
                table: "StudentSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSections_StudentId",
                table: "StudentSections",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkills_SkillId",
                table: "StudentSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkills_StudentId",
                table: "StudentSkills",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSurveys_StudentId",
                table: "StudentSurveys",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSurveys_SurveyId",
                table: "StudentSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "ApplicationEducations");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SectionAbouts");

            migrationBuilder.DropTable(
                name: "SectionCourses");

            migrationBuilder.DropTable(
                name: "SectionInstructors");

            migrationBuilder.DropTable(
                name: "StudentClassRooms");

            migrationBuilder.DropTable(
                name: "StudentSections");

            migrationBuilder.DropTable(
                name: "StudentSkills");

            migrationBuilder.DropTable(
                name: "StudentSurveys");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProducerCompanies");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
