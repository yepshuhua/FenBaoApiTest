using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FenBaoApiTest.Migrations
{
    public partial class f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("d0615df1-f3a5-4097-9c62-4f124a71596a"));

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    CommentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "activities",
                columns: new[] { "Id", "ActivityEndTime", "ActivityScore", "ActivityTime", "ActivtyAddress", "ActivtyStatus", "Comment", "Name", "ParticipantsNum" },
                values: new object[] { new Guid("039f4b7e-5a85-47a5-be57-cb12818e09de"), null, 2.0m, new DateTime(2020, 12, 9, 11, 2, 38, 818, DateTimeKind.Local).AddTicks(9768), "博文楼", true, "", "1", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ActivityId",
                table: "Comment",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DeleteData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("039f4b7e-5a85-47a5-be57-cb12818e09de"));

            migrationBuilder.InsertData(
                table: "activities",
                columns: new[] { "Id", "ActivityEndTime", "ActivityScore", "ActivityTime", "ActivtyAddress", "ActivtyStatus", "Comment", "Name", "ParticipantsNum" },
                values: new object[] { new Guid("d0615df1-f3a5-4097-9c62-4f124a71596a"), null, 2.0m, new DateTime(2020, 12, 9, 10, 33, 2, 771, DateTimeKind.Local).AddTicks(6920), "博文楼", true, "", "1", 2 });
        }
    }
}
