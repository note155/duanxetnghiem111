using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace duanxetnghiem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCre5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "DXNandGXNs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaOngNghiem",
                table: "DXNandGXNs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Star",
                table: "DXNandGXNs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "DXNandGXNs");

            migrationBuilder.DropColumn(
                name: "MaOngNghiem",
                table: "DXNandGXNs");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "DXNandGXNs");
        }
    }
}
