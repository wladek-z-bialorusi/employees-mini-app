using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesMiniApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddYearOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Employees");
        }
    }
}
