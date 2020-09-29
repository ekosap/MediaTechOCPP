using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaTech.Data.Migrations
{
    public partial class AddJamOpersionalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JamOperational",
                columns: table => new
                {
                    JamOperationalID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKPLUID = table.Column<long>(nullable: false),
                    StartAt = table.Column<TimeSpan>(nullable: true),
                    FinishAt = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JamOperational", x => x.JamOperationalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JamOperational");
        }
    }
}
