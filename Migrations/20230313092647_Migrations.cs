using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapplication.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingDetails",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ratings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingDetails", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "ReimbursementDetails",
                columns: table => new
                {
                    ReimbursementNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enddate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Projecttitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tripto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suggesstion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementDetails", x => x.ReimbursementNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingDetails");

            migrationBuilder.DropTable(
                name: "ReimbursementDetails");
        }
    }
}
