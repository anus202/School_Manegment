using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Manegment.Migrations
{
    /// <inheritdoc />
    public partial class MAK_UpdateAginStudentTbl11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrentNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhatappNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrentNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "WhatappNumber",
                table: "Students");
        }
    }
}
