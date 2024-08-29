using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTest_BCICentral.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionProject",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectLocation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectConstructionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectDetails = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ProjectCreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionProject", x => x.ProjectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionProject");
        }
    }
}
