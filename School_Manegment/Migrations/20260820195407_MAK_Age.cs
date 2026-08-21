using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Manegment.Migrations
{
    /// <inheritdoc />
    public partial class MAK_Age : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "FatherCNIC");

            migrationBuilder.RenameColumn(
                name: "EmergencyContact",
                table: "Students",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FatherCNIC",
                table: "Students",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Students",
                newName: "EmergencyContact");
        }
    }
}
