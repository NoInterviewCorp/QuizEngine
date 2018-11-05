using Microsoft.EntityFrameworkCore.Migrations;

namespace aspback.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<string>(nullable: false),
                    Technologyname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Temporaries",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    QuizId = table.Column<string>(nullable: true),
                    TechName = table.Column<string>(nullable: true),
                    TopicCompleted = table.Column<int>(nullable: false),
                    Blooms = table.Column<int>(nullable: false),
                    AttemptedOn = table.Column<string>(nullable: true),
                    TempScore = table.Column<int>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporaries", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    ThresholdId = table.Column<int>(nullable: false),
                    BloomLevel = table.Column<int>(nullable: false),
                    MinThreshold = table.Column<int>(nullable: false),
                    MaxThreshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.ThresholdId);
                });

            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(nullable: false),
                    TopicName = table.Column<string>(nullable: true),
                    TechnologyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizDatas",
                columns: table => new
                {
                    QuizId = table.Column<string>(nullable: false),
                    TechName = table.Column<string>(nullable: true),
                    TopicCompleted = table.Column<int>(nullable: false),
                    Blooms = table.Column<int>(nullable: false),
                    AttemptedOn = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizDatas", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_QuizDatas_UserDatas_UserName",
                        column: x => x.UserName,
                        principalTable: "UserDatas",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<string>(nullable: false),
                    ProblemStatement = table.Column<string>(nullable: false),
                    ResourceLink = table.Column<string>(nullable: true),
                    BloomLevel = table.Column<int>(nullable: false),
                    HasPublished = table.Column<bool>(nullable: false),
                    TopicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizDatas_UserName",
                table: "QuizDatas",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TechnologyId",
                table: "Topics",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "QuizDatas");

            migrationBuilder.DropTable(
                name: "Temporaries");

            migrationBuilder.DropTable(
                name: "Thresholds");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "UserDatas");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
