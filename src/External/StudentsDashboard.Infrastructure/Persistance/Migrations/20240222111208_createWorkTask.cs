using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsDashboard.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class createWorkTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "WorkTasks",
                newName: "IdUser");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "WorkTasks",
                newName: "Id_Customer");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "WorkTasks",
                newName: "Desciption");
        }
    }
}
