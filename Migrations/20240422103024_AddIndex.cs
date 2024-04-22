using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Branch.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_CivilId",
                table: "Employees",
                column: "CivilId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_CivilId",
                table: "Employees");
        }
    }
}
