using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaTech.Data.Migrations
{
    public partial class ChangeSKPLUData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JamOperational");

            migrationBuilder.DropColumn(
                name: "IsACType",
                table: "SPKLU");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "SPKLU",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "SocketType",
                table: "SPKLU",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "SPKLU",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SPKLU");

            migrationBuilder.DropColumn(
                name: "SocketType",
                table: "SPKLU");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SPKLU");

            migrationBuilder.AddColumn<bool>(
                name: "IsACType",
                table: "SPKLU",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "JamOperational",
                columns: table => new
                {
                    JamOperationalID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishAt = table.Column<TimeSpan>(type: "time", nullable: true),
                    SKPLUID = table.Column<long>(type: "bigint", nullable: false),
                    StartAt = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JamOperational", x => x.JamOperationalID);
                });
        }
    }
}
