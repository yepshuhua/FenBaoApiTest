using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FenBaoApiTest.Migrations
{
    public partial class f1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "activities",
                columns: new[] { "Id", "ActivityEndTime", "ActivityScore", "ActivityTime", "ActivtyAddress", "ActivtyStatus", "Comment", "Name", "ParticipantsNum" },
                values: new object[] { new Guid("d0615df1-f3a5-4097-9c62-4f124a71596a"), null, 2.0m, new DateTime(2020, 12, 9, 10, 33, 2, 771, DateTimeKind.Local).AddTicks(6920), "博文楼", true, "", "1", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "activities",
                keyColumn: "Id",
                keyValue: new Guid("d0615df1-f3a5-4097-9c62-4f124a71596a"));
        }
    }
}
