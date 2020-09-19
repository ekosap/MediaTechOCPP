using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaTech.Data.Migrations
{
    public partial class AddDetailSPKLUdiLocationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alamat",
                table: "LocationDB",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsACType",
                table: "LocationDB",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alamat",
                table: "LocationDB");

            migrationBuilder.DropColumn(
                name: "IsACType",
                table: "LocationDB");
        }
    }
}
