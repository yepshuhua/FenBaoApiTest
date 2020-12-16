using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FenBaoApiTest.Migrations
{
    public partial class f3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ActivityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParticipantsNum = table.Column<int>(nullable: true),
                    ActivityTime = table.Column<DateTime>(nullable: true),
                    ActivityEndTime = table.Column<DateTime>(nullable: true),
                    ActivtyAddress = table.Column<string>(nullable: true),
                    ActivtyStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    CommentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "activities",
                columns: new[] { "Id", "ActivityEndTime", "ActivityScore", "ActivityTime", "ActivtyAddress", "ActivtyStatus", "Name", "ParticipantsNum" },
                values: new object[] { new Guid("e109e697-a99f-40ab-b929-cee7b1338bf2"), null, 2.0m, new DateTime(2020, 12, 16, 17, 39, 43, 603, DateTimeKind.Local).AddTicks(3795), "博文楼", true, "1", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_comments_ActivityId",
                table: "comments",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "activities");
        }
    }
}
