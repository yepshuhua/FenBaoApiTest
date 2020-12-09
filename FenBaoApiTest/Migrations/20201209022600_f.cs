using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FenBaoApiTest.Migrations
{
    public partial class f : Migration
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
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    ActivityTime = table.Column<DateTime>(nullable: true),
                    ActivityEndTime = table.Column<DateTime>(nullable: true),
                    ActivtyAddress = table.Column<string>(nullable: true),
                    ActivtyStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activities");
        }
    }
}
