using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaTech.Data.Migrations
{
    public partial class ChangeSKPLUData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPKLU");

            migrationBuilder.CreateTable(
                name: "SKPLU",
                columns: table => new
                {
                    SKPLUID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    SocketType = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    MapLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKPLU", x => x.SKPLUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKPLU");

            migrationBuilder.CreateTable(
                name: "SPKLU",
                columns: table => new
                {
                    SPKLUId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ModifyBy = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SPKLUName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocketType = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPKLU", x => x.SPKLUId);
                });
        }
    }
}
