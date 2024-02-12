using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StudentsDashboard.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkEventAndWorkTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Customer = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<double>(type: "double precision", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    From_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    From_Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    To_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    To_Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Customer = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkEvents");

            migrationBuilder.DropTable(
                name: "WorkTasks");
        }
    }
}
