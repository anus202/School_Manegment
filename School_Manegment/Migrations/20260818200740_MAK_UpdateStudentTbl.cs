using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Manegment.Migrations
{
    /// <inheritdoc />
    public partial class MAK_UpdateStudentTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdmitionDate",
                table: "Students",
                newName: "AdmissionDate");

            migrationBuilder.AddColumn<string>(
                name: "BForm",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContact",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BForm",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AdmissionDate",
                table: "Students",
                newName: "AdmitionDate");
        }
    }
}
